using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Operators.LongValue
{
    public class LongValue_DivideOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, LongDivideInteger);
                overloads.Add(TokenType.Integer, LongDivideInteger);
                overloads.Add(TokenType.Long, LongDivideLong);
                overloads.Add(TokenType.Decimal, LongDivideDecimal);
                overloads.Add(TokenType.Double, LongDivideDouble);
                overloads.Add(TokenType.Float, LongDivideFloat);
                overloads.Add(TokenType.NULL, LongMathNull);
            }
            return base.GetOverloads();
        }

        Token LongMathNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
        Token LongDivideInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 / arg2, TokenType.Long);
        }

        Token LongDivideLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 / arg2, TokenType.Long);
        }


        Token LongDivideDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 / arg2, TokenType.Decimal);
        }

        Token LongDivideDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 / arg2, TokenType.Double);
        }


        Token LongDivideFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 / arg2, TokenType.Float);
        }


    }
}