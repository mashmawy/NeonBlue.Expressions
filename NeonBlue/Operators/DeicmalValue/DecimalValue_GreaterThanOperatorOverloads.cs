using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.BooleanFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.DeicmalValue
{
    public class DecimalValue_GreaterThanOperatorOverloads : OperatorsOverload
    {
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, DecimalGreaterThanInteger);
                overloads.Add(TokenType.Integer, DecimalGreaterThanInteger);
                overloads.Add(TokenType.Long, DecimalGreaterThanLong);
                overloads.Add(TokenType.Decimal, DecimalGreaterThanDecimal);
                overloads.Add(TokenType.Double, DecimalGreaterThanDouble);
                overloads.Add(TokenType.Float, DecimalGreaterThanFloat);
                overloads.Add(TokenType.NULL, DecimalLogicalOpNull);
            }
            return base.GetOverloads();
        }
        Token DecimalLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
        Token DecimalGreaterThanInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 > arg2, TokenType.Boolean);
        }
        Token DecimalGreaterThanLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 > arg2, TokenType.Boolean);
        }

        Token DecimalGreaterThanDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 > arg2, TokenType.Boolean);
        }

        Token DecimalGreaterThanDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 > (decimal)arg2, TokenType.Boolean);
        }




        Token DecimalGreaterThanFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 > (decimal)arg2, TokenType.Boolean);
        }


    }
}