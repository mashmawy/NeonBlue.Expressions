namespace NeonBlue.Expressions
{
    [Serializable]
    public class VariableUndefinedExeception : Exception
    {
        public VariableUndefinedExeception(string variableName)
        {
            VariableName = variableName;
        }

        public VariableUndefinedExeception(string variableName, string? message) : base(message)
        {
            VariableName = variableName;
        }

        public VariableUndefinedExeception(string variableName, string? message, Exception? innerException) : base(message, innerException)
        {
            VariableName = variableName;
        }

        public string VariableName { get; }
    }
}


