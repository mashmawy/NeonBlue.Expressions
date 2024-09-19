using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.DeicmalValue
{
    public class DecimalValue_MultiplyOperatorOverloads : OperatorsOverload
    {
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, DeciamlMultiplyInteger);
                overloads.Add(TokenType.Integer, DeciamlMultiplyByte);
                overloads.Add(TokenType.Long, DeciamlMultiplyLong);
                overloads.Add(TokenType.Decimal, DeciamlMultiplyDecimal);
                overloads.Add(TokenType.Double, DeciamlMultiplyDouble);
                overloads.Add(TokenType.Float, DeciamlMultiplyFloat);
                overloads.Add(TokenType.NULL, DecimalMathNull);
            }
            return overloads;
        }
        Token DecimalMathNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
        Token DeciamlMultiplyInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDecimal(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 * arg2, TokenType.Decimal);
        }
        Token DeciamlMultiplyByte(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDecimal(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 * arg2, TokenType.Decimal);
        }
        Token DeciamlMultiplyLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDecimal(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 * arg2, TokenType.Decimal);
        }
        Token DeciamlMultiplyDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDecimal(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 * arg2, TokenType.Decimal);
        }
        Token DeciamlMultiplyDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDecimal(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 * (decimal)arg2, TokenType.Decimal);
        }
        Token DeciamlMultiplyFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDecimal(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 * (decimal)arg2, TokenType.Decimal);
        }

    }
}