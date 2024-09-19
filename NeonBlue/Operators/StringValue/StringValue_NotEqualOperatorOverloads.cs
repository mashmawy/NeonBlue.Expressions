using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.BooleanFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.StringValue
{
    public class StringValue_NotEqualOperatorOverloads : OperatorsOverload
    {
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.String, StringNotEqualString);
                overloads.Add(TokenType.NULL, StringLogicalOpNull);
            }
            return base.GetOverloads();
        }
        Token StringLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        Token StringNotEqualString(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = a1.Value as string;
            var arg2 = Convert.ToString(a2.Value);
            var res = arg1 != arg2;
            return new Token(res, TokenType.Boolean);
        }


    }
}