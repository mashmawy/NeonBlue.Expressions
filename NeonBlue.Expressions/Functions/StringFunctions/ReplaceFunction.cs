namespace NeonBlue.Expressions.Functions.StringFunctions
{
    /// <summary>
    /// Represents the Replace function for replacing occurrences of a substring within a string.
    /// </summary>
    public class ReplaceFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "replace";

        /// <summary>
        /// Updates the stack by replacing occurrences of the second string with the third string in the top string value.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack contains fewer than three elements.</exception>
        /// <exception cref="InvalidArgumentTypeException">Thrown if any of the tokens are not string types.</exception>
        /// <exception cref="StringException">Thrown if the replace operation fails.</exception>
        public override void Update(Stack<Token> tokensStack, IExecutionOptions executionOptions)
        {
            if (tokensStack is null || tokensStack.Count < 3)
            {
                throw new EmptyStackException();
            }
            var token3 = tokensStack.Pop();
            var token2 = tokensStack.Pop();
            var token1 = tokensStack.Pop();
            if (StringFunctionsHelper.NullCheck(tokensStack, token1, executionOptions)) return;
            if (StringFunctionsHelper.NullCheck(tokensStack, token2, executionOptions)) return;
            if (StringFunctionsHelper.NullCheck(tokensStack, token3, executionOptions)) return;
            try
            {
                var arg3 = token3.Value!.ToString();
                var arg2 = token2.Value!.ToString();
                var arg1 = token1.Value!.ToString();
                tokensStack.Push(new Token(arg1!.Replace(arg2!, arg3), TokenType.String));
            }
            catch (Exception ex)
            {
                throw new StringException(FunctionName, $"String operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }

        }
    }
}