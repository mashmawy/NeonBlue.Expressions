using NeonBlue.Expressions.Functions.BooleanFunctions;

namespace NeonBlue.Expressions.Operators.ByteValue
{
    public class ByteValue_GreaterThanOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, ByteGreaterThanInteger);
                overloads.Add(TokenType.Integer, ByteGreaterThanInteger);
                overloads.Add(TokenType.Long, ByteGreaterThanLong);
                overloads.Add(TokenType.Decimal, ByteGreaterThanDecimal);
                overloads.Add(TokenType.Double, ByteGreaterThanDouble);
                overloads.Add(TokenType.Float, ByteGreaterThanFloat);

                overloads.Add(TokenType.NULL, ByteGreaterThanNull);


            }
            return base.GetOverloads();
        }

        Token ByteGreaterThanInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 > arg2, TokenType.Boolean);
        }

        Token ByteGreaterThanLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 > arg2, TokenType.Boolean);
        }

        Token ByteGreaterThanDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            var arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 > arg2, TokenType.Boolean);
        }

        Token ByteGreaterThanDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 > arg2, TokenType.Boolean);
        }
        Token ByteGreaterThanFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 > arg2, TokenType.Boolean);
        }

        Token ByteGreaterThanNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);


        }

    }
}