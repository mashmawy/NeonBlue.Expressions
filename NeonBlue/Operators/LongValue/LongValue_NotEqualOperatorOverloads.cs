using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.BooleanFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.LongValue
{
    public class LongValue_NotEqualOperatorOverloads : OperatorsOverload
    {
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, LongNotEqualInteger);
                overloads.Add(TokenType.Integer, LongNotEqualInteger);
                overloads.Add(TokenType.Long, LongNotEqualLong);
                overloads.Add(TokenType.Decimal, LongNotEqualDecimal);
                overloads.Add(TokenType.Double, LongNotEqualDouble);
                overloads.Add(TokenType.Float, LongNotEqualFloat);
                overloads.Add(TokenType.NULL, LongLogicalOpNull);
            }
            return base.GetOverloads();
        }
        Token LongLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
        Token LongNotEqualInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 != arg2, TokenType.Boolean);
        }

        Token LongNotEqualLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 != arg2, TokenType.Boolean);
        }


        Token LongNotEqualDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 != arg2, TokenType.Boolean);
        }

        Token LongNotEqualDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 != arg2, TokenType.Boolean);
        }


        Token LongNotEqualFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 != arg2, TokenType.Boolean);
        }


    }
}