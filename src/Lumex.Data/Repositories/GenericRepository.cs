using Lumex.Data.DbContexts;
using Lumex.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lumex.Data.Repositories
{
    public class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : class
    {
        private readonly AppDbContext dbContext;
        private readonly DbSet<TSource> _dbSet;

        public GenericRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            this._dbSet = dbContext.Set<TSource>();
        }

        /// <inheritdoc cref="IRepository{TSource}.AddAsync" />
        public async ValueTask<TSource?> AddAsync(
            TSource? entity, bool withSaveChanges = false,
            CancellationToken token = default)
        {
            if (token.IsCancellationRequested)
                await ValueTask.FromCanceled(token);

            var entry = await _dbSet.AddAsync(entity, token);

            if (withSaveChanges)
                await SaveChangesAsync(token);

            return entry.Entity;
        }

        public async ValueTask<bool> DeleteAsync(
        TSource? entity, bool withSaveChanges = false,
        CancellationToken token = default)
        {
            if (token.IsCancellationRequested)
                await ValueTask.FromCanceled(token);

            var isDeleted = await Task.Run(() => _dbSet.Remove(entity), token);

            if (withSaveChanges)
                await SaveChangesAsync(token);

            return true;
        }

        /// <inheritdoc cref="IRepository{TSource}.GetAll" />
        public IQueryable<TSource?> GetAll(
            Expression<Func<TSource, bool>>? expression = null,
            string[]? includes = null, bool isTracking = true)
        {
            IQueryable<TSource?> query = expression is null ? _dbSet : _dbSet.Where(expression);

            if (includes is not null)
                foreach (var include in includes)
                    query = query.Include(include);

            if (!isTracking)
                query = query.AsNoTracking();

            return query;
        }

        /// <inheritdoc cref="IRepository{TSource}.GetAsync" />
        public async ValueTask<TSource?> GetAsync(
            Expression<Func<TSource, bool>>? expression,
            string[]? includes = null,
            CancellationToken token = default)
        {
            if (token.IsCancellationRequested)
                await ValueTask.FromCanceled(token);

            return await GetAll(expression, includes).FirstOrDefaultAsync(token);
        }

        public async ValueTask<int> SaveChangesAsync(CancellationToken token = default)
        {
            if (token.IsCancellationRequested)
                await ValueTask.FromCanceled(token);

            return await dbContext.SaveChangesAsync(token);
        }

        /// <inheritdoc cref="IRepository{TSource}.UpdateAsync" />
        public async ValueTask<TSource?> UpdateAsync(
            TSource? entity, bool withSaveChanges = false,
            CancellationToken token = default)
        {
            if (token.IsCancellationRequested)
                await ValueTask.FromCanceled(token);

            var updatedSource = await Task.Run(() => _dbSet.Update(entity), token);

            if (withSaveChanges)
                await SaveChangesAsync(token);

            return updatedSource.Entity;
        }
    }
}
