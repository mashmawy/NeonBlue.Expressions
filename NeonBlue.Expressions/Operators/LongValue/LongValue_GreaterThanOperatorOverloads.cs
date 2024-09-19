using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.BooleanFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.LongValue
{
    public class LongValue_GreaterThanOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, LongGreaterThanInteger);
                overloads.Add(TokenType.Integer, LongGreaterThanInteger);
                overloads.Add(TokenType.Long, LongGreaterThanLong);
                overloads.Add(TokenType.Decimal, LongGreaterThanDecimal);
                overloads.Add(TokenType.Double, LongGreaterThanDouble);
                overloads.Add(TokenType.Float, LongGreaterThanFloat);
                overloads.Add(TokenType.NULL, LongLogicalOpNull);
            }
            return base.GetOverloads();
        }
        Token LongLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
        Token LongGreaterThanInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 > arg2, TokenType.Boolean);
        }

        Token LongGreaterThanLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 > arg2, TokenType.Boolean);
        }


        Token LongGreaterThanDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 > arg2, TokenType.Boolean);
        }

        Token LongGreaterThanDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 > arg2, TokenType.Boolean);
        }


        Token LongGreaterThanFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 > arg2, TokenType.Boolean);
        }

    }
}