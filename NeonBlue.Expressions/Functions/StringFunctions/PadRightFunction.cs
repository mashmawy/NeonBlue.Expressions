namespace NeonBlue.Expressions.Functions.StringFunctions
{
    /// <summary>
    /// Represents the PadRight function for padding a string with specified characters on the right side.
    /// </summary>
    public class PadRightFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "padright";

        /// <summary>
        /// Updates the stack by padding the top string value with specified characters on the right side.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack contains fewer than three elements.</exception>
        /// <exception cref="InvalidArgumentTypeException">Thrown if the first token is not a string type, the second token is not an integer type, or the third token is not a string type.</exception>
        /// <exception cref="StringException">Thrown if the pad right operation fails.</exception>
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
            try
            {
                var arg3 = token3.Value!.ToString();
                var arg2 = Convert.ToInt32(token2.Value);
                var arg1 = token1.Value!.ToString();
                tokensStack.Push(new Token(arg1!.PadRight(arg2, arg3![0]), TokenType.String));
            }
            catch (Exception ex)
            {
                throw new StringException(FunctionName, $"String operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }
        }
    }
}