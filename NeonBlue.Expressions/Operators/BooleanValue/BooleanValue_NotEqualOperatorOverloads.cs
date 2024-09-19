using NeonBlue.Expressions;
using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.BooleanValue
{
    public class BooleanValue_NotEqualOperatorOverloads : OperatorsOverload
    {
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Boolean, BooleanNotEqualBoolean);
                overloads.Add(TokenType.NULL, BooleanNotEqualNull);
            }
            return base.GetOverloads();
        }

        Token BooleanNotEqualNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            if (executionOptions.NullStrategy == NullStrategy.Default)
            {
                return a1;
            }
            else if (executionOptions.NullStrategy == NullStrategy.Propagate)
            {
                return new Token(null, TokenType.NULL);
            }
            else
            {
                throw new NullTokenExecption(a2);
            }
        }
        Token BooleanNotEqualBoolean(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToBoolean(a1.Value);
            var arg2 = Convert.ToBoolean(a2.Value);
            var res = arg1 != arg2;

            return new Token(res, TokenType.Boolean);
        }

    }
}