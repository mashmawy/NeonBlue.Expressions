namespace NeonBlue.Expressions.Functions.DateFunctions
{
    /// <summary>
    /// Represents the AddYears function for adding years to a date.
    /// </summary>
    public class AddYearsFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "addyears";

        /// <summary>
        /// Updates the stack by adding the specified number of years to the top date value.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack contains fewer than two elements.</exception>
        /// <exception cref="InvalidArgumentTypeException">Thrown if the first token is not a DateTime or the second token is not an integer.</exception>
        public override void Update(Stack<Token> tokensStack, IExecutionOptions executionOptions)
        {
            if (tokensStack == null || tokensStack.Count < 2)
            {
                throw new EmptyStackException();
            }

            var token2 = tokensStack.Pop();
            var token1 = tokensStack.Pop();

            if (DateFunctionsUtils.NullCheck(tokensStack, token1, executionOptions))
            {
                return;
            }

            if (DateFunctionsUtils.NullCheck(tokensStack, token2, executionOptions))
            {
                return;
            }

            if (token2.TokenType != TokenType.Integer || token1.TokenType != TokenType.Datetime)
            {
                throw new InvalidArgumentTypeException(FunctionName, typeof(DateTime));
            }

            var arg1 = Convert.ToDateTime(token1.Value);
            var arg2 = Convert.ToInt32(token2.Value);

            tokensStack.Push(new Token(arg1.AddYears(arg2)));
        }
    }
}