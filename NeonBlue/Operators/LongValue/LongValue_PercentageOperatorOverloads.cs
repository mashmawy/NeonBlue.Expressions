using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.LongValue
{
    public class LongValue_PercentageOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Integer, LongPercentageInteger);
                overloads.Add(TokenType.Byte, LongPercentageByte);
                overloads.Add(TokenType.Long, LongPercentageLong);
                overloads.Add(TokenType.Decimal, LongPercentageDecimal);
                overloads.Add(TokenType.Double, LongPercentageDouble);
                overloads.Add(TokenType.Float, LongPercentageFloat);
                overloads.Add(TokenType.NULL, LongMathNull);
            }
            return base.GetOverloads();
        }
        Token LongMathNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
        Token LongPercentageInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToInt64(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 % arg2, TokenType.Long);
        }
        Token LongPercentageByte(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToInt64(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 % arg2, TokenType.Long);
        }
        Token LongPercentageLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToInt64(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 % arg2, TokenType.Long);
        }
        Token LongPercentageDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToInt64(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 % arg2, TokenType.Decimal);
        }
        Token LongPercentageDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToInt64(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 % arg2, TokenType.Double);
        }
        Token LongPercentageFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToInt64(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 % arg2, TokenType.Float);
        }


    }
}