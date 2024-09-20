namespace NeonBlue.Expressions.Functions.StringFunctions
{
    /// <summary>
    /// Represents the StartWith function for checking if a string starts with a specified prefix.
    /// </summary>
    public class StartWithFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "startwith";

        /// <summary>
        /// Updates the stack by checking if the first string starts with the second string.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack contains fewer than two elements.</exception>
        /// <exception cref="InvalidArgumentTypeException">Thrown if either of the tokens are not string types.</exception>
        /// <exception cref="StringException">Thrown if the startswith operation fails.</exception>
        public override void Update(Stack<Token> tokensStack, IExecutionOptions executionOptions)
        {
            if (tokensStack is null || tokensStack.Count < 2)
            {
                throw new EmptyStackException();
            }
            var token2 = tokensStack.Pop();
            var token1 = tokensStack.Pop();
            if (StringFunctionsHelper.NullCheck(tokensStack, token1, executionOptions)) return;
            if (StringFunctionsHelper.NullCheck(tokensStack, token2, executionOptions)) return;
            try
            {
                var arg2 = token2.Value!.ToString();
                var arg1 = token1.Value!.ToString();
                tokensStack.Push(new Token(arg1!.StartsWith(arg2!)));
            }
            catch (Exception ex)
            {
                throw new StringException(FunctionName, $"String operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }
        }
    }
}