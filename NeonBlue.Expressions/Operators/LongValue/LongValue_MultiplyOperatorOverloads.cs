using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Operators.LongValue
{
    public class LongValue_MultiplyOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, LongMultiplyInteger);
                overloads.Add(TokenType.Integer, LongMultiplyByte);
                overloads.Add(TokenType.Long, LongMultiplyLong);
                overloads.Add(TokenType.Decimal, LongMultiplyDecimal);
                overloads.Add(TokenType.Double, LongMultiplyDouble);
                overloads.Add(TokenType.Float, LongMultiplyFloat);
                overloads.Add(TokenType.NULL, LongMathNull);
            }
            return base.GetOverloads();
        }
        Token LongMathNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
        Token LongMultiplyInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToInt64(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 * arg2, TokenType.Long);
        }
        Token LongMultiplyByte(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToInt64(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 * arg2, TokenType.Long);
        }
        Token LongMultiplyLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToInt64(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 * arg2, TokenType.Long);
        }
        Token LongMultiplyDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToInt64(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 * arg2, TokenType.Decimal);
        }
        Token LongMultiplyDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToInt64(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 * arg2, TokenType.Double);
        }
        Token LongMultiplyFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToInt64(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 * arg2, TokenType.Float);
        }
    }
}