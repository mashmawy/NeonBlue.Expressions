using NeonBlue.Expressions.Functions.BooleanFunctions;

namespace NeonBlue.Expressions.Operators.IntegerValue
{
    public class IntegerValue_GreaterThanOrEqualOperatorOverloads : OperatorsOverload
    {
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, IntegerGreaterThanOrEqualInteger);
                overloads.Add(TokenType.Integer, IntegerGreaterThanOrEqualInteger);
                overloads.Add(TokenType.Long, IntegerGreaterThanOrEqualLong);
                overloads.Add(TokenType.Double, IntegerGreaterThanOrEqualDouble);
                overloads.Add(TokenType.Decimal, IntegerGreaterThanOrEqualDecimal);
                overloads.Add(TokenType.Float, IntegerGreaterThanOrEqualFloat);
                overloads.Add(TokenType.NULL, IntegerLogicalOpNull);
            }
            return base.GetOverloads();
        }
        Token IntegerLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
        Token IntegerGreaterThanOrEqualInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }


        Token IntegerGreaterThanOrEqualLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }


        Token IntegerGreaterThanOrEqualDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            double arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }
        Token IntegerGreaterThanOrEqualDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }
        Token IntegerGreaterThanOrEqualFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }




    }

}