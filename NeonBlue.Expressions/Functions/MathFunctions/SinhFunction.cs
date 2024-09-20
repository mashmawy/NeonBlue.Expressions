namespace NeonBlue.Expressions.Functions.MathFunctions
{
    /// <summary>
    /// Represents the Sinh function for calculating the hyperbolic sine of a number.
    /// </summary>
    public class SinhFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "sinh";

        /// <summary>
        /// Updates the stack by calculating the hyperbolic sine of the top numeric value.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack is empty.</exception>
        /// <exception cref="InvalidArgumentTypeException">Thrown if the token is not a numeric type.</exception>
        /// <exception cref="MathException">Thrown if the hyperbolic sine operation fails.</exception>
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
                switch (token.TokenType)
                {
                    case TokenType.Integer:
                        {
                            var val = Convert.ToInt32(token.Value);
                            tokensStack.Push(new Token(Math.Sinh(val)));
                            break;
                        }

                    case TokenType.Long:
                        {
                            var val = Convert.ToInt64(token.Value);
                            tokensStack.Push(new Token(Math.Sinh(val)));
                            break;
                        }

                    case TokenType.Double:
                        {
                            var val = Convert.ToDouble(token.Value);
                            tokensStack.Push(new Token(Math.Sinh(val)));
                            break;
                        }

                    case TokenType.Float:
                        {
                            var val = Convert.ToSingle(token.Value);
                            tokensStack.Push(new Token(Math.Sinh(val)));
                            break;
                        }

                    case TokenType.Decimal:
                        {
                            var val = Convert.ToDecimal(token.Value);
                            tokensStack.Push(new Token(Math.Sinh((double)val)));
                            break;
                        }

                    case TokenType.Byte:
                        {
                            var val = Convert.ToByte(token.Value);
                            tokensStack.Push(new Token(Math.Sinh(val)));
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