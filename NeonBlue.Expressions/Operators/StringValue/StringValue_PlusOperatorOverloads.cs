using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Operators.StringValue
{
    public class StringValue_PlusOperatorOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.String, StringPlusString);
                overloads.Add(TokenType.Byte, StringPlusString);
                overloads.Add(TokenType.Integer, StringPlusString);
                overloads.Add(TokenType.Long, StringPlusString);
                overloads.Add(TokenType.Decimal, StringPlusString);
                overloads.Add(TokenType.Float, StringPlusString);
                overloads.Add(TokenType.Double, StringPlusString);
                overloads.Add(TokenType.NULL, StringMathNull);
            }
            return base.GetOverloads();
        }
        Token StringMathNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        Token StringPlusString(Token a1, Token a2, IExecutionOptions executionOptions)
        {

            var arg1 = Convert.ToString(a1.Value);
            var arg2 = Convert.ToString(a2.Value);
            return new Token(arg1 + arg2, TokenType.String);
        }


    }
}