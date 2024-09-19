using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.DoubleValue
{
    public class DoubleValue_PlusOperatorOverloads : OperatorsOverload
    {
        public DoubleValue_PlusOperatorOverloads()
        {
            GetOverloads();
        }
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, DoublePlusInteger);
                overloads.Add(TokenType.Integer, DoublePlusInteger);
                overloads.Add(TokenType.Long, DoublePlusLong);
                overloads.Add(TokenType.Decimal, DoublePlusDecimal);
                overloads.Add(TokenType.Double, DoublePlusDouble);
                overloads.Add(TokenType.Float, DoublePlusFloat);
                overloads.Add(TokenType.String, DoublePlusString);
                overloads.Add(TokenType.NULL, DoubleMathNull);
            }
            return base.GetOverloads();
        }
        Token DoubleMathNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        Token DoublePlusInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDouble(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 + arg2, TokenType.Double);
        }

        Token DoublePlusLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDouble(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 + arg2, TokenType.Double);
        }
        Token DoublePlusDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDouble(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token((decimal)arg1 + arg2, TokenType.Decimal);
        }
        Token DoublePlusDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDouble(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 + arg2, TokenType.Double);
        }
        Token DoublePlusFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDouble(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 + arg2, TokenType.Double);
        }
        Token DoublePlusString(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToDouble(a1.Value);
            var arg2 = Convert.ToString(a2.Value);
            return new Token((arg1 + arg2).ToString(), TokenType.String);
        }


    }
}