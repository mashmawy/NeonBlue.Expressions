using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.ByteValue
{
    public class ByteValue_PlusOperatorOverloads : OperatorsOverload
    {
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, BytePlusByte);
                overloads.Add(TokenType.Integer, BytePlusInteger);
                overloads.Add(TokenType.Long, BytePlusLong);
                overloads.Add(TokenType.Decimal, BytePlusDecimal);
                overloads.Add(TokenType.Double, BytePlusDouble);
                overloads.Add(TokenType.Float, BytePlusFloat);
                overloads.Add(TokenType.String, BytePlusString);
                overloads.Add(TokenType.NULL, BytePlusNull);
            }
            return overloads;
        }

        Token BytePlusNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
        Token BytePlusByte(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 + arg2, TokenType.Integer);
        }
        Token BytePlusInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 + arg2, TokenType.Integer);
        }

        Token BytePlusLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 + arg2, TokenType.Long);
        }

        Token BytePlusDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 + arg2, TokenType.Decimal);
        }

        Token BytePlusDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 + arg2, TokenType.Double);
        }

        Token BytePlusFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 + arg2, TokenType.Float);
        }

        Token BytePlusString(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            var arg2 = Convert.ToString(a2.Value);
            return new Token((arg1 + arg2).ToString(), TokenType.String);
        }

    }
}