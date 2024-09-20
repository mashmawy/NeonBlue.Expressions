using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Operators.FloatValue
{
    public class FloatValue_DivideOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, FloatDivideInteger);
                overloads.Add(TokenType.Integer, FloatDivideInteger);
                overloads.Add(TokenType.Long, FloatDivideLong);
                overloads.Add(TokenType.Decimal, FloatDivideDecimal);
                overloads.Add(TokenType.Double, FloatDivideDouble);
                overloads.Add(TokenType.Float, FloatDivideFloat);
                overloads.Add(TokenType.NULL, FloatMathNull);
            }
            return base.GetOverloads();
        }
        Token FloatMathNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
        Token FloatDivideInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToSingle(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 / arg2, TokenType.Float);
        }
        Token FloatDivideLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToSingle(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 / arg2, TokenType.Float);
        }

        Token FloatDivideDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToSingle(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token((decimal)arg1 / arg2, TokenType.Decimal);
        }

        Token FloatDivideDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToSingle(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 / arg2, TokenType.Double);
        }



        Token FloatDivideFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToSingle(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 / arg2, TokenType.Float);
        }



    }
}