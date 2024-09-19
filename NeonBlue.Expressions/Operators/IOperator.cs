namespace NeonBlue.Expressions.Operators
{
    public interface IOperator
    {
        TokenType OperatorType { get; }

        public Token Run(Token operand1, Token operand2, IExecutionOptions executionOptions);
    }
}