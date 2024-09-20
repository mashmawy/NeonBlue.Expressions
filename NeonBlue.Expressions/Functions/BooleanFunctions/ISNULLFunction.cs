namespace NeonBlue.Expressions.Functions.BooleanFunctions
{
    /// <summary>
    /// Represents the IsNull function for checking if a value is null.
    /// </summary>
    public class IsnullFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "isnull";

        /// <summary>
        /// Updates the stack by pushing a boolean value indicating whether the top token is null.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack is empty.</exception>
        public override void Update(Stack<Token> tokensStack, IExecutionOptions executionOptions)
        {
            if (tokensStack == null || tokensStack.Count < 1)
            {
                throw new EmptyStackException();
            }

            var token1 = tokensStack.Pop();

            if (token1.TokenType == TokenType.NULL)
            {
                tokensStack.Push(new Token(true, TokenType.Boolean));
            }
            else
            {
                tokensStack.Push(new Token(false, TokenType.Boolean));
            }
        }
    }
}