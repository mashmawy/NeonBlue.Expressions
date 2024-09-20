namespace NeonBlue.Expressions.Functions.MathFunctions
{
    /// <summary>
    /// Represents the Acosh function for calculating the inverse hyperbolic cosine of a number.
    /// </summary>
    public class AcoshFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "acosh";

        /// <summary>
        /// Updates the stack by calculating the inverse hyperbolic cosine of the top numeric value.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack is empty.</exception>
        /// <exception cref="InvalidArgumentTypeException">Thrown if the token is not a numeric type.</exception>
        /// <exception cref="MathException">Thrown if the inverse hyperbolic cosine operation fails.</exception>
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

                // Ensure the value is greater than or equal to 1 for Acosh
                if (val < 1)
                {
                    throw new ArgumentException("Argument must be greater than or equal to 1.");
                }

                tokensStack.Push(new Token(Math.Acosh(val)));
            }
            catch (Exception ex)
            {
                throw new MathException(FunctionName, $"Math operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }
        }
    }

}