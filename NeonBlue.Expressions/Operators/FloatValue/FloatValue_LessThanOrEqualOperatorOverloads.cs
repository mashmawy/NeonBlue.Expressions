using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.BooleanFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.FloatValue
{
    public class FloatValue_LessThanOrEqualOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, FloatLessThanOrEqualInteger);
                overloads.Add(TokenType.Integer, FloatLessThanOrEqualInteger);
                overloads.Add(TokenType.Long, FloatLessThanOrEqualLong);
                overloads.Add(TokenType.Decimal, FloatLessThanOrEqualDecimal);
                overloads.Add(TokenType.Double, FloatLessThanOrEqualDouble);
                overloads.Add(TokenType.Float, FloatLessThanOrEqualFloat);
                overloads.Add(TokenType.NULL, FloatLogicalOpNull);
            }
            return base.GetOverloads();
        }
        Token FloatLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        Token FloatLessThanOrEqualInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToSingle(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 <= arg2, TokenType.Boolean);
        }
        Token FloatLessThanOrEqualLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToSingle(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 <= arg2, TokenType.Boolean);
        }
        Token FloatLessThanOrEqualDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToSingle(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token((decimal)arg1 <= arg2, TokenType.Boolean);
        }


        Token FloatLessThanOrEqualDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToSingle(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 <= arg2, TokenType.Boolean);
        }

        Token FloatLessThanOrEqualFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToSingle(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 <= arg2, TokenType.Boolean);
        }


    }
}