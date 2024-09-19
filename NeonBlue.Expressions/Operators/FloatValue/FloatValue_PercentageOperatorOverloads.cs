using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.FloatValue
{
    public class FloatValue_PercentageOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Integer, FloatPercentageInteger);
                overloads.Add(TokenType.Byte, FloatPercentageByte);
                overloads.Add(TokenType.Long, FloatPercentageLong);
                overloads.Add(TokenType.Decimal, FloatPercentageDecimal);
                overloads.Add(TokenType.Double, FloatPercentageDouble);
                overloads.Add(TokenType.Float, FloatPercentageFloat);
                overloads.Add(TokenType.NULL, FloatMathNull);
            }
            return base.GetOverloads();
        }
        Token FloatMathNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        Token FloatPercentageInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToSingle(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 % arg2, TokenType.Float);
        }
        Token FloatPercentageByte(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToSingle(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 % arg2, TokenType.Float);
        }
        Token FloatPercentageLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToSingle(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 % arg2, TokenType.Float);
        }
        Token FloatPercentageDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToSingle(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token((decimal)arg1 % arg2, TokenType.Decimal);
        }
        Token FloatPercentageDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToSingle(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 % arg2, TokenType.Double);
        }
        Token FloatPercentageFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToSingle(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 % arg2, TokenType.Float);
        }

    }
}