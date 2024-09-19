using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.IntegerValue
{
    public class IntegerValue_PlusOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Integer, IntegerPlusInteger);
                overloads.Add(TokenType.Byte, IntegerPlusInteger);
                overloads.Add(TokenType.Long, IntegerPlusLong);
                overloads.Add(TokenType.Decimal, IntegerPlusDecimal);
                overloads.Add(TokenType.Double, IntegerPlusDouble);
                overloads.Add(TokenType.Float, IntegerPlusFloat);
                overloads.Add(TokenType.String, IntegerPlusString);
                overloads.Add(TokenType.NULL, IntegerMathNull);
            }
            return base.GetOverloads();
        }

        Token IntegerMathNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
        Token IntegerPlusInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 + arg2, TokenType.Integer);
        }

        Token IntegerPlusLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 + arg2, TokenType.Long);
        }

        Token IntegerPlusDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 + arg2, TokenType.Decimal);
        }

        Token IntegerPlusDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 + arg2, TokenType.Double);
        }

        Token IntegerPlusFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 + arg2, TokenType.Float);
        }

        Token IntegerPlusString(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            var arg2 = Convert.ToString(a2.Value);
            return new Token((arg1 + arg2).ToString(), TokenType.String);
        }

    }
}