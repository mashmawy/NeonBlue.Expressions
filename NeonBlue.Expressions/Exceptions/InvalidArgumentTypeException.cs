namespace NeonBlue.Expressions
{
    [Serializable]
    public class InvalidArgumentTypeException : Exception
    {
        public string Function { get; }
        public Type Type { get; }



        public InvalidArgumentTypeException(string function, Type type, string? message) : base(message)
        {
            Function = function;
            Type = type;
        }

        public InvalidArgumentTypeException(string function, Type type)
        {
            Function = function;
            Type = type;

        }

        public InvalidArgumentTypeException(string function, Type type, string? message, Exception? innerException) : base(message, innerException)
        {
            Function = function;
            Type = type;
        }
    }
}


