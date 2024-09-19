using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators;
using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Operators.ByteValue
{
    public class ByteValue_DivideOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, ByteDivideInteger);
                overloads.Add(TokenType.Integer, ByteDivideInteger);
                overloads.Add(TokenType.Long, ByteDivideLong);
                overloads.Add(TokenType.Decimal, ByteDivideDecimal);
                overloads.Add(TokenType.Double, ByteDivideDouble);
                overloads.Add(TokenType.Float, ByteDivideFloat);
                overloads.Add(TokenType.NULL, ByteDivideNull);


            }
            return base.GetOverloads();
        }
        Token ByteDivideInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 / arg2, TokenType.Integer);
        }
        Token ByteDivideLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 / arg2, TokenType.Long);
        }
        Token ByteDivideDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 / arg2, TokenType.Decimal);
        }

        Token ByteDivideDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 / arg2, TokenType.Double);
        }

        Token ByteDivideFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 / arg2, TokenType.Float);
        }

        Token ByteDivideNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

    }
}