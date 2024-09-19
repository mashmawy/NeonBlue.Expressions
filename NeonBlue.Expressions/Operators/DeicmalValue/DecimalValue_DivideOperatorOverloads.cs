using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.DeicmalValue
{
    public class DecimalValue_DivideOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, DecimalDivideInteger);
                overloads.Add(TokenType.Integer, DecimalDivideInteger);
                overloads.Add(TokenType.Long, DecimalDivideLong);
                overloads.Add(TokenType.Decimal, DecimalDivideDecimal);
                overloads.Add(TokenType.Double, DecimalDivideDouble);
                overloads.Add(TokenType.Float, DecimalDivideFloat);
                overloads.Add(TokenType.NULL, DecimalMathNull);
            }
            return base.GetOverloads();
        }
        Token DecimalMathNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        Token DecimalDivideInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 / arg2, TokenType.Decimal);
        }



        Token DecimalDivideLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 / arg2, TokenType.Decimal);
        }

        Token DecimalDivideDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 / arg2, TokenType.Decimal);
        }

        Token DecimalDivideDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 / (decimal)arg2, TokenType.Decimal);
        }

        Token DecimalDivideFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 / (decimal)arg2, TokenType.Decimal);
        }


    }
}