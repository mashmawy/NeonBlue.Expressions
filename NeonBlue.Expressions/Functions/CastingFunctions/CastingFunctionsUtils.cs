namespace NeonBlue.Expressions.Functions.CastingFunctions
{
    /// <summary>
    /// Utility methods for handling null values in expression evaluation.
    /// </summary>
    public static class CastingFunctionsUtils
    {
        /// <summary>
        /// Checks if the specified token is null and handles it based on the given null strategy.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="token">The token to check.</param>
        /// <param name="defaultToken">The default token to push if the token is null and the strategy is "Default".</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>True if the token was null and handled, false otherwise.</returns>
        /// <exception cref="NullTokenException">Thrown if the token is null and the null strategy is "Throw".</exception>
        public static bool NullCheck(Stack<Token> tokensStack, Token token, Token defaultToken, IExecutionOptions executionOptions)
        {
            if (token.TokenType == TokenType.NULL)
            {
                switch (executionOptions.NullStrategy)
                {
                    case NullStrategy.Throw:
                        throw new NullTokenException(token);
                    case NullStrategy.Default:
                        tokensStack.Push(defaultToken);
                        break;
                    case NullStrategy.Propagate:
                        tokensStack.Push(token);
                        break;
                } 
                return true;
            } 
            return false;
        }
    }
}