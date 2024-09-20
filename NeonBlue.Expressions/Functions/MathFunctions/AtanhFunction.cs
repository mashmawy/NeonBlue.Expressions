namespace NeonBlue.Expressions.Functions.MathFunctions
{
    /// <summary>
    /// Represents the Atanh function for calculating the inverse hyperbolic tangent of a number.
    /// </summary>
    public class AtanhFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "atanh";

        /// <summary>
        /// Updates the stack by calculating the inverse hyperbolic tangent of the top numeric value.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack is empty.</exception>
        /// <exception cref="InvalidArgumentTypeException">Thrown if the token is not a numeric type.</exception>
        /// <exception cref="MathException">Thrown if the inverse hyperbolic tangent operation fails.</exception>
        public override void Update(Stack<Token> tokensStack, IExecutionOptions executionOptions)
        {
            if (tokensStack == null || tokensStack.Count < 1)
            {
                throw new EmptyStackException();
            }

            var token = tokensStack.Pop();

            if (MathFunctionUtils.NullCheck(tokensStack, token, executionOptions.NullStrategy))
            {
                return;
            }

            if (!TokensUtils.IsNumeric(token.TokenType))
            {
                throw new InvalidArgumentTypeException(FunctionName, typeof(DateTime));
            }

            try
            {
                var val = Convert.ToDouble(token.Value);

                // Ensure the value is between -1 and 1 for Atanh
                if (val <= -1 || val >= 1)
                {
                    throw new ArgumentException("Argument must be between -1 and 1.");
                }

                tokensStack.Push(new Token(Math.Atanh(val)));
            }
            catch (Exception ex)
            {
                throw new MathException(FunctionName, $"Math operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }
        }
    }
}