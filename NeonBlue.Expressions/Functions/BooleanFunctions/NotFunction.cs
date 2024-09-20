namespace NeonBlue.Expressions.Functions.BooleanFunctions
{
    /// <summary>
    /// Represents the logical NOT function for boolean values.
    /// </summary>
    public class NotFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "not";

        /// <summary>
        /// Updates the stack by performing the logical NOT operation on the top boolean value.
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

            if (BooleanFunctionsUtils.NullCheck(tokensStack, token1, executionOptions.NullStrategy))
            {
                return;
            }

            BooleanFunctionsUtils.AssertBoolean(token1, FunctionName);

            var arg1 = Convert.ToBoolean(token1.Value);
            tokensStack.Push(new Token(!arg1, TokenType.Boolean));
        }
    }
}