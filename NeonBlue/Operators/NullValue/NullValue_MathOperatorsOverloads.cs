using NeonBlue.Expressions;
using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.NullValue
{
    public class NullValue_MathOperatorsOverloads : OperatorsOverload
    {
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, NullMathNumeric);
                overloads.Add(TokenType.Integer, NullMathNumeric);
                overloads.Add(TokenType.Long, NullMathNumeric);
                overloads.Add(TokenType.Decimal, NullMathNumeric);
                overloads.Add(TokenType.Double, NullMathNumeric);
                overloads.Add(TokenType.Float, NullMathNumeric);
                overloads.Add(TokenType.NULL, NullMathNumeric);
            }
            return base.GetOverloads();
        }
        Token NullMathNumeric(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            if (executionOptions.NullStrategy == NullStrategy.Throw)
            {
                throw new NullTokenExecption(a1);
            }
            else
            {
                return new Token(null, TokenType.NULL);
            }
        }

    }
}