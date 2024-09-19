namespace NeonBlue.Expressions
{
    [Serializable]
    public class AggregateFunctionException : Exception
    {
        public AggregateFunctionException()
        {
        }

        public AggregateFunctionException(string? message) : base(message)
        {
        }

        public AggregateFunctionException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}