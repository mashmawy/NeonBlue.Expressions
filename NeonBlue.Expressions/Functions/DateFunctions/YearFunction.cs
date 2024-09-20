namespace NeonBlue.Expressions.Functions.DateFunctions
{
    /// <summary>
    /// Represents the Year function for extracting the year from a date and time value.
    /// </summary>
    public class YearFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "year";

        /// <summary>
        /// Updates the stack by extracting the year from the top date and time value.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack is empty.</exception>
        /// <exception cref="InvalidArgumentTypeException">Thrown if the token is not a DateTime.</exception>
        public override void Update(Stack<Token> tokensStack, IExecutionOptions executionOptions)
        {
            if (tokensStack == null || tokensStack.Count < 1)
            {
                throw new EmptyStackException();
            }

            var token1 = tokensStack.Pop();

            if (DateFunctionsUtils.NullCheck(tokensStack, token1, executionOptions))
            {
                return;
            }

            if (token1.TokenType != TokenType.Datetime)
            {
                throw new InvalidArgumentTypeException(FunctionName, typeof(DateTime));
            }

            var arg1 = Convert.ToDateTime(token1.Value);
            tokensStack.Push(new Token(arg1.Year));
        }
    }
}