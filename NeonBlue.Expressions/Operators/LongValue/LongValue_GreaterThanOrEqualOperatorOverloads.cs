using NeonBlue.Expressions.Functions.BooleanFunctions;

namespace NeonBlue.Expressions.Operators.LongValue
{
    public class LongValue_GreaterThanOrEqualOperatorOverloads : OperatorsOverload
    {
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, LongGreaterThanOrEqualInteger);
                overloads.Add(TokenType.Integer, LongGreaterThanOrEqualInteger);
                overloads.Add(TokenType.Long, LongGreaterThanOrEqualLong);
                overloads.Add(TokenType.Decimal, LongGreaterThanOrEqualDecimal);
                overloads.Add(TokenType.Double, LongGreaterThanOrEqualDouble);
                overloads.Add(TokenType.Float, LongGreaterThanOrEqualFloat);
                overloads.Add(TokenType.NULL, LongLogicalOpNull);
            }
            return overloads;
        }
        Token LongLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
        Token LongGreaterThanOrEqualInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }

        Token LongGreaterThanOrEqualLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }


        Token LongGreaterThanOrEqualDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }

        Token LongGreaterThanOrEqualDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }


        Token LongGreaterThanOrEqualFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt64(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }

    }
}