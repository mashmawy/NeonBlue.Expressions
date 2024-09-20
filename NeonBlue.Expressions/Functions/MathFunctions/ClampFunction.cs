namespace NeonBlue.Expressions.Functions.MathFunctions
{
    /// <summary>
    /// Represents the Clamp function for clamping a number within a specified range.
    /// </summary>
    public class ClampFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "clamp";

        /// <summary>
        /// Updates the stack by clamping the top numeric value within the specified range.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack contains fewer than three elements.</exception>
        /// <exception cref="InvalidArgumentTypeException">Thrown if any of the tokens are not numeric types.</exception>
        /// <exception cref="MathException">Thrown if the clamp operation fails.</exception>
        public override void Update(Stack<Token> tokensStack, IExecutionOptions executionOptions)
        {
            if (tokensStack == null || tokensStack.Count < 3)
            {
                throw new EmptyStackException();
            }

            var arg3 = tokensStack.Pop();
            var arg2 = tokensStack.Pop();
            var arg1 = tokensStack.Pop();

            if (MathFunctionUtils.NullCheck(tokensStack, arg3, executionOptions.NullStrategy))
            {
                return;
            }

            if (MathFunctionUtils.NullCheck(tokensStack, arg2, executionOptions.NullStrategy))
            {
                return;
            }

            if (MathFunctionUtils.NullCheck(tokensStack, arg1, executionOptions.NullStrategy))
            {
                return;
            }

            if (!TokensUtils.IsNumeric(arg1.TokenType) ||
                !TokensUtils.IsNumeric(arg2.TokenType) ||
                !TokensUtils.IsNumeric(arg3.TokenType))
            {
                throw new InvalidArgumentTypeException(FunctionName, typeof(DateTime));
            }

            try
            {
                switch (arg1.TokenType)
                {
                    case TokenType.Integer:
                        {
                            var arg1val = Convert.ToInt32(arg1.Value);
                            var arg2val = Convert.ToInt32(arg2.Value);
                            var arg3val = Convert.ToInt32(arg3.Value);
                            tokensStack.Push(new Token(Math.Clamp(arg1val, arg2val, arg3val)));
                            break;
                        }

                    case TokenType.Long:
                        {
                            var arg1val = Convert.ToInt64(arg1.Value);
                            var arg2val = Convert.ToInt64(arg2.Value);
                            var arg3val = Convert.ToInt64(arg3.Value);
                            tokensStack.Push(new Token(Math.Clamp(arg1val, arg2val, arg3val)));
                            break;
                        }

                    case TokenType.Double:
                        {
                            var arg1val = Convert.ToDouble(arg1.Value);
                            var arg2val = Convert.ToDouble(arg2.Value);
                            var arg3val = Convert.ToDouble(arg3.Value);
                            tokensStack.Push(new Token(Math.Clamp(arg1val, arg2val, arg3val)));
                            break;
                        }

                    case TokenType.Float:
                        {
                            var arg1val = Convert.ToSingle(arg1.Value);
                            var arg2val = Convert.ToSingle(arg2.Value);
                            var arg3val = Convert.ToSingle(arg3.Value);
                            tokensStack.Push(new Token(Math.Clamp(arg1val, arg2val, arg3val)));
                            break;
                        }

                    case TokenType.Decimal:
                        {
                            var arg1val = Convert.ToDecimal(arg1.Value);
                            var arg2val = Convert.ToDecimal(arg2.Value);
                            var arg3val = Convert.ToDecimal(arg3.Value);
                            tokensStack.Push(new Token(Math.Clamp(arg1val, arg2val, arg3val)));
                            break;
                        }

                    case TokenType.Byte:
                        {
                            var arg1val = Convert.ToByte(arg1.Value);
                            var arg2val = Convert.ToByte(arg2.Value);
                            var arg3val = Convert.ToByte(arg3.Value);
                            tokensStack.Push(new Token(Math.Clamp(arg1val, arg2val, arg3val)));
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