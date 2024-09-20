namespace NeonBlue.Expressions.Functions.DateFunctions
{
    /// <summary>
    /// Represents the Quarter function for extracting the quarter of the year from a date.
    /// </summary>
    public class QuarterFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "quarter";

        /// <summary>
        /// Updates the stack by extracting the quarter of the year from the top date value.
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
            int res;

            if (arg1.Month >= 1 && arg1.Month <= 3)
            {
                res = 1;
            }
            else if (arg1.Month >= 4 && arg1.Month <= 6)
            {
                res = 2;
            }
            else if (arg1.Month >= 7 && arg1.Month <= 9)
            {
                res = 3;
            }
            else
            {
                res = 4;
            }

            tokensStack.Push(new Token(res));
        }
    }
}