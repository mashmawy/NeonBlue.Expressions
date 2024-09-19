using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.DeicmalValue
{
    public class DecimalValue_PlusOperatorOverloads : OperatorsOverload
    {
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, DecimalPlusInteger);
                overloads.Add(TokenType.Integer, DecimalPlusInteger);
                overloads.Add(TokenType.Long, DecimalPlusLong);
                overloads.Add(TokenType.Decimal, DecimalPlusDecimal);
                overloads.Add(TokenType.Double, DecimalPlusDouble);
                overloads.Add(TokenType.Float, DecimalPlusFloat);
                overloads.Add(TokenType.String, DecimalPlusString);
                overloads.Add(TokenType.NULL, DecimalMathNull);
            }
            return base.GetOverloads();
        }
        Token DecimalMathNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        Token DecimalPlusInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 + arg2, TokenType.Decimal);
        }

        Token DecimalPlusLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 + arg2, TokenType.Decimal);
        }
        Token DecimalPlusDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            var arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 + arg2, TokenType.Decimal);
        }

        Token DecimalPlusDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 + (decimal)arg2, TokenType.Decimal);
        }

        Token DecimalPlusFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 + (decimal)arg2, TokenType.Decimal);
        }


        Token DecimalPlusString(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            var arg2 = Convert.ToString(a2.Value);
            return new Token((arg1 + arg2).ToString(), TokenType.String);
        }


    }
}