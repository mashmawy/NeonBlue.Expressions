namespace NeonBlue.Expressions.Functions.MathFunctions
{
    /// <summary>
    /// Represents the Truncate function for truncating a number to its integer part.
    /// </summary>
    public class TruncateFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "truncate";

        /// <summary>
        /// Updates the stack by truncating the top numeric value to its integer part.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack is empty.</exception>
        /// <exception cref="InvalidArgumentTypeException">Thrown if the token is not a numeric type.</exception>
        /// <exception cref="MathException">Thrown if the truncation operation fails.</exception>
        public override void Update(Stack<Token> tokensStack, IExecutionOptions executionOptions)
        {
            if (tokensStack is null || tokensStack.Count < 1)
            {
                throw new EmptyStackException();
            }
            var token = tokensStack.Pop();
            if (MathFunctionUtils.NullCheck(tokensStack, token, executionOptions.NullStrategy)) return;
            if (!TokensUtils.IsNumeric(token.TokenType))
            {
                throw new InvalidArgumentTypeException(FunctionName, typeof(DateTime));
            }


            try
            {
                if (token.TokenType == TokenType.Decimal)
                {
                    var arg1val = Convert.ToDecimal(token.Value);
                    tokensStack.Push(new Token(Math.Truncate(arg1val)));
                }
                else
                {
                    var arg1val = Convert.ToDouble(token.Value);
                    tokensStack.Push(new Token(Math.Truncate(arg1val)));
                }
            }
            catch (Exception ex)
            {
                throw new MathException(FunctionName, $"Math operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }
        }

    }
}