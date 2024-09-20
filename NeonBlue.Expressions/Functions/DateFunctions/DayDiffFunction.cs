namespace NeonBlue.Expressions.Functions.DateFunctions
{
    /// <summary>
    /// Represents the DayDiff function for calculating the difference in days between two dates.
    /// </summary>
    public class DayDiffFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "daydiff";

        /// <summary>
        /// Updates the stack by calculating the difference in days between the top two date values.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack contains fewer than two elements.</exception>
        /// <exception cref="InvalidArgumentTypeException">Thrown if either token is not a DateTime.</exception>
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

            if (token2.TokenType != TokenType.Datetime || token1.TokenType != TokenType.Datetime)
            {
                throw new InvalidArgumentTypeException(FunctionName, typeof(DateTime));
            }

            var arg1 = Convert.ToDateTime(token1.Value);
            var arg2 = Convert.ToDateTime(token2.Value);

            tokensStack.Push(new Token(arg1.Subtract(arg2).TotalDays, TokenType.Double));
        }
    }

}