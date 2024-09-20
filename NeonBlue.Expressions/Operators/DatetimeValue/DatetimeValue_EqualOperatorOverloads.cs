using NeonBlue.Expressions.Functions.BooleanFunctions;

namespace NeonBlue.Expressions.Operators.DatetimeValue
{
    public class DatetimeValue_EqualOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Datetime, DatetimeEqualDatetime);
                overloads.Add(TokenType.NULL, DatetimeEqualNull);
            }
            return base.GetOverloads();
        }

        Token DatetimeEqualNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);

        }
        Token DatetimeEqualDatetime(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDateTime(a1.Value);
            var arg2 = Convert.ToDateTime(a2.Value);
            var res = arg1 == arg2;
            return new Token(res, TokenType.Boolean);
        }


    }
}