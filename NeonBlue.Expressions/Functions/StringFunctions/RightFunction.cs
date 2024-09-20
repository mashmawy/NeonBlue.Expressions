namespace NeonBlue.Expressions.Functions.StringFunctions
{
    /// <summary>
    /// Represents the Right function for extracting a substring from the right side of a string.
    /// </summary>
    public class RightFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "right";

        /// <summary>
        /// Updates the stack by extracting a substring from the right side of the top string value.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack contains fewer than two elements.</exception>
        /// <exception cref="InvalidArgumentTypeException">Thrown if the first token is not a string type or the second token is not an integer type.</exception>
        /// <exception cref="StringException">Thrown if the right operation fails.</exception>
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
            if (!TokensUtils.IsNumeric(token2.TokenType))
            {
                throw new InvalidArgumentTypeException(FunctionName, typeof(int));
            }

            try
            {
                var arg2 = Convert.ToInt32(token2.Value);
                var arg1 = token1.Value!.ToString();
                tokensStack.Push(new Token(arg1![(arg1!.Length - arg2)..]));
            }
            catch (Exception ex)
            {
                throw new StringException(FunctionName, $"String operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }
        }
    }
}

