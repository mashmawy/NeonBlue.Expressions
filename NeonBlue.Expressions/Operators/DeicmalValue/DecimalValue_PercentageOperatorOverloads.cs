using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.DeicmalValue
{
    public class DecimalValue_PercentageOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Integer, DecimalPercentageInteger);
                overloads.Add(TokenType.Byte, DecimalPercentageByte);
                overloads.Add(TokenType.Long, DecimalPercentageLong);
                overloads.Add(TokenType.Decimal, DecimalPercentageDecimal);
                overloads.Add(TokenType.Double, DecimalPercentageDouble);
                overloads.Add(TokenType.Float, DecimalPercentageFloat);
                overloads.Add(TokenType.NULL, DecimalMathNull);
            }
            return base.GetOverloads();
        }
        Token DecimalMathNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
        Token DecimalPercentageInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDecimal(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 % arg2, TokenType.Decimal);
        }
        Token DecimalPercentageByte(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDecimal(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 % arg2, TokenType.Decimal);
        }
        Token DecimalPercentageLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDecimal(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 % arg2, TokenType.Decimal);
        }
        Token DecimalPercentageDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDecimal(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 % arg2, TokenType.Decimal);
        }
        Token DecimalPercentageDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDecimal(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 % (decimal)arg2, TokenType.Decimal);
        }
        Token DecimalPercentageFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDecimal(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 % (decimal)arg2, TokenType.Decimal);
        }

    }
}