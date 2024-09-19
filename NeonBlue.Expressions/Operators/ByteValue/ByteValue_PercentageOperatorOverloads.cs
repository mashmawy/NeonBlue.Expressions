using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.ByteValue
{
    public class ByteValue_PercentageOperatorOverloads : OperatorsOverload
    {
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Integer, BytePercentageInteger);
                overloads.Add(TokenType.Byte, BytePercentageByte);
                overloads.Add(TokenType.Long, BytePercentageLong);
                overloads.Add(TokenType.Decimal, BytePercentageDecimal);
                overloads.Add(TokenType.Double, BytePercentageDouble);
                overloads.Add(TokenType.Float, BytePercentageFloat);
                overloads.Add(TokenType.NULL, BytePercentageNull);
            }
            return base.GetOverloads();
        }
        Token BytePercentageNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
        Token BytePercentageInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToByte(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 % arg2, TokenType.Integer);
        }
        Token BytePercentageByte(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToByte(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 % arg2, TokenType.Integer);
        }
        Token BytePercentageLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToByte(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 % arg2, TokenType.Long);
        }
        Token BytePercentageDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToByte(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 % arg2, TokenType.Decimal);
        }
        Token BytePercentageDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToByte(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 % arg2, TokenType.Double);
        }
        Token BytePercentageFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToByte(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 % arg2, TokenType.Float);
        }

    }
}