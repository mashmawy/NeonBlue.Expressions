using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.BooleanFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.DoubleValue
{
    public class DoubleValue_NotEqualOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, DoubleNotEqualInteger);
                overloads.Add(TokenType.Integer, DoubleNotEqualInteger);
                overloads.Add(TokenType.Long, DoubleNotEqualLong);
                overloads.Add(TokenType.Decimal, DoubleNotEqualDecimal);
                overloads.Add(TokenType.Double, DoubleNotEqualDouble);
                overloads.Add(TokenType.Float, DoubleNotEqualFloat);
                overloads.Add(TokenType.NULL, DoubleLogicalOpNull);
            }
            return base.GetOverloads();
        }
        Token DoubleLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        Token DoubleNotEqualInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 != arg2, TokenType.Boolean);
        }

        Token DoubleNotEqualLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 != arg2, TokenType.Boolean);
        }

        Token DoubleNotEqualDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token((decimal)arg1 != arg2, TokenType.Boolean);
        }

        Token DoubleNotEqualDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 != arg2, TokenType.Boolean);
        }

        Token DoubleNotEqualFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 != arg2, TokenType.Boolean);
        }


    }
}