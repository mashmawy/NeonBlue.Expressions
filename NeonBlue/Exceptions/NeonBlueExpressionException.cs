namespace NeonBlue.Expressions.Exceptions
{
    [Serializable]
    public class NeonBlueExpressionException : Exception
    {
        public NeonBlueExpressionException()
        {
        }

        public NeonBlueExpressionException(string? message) : base(message)
        {
        }

        public NeonBlueExpressionException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}