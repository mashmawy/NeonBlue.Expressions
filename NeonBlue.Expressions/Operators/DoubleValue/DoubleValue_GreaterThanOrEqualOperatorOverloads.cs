using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.BooleanFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.DoubleValue
{
    public class DoubleValue_GreaterThanOrEqualOperatorOverloads : OperatorsOverload
    {
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, DoubleGreaterThanOrEqualInteger);
                overloads.Add(TokenType.Integer, DoubleGreaterThanOrEqualInteger);
                overloads.Add(TokenType.Long, DoubleGreaterThanOrEqualLong);
                overloads.Add(TokenType.Decimal, DoubleGreaterThanOrEqualDecimal);
                overloads.Add(TokenType.Double, DoubleGreaterThanOrEqualDouble);
                overloads.Add(TokenType.Float, DoubleGreaterThanOrEqualFloat);
                overloads.Add(TokenType.NULL, DoubleLogicalOpNull);
            }
            return base.GetOverloads();
        }
        Token DoubleLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        Token DoubleGreaterThanOrEqualInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 != arg2, TokenType.Boolean);
        }

        Token DoubleGreaterThanOrEqualLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 != arg2, TokenType.Boolean);
        }

        Token DoubleGreaterThanOrEqualDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token((decimal)arg1 != arg2, TokenType.Boolean);
        }

        Token DoubleGreaterThanOrEqualDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 != arg2, TokenType.Boolean);
        }

        Token DoubleGreaterThanOrEqualFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 != arg2, TokenType.Boolean);
        }


    }
}