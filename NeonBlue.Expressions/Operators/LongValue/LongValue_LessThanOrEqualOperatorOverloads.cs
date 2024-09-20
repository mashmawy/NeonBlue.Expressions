using NeonBlue.Expressions.Functions.BooleanFunctions;

namespace NeonBlue.Expressions.Operators.LongValue
{
    public class LongValue_LessThanOrEqualOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, LongLessThanOrEqualInteger);
                overloads.Add(TokenType.Integer, LongLessThanOrEqualInteger);
                overloads.Add(TokenType.Long, LongLessThanOrEqualLong);
                overloads.Add(TokenType.Decimal, LongLessThanOrEqualDecimal);
                overloads.Add(TokenType.Double, LongLessThanOrEqualDouble);
                overloads.Add(TokenType.Float, LongLessThanOrEqualFloat);
                overloads.Add(TokenType.NULL, LongLogicalOpNull);
            }
            return base.GetOverloads();
        }
        Token LongLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
        Token LongLessThanOrEqualInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 <= arg2, TokenType.Boolean);
        }

        Token LongLessThanOrEqualLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 <= arg2, TokenType.Boolean);
        }


        Token LongLessThanOrEqualDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 <= arg2, TokenType.Boolean);
        }

        Token LongLessThanOrEqualDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 <= arg2, TokenType.Boolean);
        }


        Token LongLessThanOrEqualFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 <= arg2, TokenType.Boolean);
        }


    }
}