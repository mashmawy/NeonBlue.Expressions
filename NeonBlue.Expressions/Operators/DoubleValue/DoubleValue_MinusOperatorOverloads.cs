using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.DoubleValue
{
    public class DoubleValue_MinusOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, DoubleMinusInteger);
                overloads.Add(TokenType.Integer, DoubleMinusInteger);
                overloads.Add(TokenType.Long, DoubleMinusLong);
                overloads.Add(TokenType.Decimal, DoubleMinusDecimal);
                overloads.Add(TokenType.Double, DoubleMinusDouble);
                overloads.Add(TokenType.Float, DoubleMinusFloat);
                overloads.Add(TokenType.NULL, DoubleMathNull);
            }
            return base.GetOverloads();
        }

        Token DoubleMathNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
        Token DoubleMinusInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDouble(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 - arg2, TokenType.Double);
        }

        Token DoubleMinusLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDouble(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 - arg2, TokenType.Double);
        }
        Token DoubleMinusDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDouble(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token((decimal)arg1 - arg2, TokenType.Decimal);
        }
        Token DoubleMinusDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDouble(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 - arg2, TokenType.Double);
        }
        Token DoubleMinusFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDouble(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 - arg2, TokenType.Double);
        }

    }
}