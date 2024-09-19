using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.BooleanFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.DeicmalValue
{
    public class DecimalValue_NotEqualOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, DecimalNotEqualInteger);
                overloads.Add(TokenType.Integer, DecimalNotEqualInteger);
                overloads.Add(TokenType.Long, DecimalNotEqualLong);
                overloads.Add(TokenType.Decimal, DecimalNotEqualDecimal);
                overloads.Add(TokenType.Double, DecimalNotEqualDouble);
                overloads.Add(TokenType.Float, DecimalNotEqualFloat);
                overloads.Add(TokenType.NULL, DecimalLogicalOpNull);
            }
            return base.GetOverloads();
        }
        Token DecimalLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
        Token DecimalNotEqualInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 != arg2, TokenType.Boolean);
        }
        Token DecimalNotEqualLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 != arg2, TokenType.Boolean);
        }

        Token DecimalNotEqualDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 != arg2, TokenType.Boolean);
        }

        Token DecimalNotEqualDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 != (decimal)arg2, TokenType.Boolean);
        }




        Token DecimalNotEqualFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 != (decimal)arg2, TokenType.Boolean);
        }




    }
}