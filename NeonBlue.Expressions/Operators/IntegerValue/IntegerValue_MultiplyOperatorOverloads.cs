using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.IntegerValue
{
    public class IntegerValue_MultiplyOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, IntegerMultiplyInteger);
                overloads.Add(TokenType.Integer, IntegerMultiplyInteger);
                overloads.Add(TokenType.Long, IntegerMultiplyLong);
                overloads.Add(TokenType.Decimal, IntegerMultiplyDecimal);
                overloads.Add(TokenType.Double, IntegerMultiplyDouble);
                overloads.Add(TokenType.Float, IntegerMultiplyFloat);
                overloads.Add(TokenType.NULL, IntegerMathNull);
            }
            return base.GetOverloads();
        }
        Token IntegerMathNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        Token IntegerMultiplyInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 * arg2, TokenType.Integer);
        }
        Token IntegerMultiplyLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToInt32(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 * arg2, TokenType.Long);
        }
        Token IntegerMultiplyDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToInt32(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 * arg2, TokenType.Decimal);
        }
        Token IntegerMultiplyDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToInt32(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 * arg2, TokenType.Double);
        }
        Token IntegerMultiplyFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToInt32(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 * arg2, TokenType.Float);
        }

    }
}