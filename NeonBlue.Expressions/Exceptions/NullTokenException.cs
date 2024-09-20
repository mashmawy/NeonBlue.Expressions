namespace NeonBlue.Expressions
{
    [Serializable]
    public class NullTokenException : Exception
    {
        public Token Arg1 { get; private set; }

        public NullTokenException(Token arg1)
        {
            Arg1 = arg1;
        }

        public NullTokenException(Token arg1, string? message) : base(message)
        {
            Arg1 = arg1;
        }

        public NullTokenException(Token arg1, string? message, Exception? innerException) : base(message, innerException)
        {
            Arg1 = arg1;
        }
    }


}