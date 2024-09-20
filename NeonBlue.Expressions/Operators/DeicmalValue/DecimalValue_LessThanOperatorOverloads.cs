using NeonBlue.Expressions.Functions.BooleanFunctions;

namespace NeonBlue.Expressions.Operators.DeicmalValue
{
    public class DecimalValue_LessThanOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, DecimalLessThanInteger);
                overloads.Add(TokenType.Integer, DecimalLessThanInteger);
                overloads.Add(TokenType.Long, DecimalLessThanLong);
                overloads.Add(TokenType.Decimal, DecimalLessThanDecimal);
                overloads.Add(TokenType.Double, DecimalLessThanDouble);
                overloads.Add(TokenType.Float, DecimalLessThanFloat);
                overloads.Add(TokenType.NULL, DecimalLogicalOpNull);
            }
            return base.GetOverloads();
        }
        Token DecimalLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
        Token DecimalLessThanInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 < arg2, TokenType.Boolean);
        }
        Token DecimalLessThanLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 < arg2, TokenType.Boolean);
        }

        Token DecimalLessThanDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 < arg2, TokenType.Boolean);
        }

        Token DecimalLessThanDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 < (decimal)arg2, TokenType.Boolean);
        }

        Token DecimalLessThanFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 < (decimal)arg2, TokenType.Boolean);
        }


    }
}