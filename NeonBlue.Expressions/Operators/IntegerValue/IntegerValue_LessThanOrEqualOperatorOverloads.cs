using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.BooleanFunctions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Operators.IntegerValue
{
    public class IntegerValue_LessThanOrEqualOperatorOverloads : OperatorsOverload
    {
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, IntegerLessThanOrEqualInteger);
                overloads.Add(TokenType.Integer, IntegerLessThanOrEqualInteger);
                overloads.Add(TokenType.Long, IntegerLessThanOrEqualLong);
                overloads.Add(TokenType.Double, IntegerLessThanOrEqualDouble);
                overloads.Add(TokenType.Decimal, IntegerLessThanOrEqualDecimal);
                overloads.Add(TokenType.Float, IntegerLessThanOrEqualFloat);
                overloads.Add(TokenType.NULL, IntegerLogicalOpNull);
            }
            return base.GetOverloads();
        }
        Token IntegerLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
        Token IntegerLessThanOrEqualInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 <= arg2, TokenType.Boolean);
        }


        Token IntegerLessThanOrEqualLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 <= arg2, TokenType.Boolean);
        }


        Token IntegerLessThanOrEqualDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            double arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 <= arg2, TokenType.Boolean);
        }
        Token IntegerLessThanOrEqualDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 <= arg2, TokenType.Boolean);
        }
        Token IntegerLessThanOrEqualFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 <= arg2, TokenType.Boolean);
        }


    }

}