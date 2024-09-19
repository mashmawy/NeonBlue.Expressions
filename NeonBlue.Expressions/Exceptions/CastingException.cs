namespace NeonBlue.Expressions
{
    [Serializable]
    public class CastingException : Exception
    {
        public CastingException()
        {
        }

        public CastingException(string? message) : base(message)
        {
        }

        public CastingException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}


