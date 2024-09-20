using NeonBlue.Expressions.Functions.BooleanFunctions;

namespace NeonBlue.Expressions.Operators.DatetimeValue
{
    public class DatetimeValue_LessThanOrEqualOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Datetime, DatetimeLessThanOrEqualDatetime);
                overloads.Add(TokenType.NULL, DatetimeLogicalOpNull);
            }
            return overloads;
        }
        Token DatetimeLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);

        }

        Token DatetimeLessThanOrEqualDatetime(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDateTime(a1.Value);
            var arg2 = Convert.ToDateTime(a2.Value);
            var res = arg1 <= arg2;
            return new Token(res, TokenType.Boolean);
        }

    }
}