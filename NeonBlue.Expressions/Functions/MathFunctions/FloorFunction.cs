namespace NeonBlue.Expressions.Functions.MathFunctions
{
    /// <summary>
    /// Represents the Floor function for rounding a number down to the nearest integer.
    /// </summary>
    public class FloorFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "floor";

        /// <summary>
        /// Updates the stack by rounding the top numeric value down to the nearest integer.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack is empty.</exception>
        /// <exception cref="InvalidArgumentTypeException">Thrown if the token is not a numeric type.</exception>
        /// <exception cref="MathException">Thrown if the floor operation fails.</exception>
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

                    var arg2val = Convert.ToDecimal(token.Value);
                    tokensStack.Push(new Token(Math.Floor(arg2val)));
                }
                else
                {
                    var arg2val = Convert.ToDouble(token.Value);
                    tokensStack.Push(new Token(Math.Floor(arg2val)));
                }
            }
            catch (Exception ex)
            {
                throw new MathException(FunctionName, $"Math operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }

        }
    }
}