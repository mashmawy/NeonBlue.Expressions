using NeonBlue.Expressions;

namespace NeonBlue.Expressions.Operators
{
    public class LogicalAndOperatorOverloads : IOperator
    {
        public TokenType OperatorType { get; } = TokenType.LessThanOrEqual;

        public LogicalAndOperatorOverloads()
        {
        }



        public Token Run(Token operand1, Token operand2, IExecutionOptions executionOptions)
        {
            var arg1Token = Convert.ToBoolean(operand1.Value);

            var arg2Token = Convert.ToBoolean(operand2.Value);
            return new Token(arg1Token && arg2Token, TokenType.Boolean);

        }

    }
}