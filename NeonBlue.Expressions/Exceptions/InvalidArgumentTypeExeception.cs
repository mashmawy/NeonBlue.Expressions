namespace NeonBlue.Expressions
{
    [Serializable]
    public class InvalidArgumentTypeExeception : Exception
    {
        public string Function { get; }
        public Type Type { get; }



        public InvalidArgumentTypeExeception(string function, Type type, string? message) : base(message)
        {
            Function = function;
            Type = type;
        }

        public InvalidArgumentTypeExeception(string function, Type type)
        {
            Function = function;
            Type = type;

        }

        public InvalidArgumentTypeExeception(string function, Type type, string? message, Exception? innerException) : base(message, innerException)
        {
            Function = function;
            Type = type;
        }
    }
}


