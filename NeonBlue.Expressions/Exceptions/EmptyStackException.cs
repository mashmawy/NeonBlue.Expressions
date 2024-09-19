namespace NeonBlue.Expressions
{
    [Serializable]
    public class EmptyStackException : Exception
    {
        public EmptyStackException()
        {
        }

        public EmptyStackException( string? message) : base(message)
        {
        }

        public EmptyStackException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }

}