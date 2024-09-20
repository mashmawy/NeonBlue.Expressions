using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Operators.IntegerValue
{
    public class IntegerValue_MinusOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Integer, IntegerMinusInteger);
                overloads.Add(TokenType.Byte, IntegerMinusInteger);
                overloads.Add(TokenType.Long, IntegerMinusLong);
                overloads.Add(TokenType.Decimal, IntegerMinusDecimal);
                overloads.Add(TokenType.Double, IntegerMinusDouble);
                overloads.Add(TokenType.Float, IntegerMinusFloat);
                overloads.Add(TokenType.NULL, IntegerMathNull);
            }
            return base.GetOverloads();
        }
        Token IntegerMathNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        Token IntegerMinusInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 - arg2, TokenType.Integer);
        }

        Token IntegerMinusLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 - arg2, TokenType.Long);
        }

        Token IntegerMinusDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 - arg2, TokenType.Decimal);
        }

        Token IntegerMinusDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 - arg2, TokenType.Double);
        }

        Token IntegerMinusFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 - arg2, TokenType.Float);
        }


    }
}