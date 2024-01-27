namespace Lumex.Services.Exceptions
{
    public class LumexException : Exception
    {
        public int Code { get; set; }
        public LumexException(int code, string message) : base(message)
        {
            Code = code;
        }
    }
}
