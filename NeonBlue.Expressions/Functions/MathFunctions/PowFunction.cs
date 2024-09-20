namespace NeonBlue.Expressions.Functions.MathFunctions
{
    /// <summary>
    /// Represents the Pow function for calculating the power of a number.
    /// </summary>
    public class PowFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "pow";

        /// <summary>
        /// Updates the stack by calculating the power of the top two numeric values.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack contains fewer than two elements.</exception>
        /// <exception cref="InvalidArgumentTypeException">Thrown if either of the tokens are not numeric types.</exception>
        /// <exception cref="MathException">Thrown if the power operation fails.</exception>
        public override void Update(Stack<Token> tokensStack, IExecutionOptions executionOptions)
        {
            if (tokensStack == null || tokensStack.Count < 2)
            {
                throw new EmptyStackException();
            }

            var arg2 = tokensStack.Pop();
            var arg1 = tokensStack.Pop();

            if (MathFunctionUtils.NullCheck(tokensStack, arg2, executionOptions.NullStrategy))
            {
                return;
            }

            if (MathFunctionUtils.NullCheck(tokensStack, arg1, executionOptions.NullStrategy))
            {
                return;
            }

            if (!TokensUtils.IsNumeric(arg1.TokenType) || !TokensUtils.IsNumeric(arg2.TokenType))
            {
                throw new InvalidArgumentTypeException(FunctionName, arg1.GetType());
            }

            try
            {
                var arg2val = Convert.ToDouble(arg2.Value);
                var arg1val = Convert.ToDouble(arg1.Value);
                tokensStack.Push(new Token(Math.Pow(arg1val, arg2val)));
            }
            catch (Exception ex)
            {
                throw new MathException(FunctionName, $"Math operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }
        }
    }
}