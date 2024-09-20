namespace NeonBlue.Expressions.Functions.MathFunctions
{
    /// <summary>
    /// Represents the Round function for rounding a number to a specified number of decimal places.
    /// </summary>
    public class RoundFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "round";

        /// <summary>
        /// Updates the stack by rounding the top numeric value to the specified number of decimal places.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack contains fewer than two elements.</exception>
        /// <exception cref="InvalidArgumentTypeException">Thrown if the first token is not numeric or the second token is not an integer.</exception>
        /// <exception cref="MathException">Thrown if the rounding operation fails.</exception>
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
                var arg2val = Convert.ToInt32(arg2.Value);

                switch (arg1.TokenType)
                {
                    case TokenType.Decimal:
                        {
                            var val = Convert.ToDecimal(arg1.Value);
                            tokensStack.Push(new Token(Math.Round(val, arg2val)));
                            break;
                        }

                    case TokenType.Double:
                        {
                            var val = Convert.ToDouble(arg1.Value);
                            tokensStack.Push(new Token(Math.Round(val, arg2val)));
                            break;
                        }

                    case TokenType.Float:
                        {
                            var val = Convert.ToSingle(arg1.Value);
                            tokensStack.Push(new Token(Math.Round(val, arg2val)));
                            break;
                        }

                    default:
                        {
                            // Integer, Long, or Byte values are already rounded
                            tokensStack.Push(arg1);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                throw new MathException(FunctionName, $"Math operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }
        }
    }
}