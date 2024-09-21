namespace NeonBlue.Expressions.Operators.NullValue
{
    /// <summary>
    /// Represents the operator overloads for mathematical operations involving null values.
    /// </summary>
    public class NullValueMathOperatorsOverloads : OperatorsOverload
    {
        /// <summary>
        /// Gets a dictionary of functions that handle null mathematical operations for different token types.
        /// </summary>
        /// <returns>A dictionary of functions.</returns>
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, NullMathNumeric);
                overloads.Add(TokenType.Integer, NullMathNumeric);
                overloads.Add(TokenType.Long, NullMathNumeric);
                overloads.Add(TokenType.Decimal, NullMathNumeric);
                overloads.Add(TokenType.Double, NullMathNumeric);
                overloads.Add(TokenType.Float, NullMathNumeric);
                overloads.Add(TokenType.NULL, NullMathNumeric);
            }

            return base.GetOverloads();
        }

        /// <summary>
        /// Handles the case where one operand is null for all numeric types.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the mathematical operation.</returns>
        private static Token NullMathNumeric(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            if (executionOptions.NullStrategy == NullStrategy.Throw)
            {
                throw new NullTokenException(a1);
            }
            else
            {
                return new Token(null, TokenType.NULL);
            }
        }
    }
}