using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.BooleanFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.DatetimeValue
{
    public class DatetimeValue_GreaterThanOrEqualOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Datetime, DatetimeGreaterThanOrEqualDatetime);
                overloads.Add(TokenType.NULL, DatetimeLogicalOpNull);
            }
            return base.GetOverloads();
        }

        Token DatetimeLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);

        }
        Token DatetimeGreaterThanOrEqualDatetime(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDateTime(a1.Value);
            var arg2 = Convert.ToDateTime(a2.Value);
            var res = arg1 >= arg2;
            return new Token(res, TokenType.Boolean);
        }
    }
}