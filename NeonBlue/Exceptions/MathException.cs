namespace NeonBlue.Expressions.Exceptions
{
    [Serializable]
    public class MathException : Exception
    {
        public MathException(string functionName)
        {
            FunctionName = functionName;
        }

        public MathException(string functionName, string? message) : base(message)
        {
            FunctionName = functionName;
        }

        public MathException(string functionName, string? message, Exception? innerException) : base(message, innerException)
        {
            FunctionName = functionName;
        }

        public string FunctionName { get; }
    }

}