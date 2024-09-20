namespace NeonBlue.Expressions.Functions.BooleanFunctions
{
    /// <summary>
    /// Represents the IIf function (ternary operator equivalent).
    /// </summary>
    public class IifFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "iif";

        /// <summary>
        /// Updates the stack by performing the IIf function on the top three elements.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack contains fewer than three elements.</exception>
        public override void Update(Stack<Token> tokensStack, IExecutionOptions executionOptions)
        {
            if (tokensStack == null || tokensStack.Count < 3)
            {
                throw new EmptyStackException();
            }

            var token3 = tokensStack.Pop();
            var token2 = tokensStack.Pop();
            var token1 = tokensStack.Pop();

            if (BooleanFunctionsUtils.NullCheck(tokensStack, token1, NullStrategy.Throw))
            {
                return;
            }

            BooleanFunctionsUtils.AssertBoolean(token1, FunctionName);

            var arg1 = Convert.ToBoolean(token1.Value);

            if (arg1)
            {
                tokensStack.Push(token2);
            }
            else
            {
                tokensStack.Push(token3);
            }
        }
    }
}