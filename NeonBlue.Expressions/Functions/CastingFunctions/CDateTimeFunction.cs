namespace NeonBlue.Expressions.Functions.CastingFunctions
{
    /// <summary>
    /// Represents the CDateTime function for converting a value to a DateTime.
    /// </summary>
    public class CDateTimeFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "cdatetime";

        /// <summary>
        /// Updates the stack by converting the top value to a DateTime.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack is empty.</exception>
        /// <exception cref="CastingException">Thrown if the value cannot be converted to a DateTime.</exception>
        public override void Update(Stack<Token> tokensStack, IExecutionOptions executionOptions)
        {
            if (tokensStack == null || tokensStack.Count < 1)
            {
                throw new EmptyStackException();
            }

            var arg1 = tokensStack.Pop();

            if (CastingFunctionsUtils.NullCheck(tokensStack, arg1, new Token(null), executionOptions))
            {
                return;
            }

            try
            {
                tokensStack.Push(new Token(Convert.ToDateTime(arg1.Value)));
            }
            catch (Exception ex)
            {
                throw new CastingException($"Can't cast input of type {arg1.TokenType} to datetime, see inner exception", ex);
            }
        }
    }

}