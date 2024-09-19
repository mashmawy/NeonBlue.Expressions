namespace NeonBlue.Expressions.Exceptions
{
    [Serializable]
    public class StringException : Exception
    {
        public StringException(string functionName)
        {
            FunctionName = functionName;
        }

        public StringException(string functionName, string? message) : base(message)
        {
            FunctionName = functionName;
        }

        public StringException(string functionName, string? message, Exception? innerException) : base(message, innerException)
        {
            FunctionName = functionName;
        }

        public string FunctionName { get; }
    }

}