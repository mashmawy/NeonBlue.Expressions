using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.BooleanFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.DoubleValue
{
    public class DoubleValue_EqualOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, DoubleEqualInteger);
                overloads.Add(TokenType.Integer, DoubleEqualInteger);
                overloads.Add(TokenType.Long, DoubleEqualLong);
                overloads.Add(TokenType.Decimal, DoubleEqualDecimal);
                overloads.Add(TokenType.Double, DoubleEqualDouble);
                overloads.Add(TokenType.Float, DoubleEqualFloat);
                overloads.Add(TokenType.NULL, DoubleLogicalOpNull);
            }
            return base.GetOverloads();
        }
        Token DoubleLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        Token DoubleEqualInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 == arg2, TokenType.Boolean);
        }

        Token DoubleEqualLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 == arg2, TokenType.Boolean);
        }

        Token DoubleEqualDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token((decimal)arg1 == arg2, TokenType.Boolean);
        }

        Token DoubleEqualDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 == arg2, TokenType.Boolean);
        }

        Token DoubleEqualFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 == arg2, TokenType.Boolean);
        }


    }
}