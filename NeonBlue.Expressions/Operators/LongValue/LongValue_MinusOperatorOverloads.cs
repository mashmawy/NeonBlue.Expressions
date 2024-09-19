using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.LongValue
{
    public class LongValue_MinusOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, LongMinusInteger);
                overloads.Add(TokenType.Integer, LongMinusInteger);
                overloads.Add(TokenType.Long, LongMinusLong);
                overloads.Add(TokenType.Decimal, LongMinusDecimal);
                overloads.Add(TokenType.Double, LongMinusDouble);
                overloads.Add(TokenType.Float, LongMinusFloat);
                overloads.Add(TokenType.NULL, LongMathNull);
            }
            return base.GetOverloads();
        }

        Token LongMathNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
        Token LongMinusInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 - arg2, TokenType.Long);
        }

        Token LongMinusLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            var arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 - arg2, TokenType.Long);
        }

        Token LongMinusDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            var arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 - arg2, TokenType.Decimal);
        }
        Token LongMinusDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 - arg2, TokenType.Double);
        }

        Token LongMinusFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 - arg2, TokenType.Float);
        }

    }
}