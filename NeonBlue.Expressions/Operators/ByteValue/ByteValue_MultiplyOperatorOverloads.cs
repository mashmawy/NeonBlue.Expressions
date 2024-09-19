using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.ByteValue
{
    public class ByteValue_MultiplyOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, ByteMultiplyInteger);
                overloads.Add(TokenType.Integer, ByteMultiplyInteger);
                overloads.Add(TokenType.Long, ByteMultiplyLong);
                overloads.Add(TokenType.Decimal, ByteMultiplyDecimal);
                overloads.Add(TokenType.Double, ByteMultiplyDouble);
                overloads.Add(TokenType.Float, ByteMultiplyFloat);
                overloads.Add(TokenType.NULL, ByteMultiplyNull);
            }
            return base.GetOverloads();
        }
        Token ByteMultiplyNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
        Token ByteMultiplyInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToByte(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 * arg2, TokenType.Integer);
        }

        Token ByteMultiplyLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToByte(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 * arg2, TokenType.Long);
        }
        Token ByteMultiplyDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToByte(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 * arg2, TokenType.Decimal);
        }
        Token ByteMultiplyDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToByte(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 * arg2, TokenType.Double);
        }
        Token ByteMultiplyFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToByte(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 * arg2, TokenType.Float);
        }
    }
}