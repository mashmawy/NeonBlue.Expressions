namespace NeonBlue.Expressions.Exceptions
{
    [Serializable]
    public class NullTokenExecption : Exception
    {
        public Token Arg1 { get; private set; }

        public NullTokenExecption(Token arg1)
        {
            Arg1 = arg1;
        }

        public NullTokenExecption(Token arg1, string? message) : base(message)
        {
            Arg1 = arg1;
        }

        public NullTokenExecption(Token arg1, string? message, Exception? innerException) : base(message, innerException)
        {
            Arg1 = arg1;
        }
    }


}