namespace NeonBlue.Expressions
{
    public interface IExpressionContext
    {
        Token GetValueToken(string name);
        TokenType GetVariableType(string name);
        object? GetVariableValue(string name);
        bool HasVariable(string name);
        void SetVariable(string name, object? value);
    }
}