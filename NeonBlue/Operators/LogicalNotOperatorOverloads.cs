using NeonBlue.Expressions;

namespace NeonBlue.Expressions.Operators
{
    public class LogicalNotOperatorOverloads : IOperator
    {
        public TokenType OperatorType { get; } = TokenType.LessThanOrEqual;

        public LogicalNotOperatorOverloads()
        {
        }



        public Token Run(Token operand1, Token? operand2, IExecutionOptions executionOptions)
        {
            var arg1Token = Convert.ToBoolean(operand1.Value);

            return new Token(!arg1Token, TokenType.Boolean);

        }

    }
}