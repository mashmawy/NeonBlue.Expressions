namespace NeonBlue.Expressions.Exceptions
{
    [Serializable]
    public class CustomFunctionException : Exception
    {
        public CustomFunctionException()
        {
        }

        public CustomFunctionException(string? message) : base(message)
        {
        }

        public CustomFunctionException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}


