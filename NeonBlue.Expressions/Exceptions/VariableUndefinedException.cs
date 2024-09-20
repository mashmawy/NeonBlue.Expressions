namespace NeonBlue.Expressions
{
    [Serializable]
    public class VariableUndefinedException : Exception
    {
        public VariableUndefinedException(string variableName)
        {
            VariableName = variableName;
        }

        public VariableUndefinedException(string variableName, string? message) : base(message)
        {
            VariableName = variableName;
        }

        public VariableUndefinedException(string variableName, string? message, Exception? innerException) : base(message, innerException)
        {
            VariableName = variableName;
        }

        public string VariableName { get; }
    }
}


