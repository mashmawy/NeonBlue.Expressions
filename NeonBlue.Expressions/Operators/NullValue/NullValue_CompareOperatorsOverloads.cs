namespace NeonBlue.Expressions.Operators.NullValue
{
    public class NullValue_CompareOperatorsOverloads : OperatorsOverload
    {

        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Boolean, NullEqualBoolean);
                overloads.Add(TokenType.Integer, NullEqualAny);
                overloads.Add(TokenType.Datetime, NullEqualAny);
                overloads.Add(TokenType.Byte, NullEqualAny);
                overloads.Add(TokenType.Float, NullEqualAny);
                overloads.Add(TokenType.Long, NullEqualAny);
                overloads.Add(TokenType.Double, NullEqualAny);
                overloads.Add(TokenType.Decimal, NullEqualAny);
                overloads.Add(TokenType.NULL, NullEqualAny);
                overloads.Add(TokenType.String, NullEqualAny);

            }
            return base.GetOverloads();
        }
        Token NullEqualBoolean(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            if (executionOptions.NullStrategy == NullStrategy.Default)
            {
                return a2;
            }
            else if (executionOptions.NullStrategy == NullStrategy.Propagate)
            {
                return new Token(null, TokenType.NULL);
            }
            else
            {
                throw new NullTokenException(a1);
            }
        }
        Token NullEqualAny(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            if (executionOptions.NullStrategy == NullStrategy.Default)
            {
                return new Token(false, TokenType.Boolean); ;
            }
            else if (executionOptions.NullStrategy == NullStrategy.Propagate)
            {
                return new Token(null, TokenType.NULL);
            }
            else
            {
                throw new NullTokenException(a1);
            }
        }


    }
}