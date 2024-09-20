namespace NeonBlue.Expressions.Functions.MathFunctions
{
    /// <summary>
    /// Utility class for handling null tokens within mathematical expressions.
    /// </summary>
    public static class MathFunctionUtils
    {
        /// <summary>
        /// Checks if the given token is null and handles it according to the specified null strategy.
        /// </summary>
        /// <param name="x">The stack of tokens.</param>
        /// <param name="token">The token to check.</param>
        /// <param name="nullStrategy">The null strategy to apply.</param>
        /// <returns>True if the token is null, false otherwise.</returns>
        /// <exception cref="NullTokenException">Thrown if the token is null and the null strategy is "Throw".</exception>
        public static bool NullCheck(Stack<Token> x, Token token, NullStrategy nullStrategy)
        {
            if (token.TokenType == TokenType.NULL)
            {
                if (nullStrategy == NullStrategy.Throw)
                {
                    throw new NullTokenException(token);
                }
                else
                {
                    x.Push(new Token(null, TokenType.NULL));
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if the given token is null and handles it according to the specified null strategy.
        /// </summary>
        /// <param name="token">The token to check.</param>
        /// <param name="nullStrategy">The null strategy to apply.</param>
        /// <returns>A new null token if the given token is null, otherwise the original token.</returns>
        /// <exception cref="NullTokenException">Thrown if the token is null and the null strategy is "Throw".</exception>
        public static Token NullCheck(Token token, NullStrategy nullStrategy)
        {
            if (nullStrategy == NullStrategy.Throw)
            {
                throw new NullTokenException(token);
            }
            else
            {
                return new Token(null, TokenType.NULL);
            }
        }
    }
}