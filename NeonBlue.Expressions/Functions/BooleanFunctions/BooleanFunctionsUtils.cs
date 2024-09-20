namespace NeonBlue.Expressions.Functions.BooleanFunctions
{
    /// <summary>
    /// Utility methods for working with boolean values in expression evaluation.
    /// </summary>
    public static class BooleanFunctionsUtils
    {
        /// <summary>
        /// Checks if the specified token represents a boolean value.
        /// </summary>
        /// <param name="token">The token to check.</param>
        /// <returns>True if the token is a boolean value, false otherwise.</returns>
        public static bool IsBoolean(Token token)
        {
            if (token == null || token.Value is null)
            {
                return false;
            }

            return token.TokenType == TokenType.Boolean || token.Value.ToString() == "true" || token.Value.ToString() == "false"
                || token.Value.ToString() == "1" || token.Value.ToString() == "0";
        }

        /// <summary>
        /// Asserts that the specified token is a boolean value.
        /// </summary>
        /// <param name="token">The token to check.</param>
        /// <param name="function">The name of the function that uses the token.</param>
        /// <exception cref="InvalidArgumentTypeException">Thrown if the token is not a boolean value.</exception>
        public static void AssertBoolean(Token token, string function)
        {
            if (!IsBoolean(token) && token.Value is not null)
            {
                throw new InvalidArgumentTypeException(
                    function, token.Value.GetType(), $"Invalid Argument type {token.Value.GetType().Name} for function {function}");
            }
        }

        /// <summary>
        /// Checks if the specified token is null and handles it based on the given null strategy.
        /// </summary>
        /// <param name="x">The stack of tokens.</param>
        /// <param name="token">The token to check.</param>
        /// <param name="nullStrategy">The null strategy to apply.</param>
        /// <returns>True if the token was null and handled, false otherwise.</returns>
        /// <exception cref="EmptyStackException">Thrown if the stack is null or empty.</exception>
        /// <exception cref="NullTokenException">Thrown if the token is null and the null strategy is "Throw".</exception>
        public static bool NullCheck(Stack<Token> x, Token token, NullStrategy nullStrategy)
        {
            if (x == null)
            {
                throw new EmptyStackException();
            }

            if (token.TokenType == TokenType.NULL)
            {
                switch (nullStrategy)
                {
                    case NullStrategy.Throw:
                        throw new NullTokenException(token);
                    case NullStrategy.Default:
                        x.Push(new Token(false, TokenType.Boolean));
                        break;
                    case NullStrategy.Propagate:
                        x.Push(token);
                        break;
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Handles a null token based on the given null strategy.
        /// </summary>
        /// <param name="token">The token to check.</param>
        /// <param name="nullStrategy">The null strategy to apply.</param>
        /// <returns>A new token representing the null value according to the strategy.</returns>
        /// <exception cref="NullTokenException">Thrown if the null strategy is "Throw".</exception>
        public static Token NullCheck(Token token, NullStrategy nullStrategy)
        {
            if (nullStrategy == NullStrategy.Default)
            {
                return new Token(false, TokenType.Boolean);
            }
            else if (nullStrategy == NullStrategy.Propagate)
            {
                return new Token(null, TokenType.NULL);
            }
            else
            {
                throw new NullTokenException(token);
            }
        }
    }
}