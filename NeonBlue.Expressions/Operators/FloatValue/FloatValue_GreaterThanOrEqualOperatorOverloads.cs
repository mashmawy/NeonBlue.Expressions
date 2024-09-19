using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.BooleanFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.FloatValue
{
    public class FloatValue_GreaterThanOrEqualOperatorOverloads : OperatorsOverload
    {
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, FloatGreaterThanOrEqualInteger);
                overloads.Add(TokenType.Integer, FloatGreaterThanOrEqualInteger);
                overloads.Add(TokenType.Long, FloatGreaterThanOrEqualLong);
                overloads.Add(TokenType.Decimal, FloatGreaterThanOrEqualDecimal);
                overloads.Add(TokenType.Double, FloatGreaterThanOrEqualDouble);
                overloads.Add(TokenType.Float, FloatGreaterThanOrEqualFloat);
                overloads.Add(TokenType.NULL, FloatLogicalOpNull);
            }
            return base.GetOverloads();
        }
        Token FloatLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        Token FloatGreaterThanOrEqualInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToSingle(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }
        Token FloatGreaterThanOrEqualLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToSingle(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }
        Token FloatGreaterThanOrEqualDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToSingle(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token((decimal)arg1 >= arg2, TokenType.Boolean);
        }


        Token FloatGreaterThanOrEqualDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToSingle(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }

        Token FloatGreaterThanOrEqualFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToSingle(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }


    }
}