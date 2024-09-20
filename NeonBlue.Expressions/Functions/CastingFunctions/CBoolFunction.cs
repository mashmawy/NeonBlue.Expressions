namespace NeonBlue.Expressions.Functions.CastingFunctions
{
    /// <summary>
    /// Represents the CBool function for converting a value to a boolean.
    /// </summary>
    public class CBoolFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "cbool";

        /// <summary>
        /// Updates the stack by converting the top value to a boolean.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack is empty.</exception>
        /// <exception cref="CastingException">Thrown if the value cannot be converted to a boolean.</exception>
        public override void Update(Stack<Token> tokensStack, IExecutionOptions executionOptions)
        {
            if (tokensStack == null || tokensStack.Count < 1)
            {
                throw new EmptyStackException();
            }

            var arg1 = tokensStack.Pop();

            if (CastingFunctionsUtils.NullCheck(tokensStack, arg1, new Token(false, TokenType.Boolean), executionOptions))
            {
                return;
            }

            try
            {
                tokensStack.Push(new Token(Convert.ToBoolean(arg1.Value)));
            }
            catch (Exception ex)
            {
                throw new CastingException($"Can't cast input of type {arg1.TokenType} to boolean, see inner exception", ex);
            }
        }
    }

}