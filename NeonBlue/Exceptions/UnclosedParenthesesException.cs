namespace NeonBlue.Expressions.Exceptions
{
    [Serializable]
    public class UnclosedParenthesesException : Exception
    {
        public UnclosedParenthesesException()
        {
        }

        public UnclosedParenthesesException(string? message) : base(message)
        {
        }

        public UnclosedParenthesesException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}