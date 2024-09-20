using NeonBlue.Expressions.Functions.BooleanFunctions;

namespace NeonBlue.Expressions.Operators.DeicmalValue
{
    public class DecimalValue_GreaterThanOrEqualOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, DecimalGreaterThanOrEqualInteger);
                overloads.Add(TokenType.Integer, DecimalGreaterThanOrEqualInteger);
                overloads.Add(TokenType.Long, DecimalGreaterThanOrEqualLong);
                overloads.Add(TokenType.Decimal, DecimalGreaterThanOrEqualDecimal);
                overloads.Add(TokenType.Double, DecimalGreaterThanOrEqualDouble);
                overloads.Add(TokenType.Float, DecimalGreaterThanOrEqualFloat);
                overloads.Add(TokenType.NULL, DecimalLogicalOpNull);
            }
            return overloads;
        }
        Token DecimalLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
        Token DecimalGreaterThanOrEqualInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }
        Token DecimalGreaterThanOrEqualLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }

        Token DecimalGreaterThanOrEqualDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }

        Token DecimalGreaterThanOrEqualDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 >= (decimal)arg2, TokenType.Boolean);
        }




        Token DecimalGreaterThanOrEqualFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 >= (decimal)arg2, TokenType.Boolean);
        }




    }
}