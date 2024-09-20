namespace NeonBlue.Expressions.Functions.StringFunctions
{
    /// <summary>
    /// Utility class for handling null tokens within string operations.
    /// </summary>
    public static class StringFunctionsHelper
    {
        /// <summary>
        /// Checks if the given token is null and handles it according to the specified null strategy.
        /// </summary>
        /// <param name="x">The stack of tokens.</param>
        /// <param name="token">The token to check.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>True if the token is null, false otherwise.</returns>
        /// <exception cref="NullTokenException">Thrown if the token is null and the null strategy is "Throw".</exception>
        public static bool NullCheck(Stack<Token> x, Token token, IExecutionOptions executionOptions)
        {
            if (token.TokenType == TokenType.NULL)
            {
                if (executionOptions.NullStrategy == NullStrategy.Throw)
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
    }
}