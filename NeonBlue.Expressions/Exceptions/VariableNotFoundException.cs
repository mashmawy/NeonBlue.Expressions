namespace NeonBlue.Expressions
{
    [Serializable]
    public class VariableNotFoundException : Exception
    {
        public VariableNotFoundException()
        {
        }

        public VariableNotFoundException(string? message) : base(message)
        {
        }

        public VariableNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }

}