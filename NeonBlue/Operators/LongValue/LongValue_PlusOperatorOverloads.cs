using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.LongValue
{
    public class LongValue_PlusOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, LongPlusInteger);
                overloads.Add(TokenType.Integer, LongPlusInteger);
                overloads.Add(TokenType.Long, LongPlusLong);
                overloads.Add(TokenType.Decimal, LongPlusDecimal);
                overloads.Add(TokenType.Double, LongPlusDouble);
                overloads.Add(TokenType.Float, LongPlusFloat);
                overloads.Add(TokenType.String, LongPlusString);
                overloads.Add(TokenType.NULL, LongMathNull);
            }
            return base.GetOverloads();
        }
        Token LongMathNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        Token LongPlusInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 + arg2, TokenType.Long);
        }

        Token LongPlusLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            var arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 + arg2, TokenType.Long);
        }

        Token LongPlusDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            var arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 + arg2, TokenType.Decimal);
        }
        Token LongPlusDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 + arg2, TokenType.Double);
        }

        Token LongPlusFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 + arg2, TokenType.Float);
        }

        Token LongPlusString(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            var arg2 = Convert.ToString(a2.Value);
            return new Token((arg1 + arg2).ToString(), TokenType.String);
        }

    }
}