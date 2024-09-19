using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.BooleanFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.ByteValue
{
    public class ByteValue_GreaterThanOrEqualOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, ByteGreaterThanOrEqualInteger);
                overloads.Add(TokenType.Integer, ByteGreaterThanOrEqualInteger);
                overloads.Add(TokenType.Long, ByteGreaterThanOrEqualLong);
                overloads.Add(TokenType.Decimal, ByteGreaterThanOrEqualDecimal);
                overloads.Add(TokenType.Double, ByteGreaterThanOrEqualDouble);
                overloads.Add(TokenType.Float, ByteGreaterThanOrEqualFloat);

                overloads.Add(TokenType.NULL, ByteGreaterThanOrEqualNull);


            }
            return base.GetOverloads();
        }

        Token ByteGreaterThanOrEqualInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }

        Token ByteGreaterThanOrEqualLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }

        Token ByteGreaterThanOrEqualDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            var arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }

        Token ByteGreaterThanOrEqualDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }
        Token ByteGreaterThanOrEqualFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }

        Token ByteGreaterThanOrEqualNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);


        }

    }
}