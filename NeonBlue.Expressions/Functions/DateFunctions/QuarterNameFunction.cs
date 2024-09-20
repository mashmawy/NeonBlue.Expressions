namespace NeonBlue.Expressions.Functions.DateFunctions
{
    /// <summary>
    /// Represents the QuarterName function for extracting the name of the quarter from a date.
    /// </summary>
    public class QuarterNameFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "quartername";

        /// <summary>
        /// Updates the stack by extracting the name of the quarter from the top date value.
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
            string res;

            if (arg1.Month >= 1 && arg1.Month <= 3)
            {
                res = "Q1";
            }
            else if (arg1.Month >= 4 && arg1.Month <= 6)
            {
                res = "Q2";
            }
            else if (arg1.Month >= 7 && arg1.Month <= 9)
            {
                res = "Q3";
            }
            else
            {
                res = "Q4";
            }

            tokensStack.Push(new Token(res));
        }
    }
}