namespace NeonBlue.Expressions.Functions.DateFunctions
{
    /// <summary>
    /// Utility methods for working with date and time values in expression evaluation.
    /// </summary>
    public static class DateFunctionsUtils
    {
        /// <summary>
        /// Checks if the specified token is null and handles it based on the given null strategy.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="token">The token to check.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>True if the token was null and handled, false otherwise.</returns>
        /// <exception cref="NullTokenException">Thrown if the token is null and the null strategy is "Throw".</exception>
        public static bool NullCheck(Stack<Token> tokensStack, Token token, IExecutionOptions executionOptions)
        {
            if (token.TokenType == TokenType.NULL)
            {
                if (executionOptions.NullStrategy == NullStrategy.Throw)
                {
                    throw new NullTokenException(token);
                }
                else
                {
                    tokensStack.Push(new Token(null, TokenType.NULL));
                }

                return true;
            }

            return false;
        }
    }
}