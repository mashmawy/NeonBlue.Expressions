namespace NeonBlue.Expressions.Functions.BooleanFunctions
{
    /// <summary>
    /// Represents the logical AND function for boolean values.
    /// </summary>
    public class AndFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "and";

        /// <summary>
        /// Updates the stack by performing the logical AND operation on the top two boolean values.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack contains fewer than two elements.</exception>
        public override void Update(Stack<Token> tokensStack, IExecutionOptions executionOptions)
        {
            if (tokensStack == null || tokensStack.Count < 2)
            {
                throw new EmptyStackException();
            }

            var token2 = tokensStack.Pop();
            var token1 = tokensStack.Pop();

            if (BooleanFunctionsUtils.NullCheck(tokensStack, token1, executionOptions.NullStrategy))
            {
                return;
            }

            if (BooleanFunctionsUtils.NullCheck(tokensStack, token2, executionOptions.NullStrategy))
            {
                return;
            }

            BooleanFunctionsUtils.AssertBoolean(token1, FunctionName);
            BooleanFunctionsUtils.AssertBoolean(token2, FunctionName);

            var arg1 = Convert.ToBoolean(token1.Value);
            var arg2 = Convert.ToBoolean(token2.Value);

            tokensStack.Push(new Token(arg1 && arg2, TokenType.Boolean));
        }
    }
}