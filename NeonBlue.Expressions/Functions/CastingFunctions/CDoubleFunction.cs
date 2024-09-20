namespace NeonBlue.Expressions.Functions.CastingFunctions
{
    /// <summary>
    /// Represents the CDouble function for converting a value to a double.
    /// </summary>
    public class CDoubleFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "cdouble";

        /// <summary>
        /// Updates the stack by converting the top value to a double.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack is empty.</exception>
        /// <exception cref="CastingException">Thrown if the value cannot be converted to a double.</exception>
        public override void Update(Stack<Token> tokensStack, IExecutionOptions executionOptions)
        {
            if (tokensStack == null || tokensStack.Count < 1)
            {
                throw new EmptyStackException();
            }

            var arg1 = tokensStack.Pop();

            if (CastingFunctionsUtils.NullCheck(tokensStack, arg1, new Token(0.0, TokenType.Double), executionOptions))
            {
                return;
            }

            try
            {
                tokensStack.Push(new Token(Convert.ToDouble(arg1.Value)));
            }
            catch (Exception ex)
            {
                throw new CastingException($"Can't cast input of type {arg1.TokenType} to double, see inner exception", ex);
            }
        }
    }
}