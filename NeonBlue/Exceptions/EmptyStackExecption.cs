namespace NeonBlue.Expressions.Exceptions
{
    [Serializable]
    public class EmptyStackExecption : Exception
    {
        public EmptyStackExecption()
        {
        }

        public EmptyStackExecption( string? message) : base(message)
        {
        }

        public EmptyStackExecption(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }

}