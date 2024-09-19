using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.BooleanFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.IntegerValue
{
    public class IntegerValue_LessThanOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, IntegerLessThanInteger);
                overloads.Add(TokenType.Integer, IntegerLessThanInteger);
                overloads.Add(TokenType.Long, IntegerLessThanLong);
                overloads.Add(TokenType.Double, IntegerLessThanDouble);
                overloads.Add(TokenType.Decimal, IntegerLessThanDecimal);
                overloads.Add(TokenType.Float, IntegerLessThanFloat);
                overloads.Add(TokenType.NULL, IntegerLogicalOpNull);
            }
            return base.GetOverloads();
        }
        Token IntegerLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
        Token IntegerLessThanInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 < arg2, TokenType.Boolean);
        }


        Token IntegerLessThanLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 < arg2, TokenType.Boolean);
        }


        Token IntegerLessThanDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            double arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 < arg2, TokenType.Boolean);
        }
        Token IntegerLessThanDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 < arg2, TokenType.Boolean);
        }
        Token IntegerLessThanFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 < arg2, TokenType.Boolean);
        }

    }

}