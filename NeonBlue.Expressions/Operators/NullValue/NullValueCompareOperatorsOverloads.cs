namespace NeonBlue.Expressions.Operators.NullValue
{
    /// <summary>
    /// Represents the operator overloads for comparison operations involving null values.
    /// </summary>
    public class NullValueCompareOperatorsOverloads : OperatorsOverload
    {
        /// <summary>
        /// Gets a dictionary of functions that handle null comparison operations for different token types.
        /// </summary>
        /// <returns>A dictionary of functions.</returns>
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

        /// <summary>
        /// Handles the case where one operand is null and the other is Boolean.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the comparison operation.</returns>
        private static Token NullEqualBoolean(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            if (executionOptions.NullStrategy == NullStrategy.Default)
            {
                return a2; // If null strategy is Default, return the non-null operand
            }
            else if (executionOptions.NullStrategy == NullStrategy.Propagate)
            {
                return new Token(null, TokenType.NULL); // If null strategy is Propagate, return null
            }
            else
            {
                throw new NullTokenException(a1); // If null strategy is Error, throw an exception
            }
        }

        /// <summary>
        /// Handles the case where one operand is null and the other is any other type.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the comparison operation.</returns>
        private static Token NullEqualAny(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            if (executionOptions.NullStrategy == NullStrategy.Default)
            {
                return new Token(false, TokenType.Boolean); // If null strategy is Default, return false
            }
            else if (executionOptions.NullStrategy == NullStrategy.Propagate)
            {
                return new Token(null, TokenType.NULL); // If null strategy is Propagate, return null
            }
            else
            {
                throw new NullTokenException(a1); // If null strategy is Error, throw an exception
            }
        }
    }
}