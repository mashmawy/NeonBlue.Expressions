using NeonBlue.Expressions.Functions.StringFunctions;

namespace NeonBlue.Expressions.Functions.CastingFunctions
{
    /// <summary>
    /// Represents the CString function for converting a value to a string.
    /// </summary>
    public class CStringFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "cstring";

        /// <summary>
        /// Updates the stack by converting the top value to a string.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack is empty.</exception>
        /// <exception cref="CastingException">Thrown if the value cannot be converted to a string.</exception>
        public override void Update(Stack<Token> tokensStack, IExecutionOptions executionOptions)
        {
            if (tokensStack == null || tokensStack.Count < 1)
            {
                throw new EmptyStackException();
            }

            var token1 = tokensStack.Pop();

            if (StringFunctionsHelper.NullCheck(tokensStack, token1, executionOptions))
            {
                return;
            }

            try
            {
                var arg1 = token1.Value!.ToString();
                tokensStack.Push(new Token(arg1, TokenType.String));
            }
            catch (Exception ex)
            {
                throw new CastingException($"Can't cast input of type {token1.TokenType} to string, see inner exception", ex);
            }
        }
    }
}