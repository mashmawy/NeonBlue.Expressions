namespace NeonBlue.Expressions.Functions.StringFunctions
{
    /// <summary>
    /// Represents the Upper function for converting a string to uppercase.
    /// </summary>
    public class UpperFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "upper";

        /// <summary>
        /// Updates the stack by converting the top string value to uppercase.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack is empty.</exception>
        /// <exception cref="InvalidArgumentTypeException">Thrown if the token is not a string type.</exception>
        /// <exception cref="StringException">Thrown if the uppercase operation fails.</exception>
        public override void Update(Stack<Token> tokensStack, IExecutionOptions executionOptions)
        {
            if (tokensStack is null || tokensStack.Count < 1)
            {
                throw new EmptyStackException();
            }
            var token1 = tokensStack.Pop();
            if (StringFunctionsHelper.NullCheck(tokensStack, token1, executionOptions)) return;
            try
            {
                var arg1 = token1.Value!.ToString();
                tokensStack.Push(new Token(arg1!.ToUpper()));
            }
            catch (Exception ex)
            {
                throw new StringException(FunctionName, $"String operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }
        }
    }
}