namespace NeonBlue.Expressions.Functions.StringFunctions
{
    /// <summary>
    /// Represents the Substring function for extracting a substring from a string.
    /// </summary>
    public class SubstringFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "substring";

        /// <summary>
        /// Updates the stack by extracting a substring from the top string value.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack contains fewer than three elements.</exception>
        /// <exception cref="InvalidArgumentTypeException">Thrown if the first token is not a string type, or the second and third tokens are not integer types.</exception>
        /// <exception cref="StringException">Thrown if the substring operation fails.</exception>
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
            if (!TokensUtils.IsNumeric(token2.TokenType))
            {
                throw new InvalidArgumentTypeException(FunctionName, typeof(int));
            }
            if (!TokensUtils.IsNumeric(token3.TokenType))
            {
                throw new InvalidArgumentTypeException(FunctionName, typeof(int));
            }
            try
            {
                var arg3 = Convert.ToInt32(token3.Value);
                var arg2 = Convert.ToInt32(token2.Value);
                var arg1 = token1.ToString();
                tokensStack.Push(new Token(arg1.Substring(arg2, arg3)));


            }
            catch (Exception ex)
            {
                throw new StringException(FunctionName, $"String operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }
        }
    }
}