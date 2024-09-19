using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.BooleanFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.FloatValue
{
    public class FloatValue_LessThanOperatorOverloads : OperatorsOverload
    {
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, FloatLessThanInteger);
                overloads.Add(TokenType.Integer, FloatLessThanInteger);
                overloads.Add(TokenType.Long, FloatLessThanLong);
                overloads.Add(TokenType.Decimal, FloatLessThanDecimal);
                overloads.Add(TokenType.Double, FloatLessThanDouble);
                overloads.Add(TokenType.Float, FloatLessThanFloat);
                overloads.Add(TokenType.NULL, FloatLogicalOpNull);
            }
            return base.GetOverloads();
        }
        Token FloatLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        Token FloatLessThanInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToSingle(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 < arg2, TokenType.Boolean);
        }
        Token FloatLessThanLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToSingle(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 < arg2, TokenType.Boolean);
        }
        Token FloatLessThanDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToSingle(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token((decimal)arg1 < arg2, TokenType.Boolean);
        }


        Token FloatLessThanDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToSingle(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 < arg2, TokenType.Boolean);
        }

        Token FloatLessThanFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToSingle(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 < arg2, TokenType.Boolean);
        }


    }
}