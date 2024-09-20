using NeonBlue.Expressions.Functions.BooleanFunctions;

namespace NeonBlue.Expressions.Operators.DoubleValue
{
    public class DoubleValue_LessThanOperatorOverloads : OperatorsOverload
    {
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, DoubleLessThanInteger);
                overloads.Add(TokenType.Integer, DoubleLessThanInteger);
                overloads.Add(TokenType.Long, DoubleLessThanLong);
                overloads.Add(TokenType.Decimal, DoubleLessThanDecimal);
                overloads.Add(TokenType.Double, DoubleLessThanDouble);
                overloads.Add(TokenType.Float, DoubleLessThanFloat);
                overloads.Add(TokenType.NULL, DoubleLogicalOpNull);
            }
            return base.GetOverloads();
        }
        Token DoubleLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }


        Token DoubleLessThanInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 < arg2, TokenType.Boolean);
        }

        Token DoubleLessThanLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 < arg2, TokenType.Boolean);
        }

        Token DoubleLessThanDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token((decimal)arg1 < arg2, TokenType.Boolean);
        }

        Token DoubleLessThanDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 < arg2, TokenType.Boolean);
        }

        Token DoubleLessThanFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 < arg2, TokenType.Boolean);
        }


    }
}