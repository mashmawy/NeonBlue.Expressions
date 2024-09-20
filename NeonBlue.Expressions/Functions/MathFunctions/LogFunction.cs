﻿namespace NeonBlue.Expressions.Functions.MathFunctions
{
    /// <summary>
    /// Represents the Log function for calculating the natural logarithm of a number.
    /// </summary>
    public class LogFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "log";

        /// <summary>
        /// Updates the stack by calculating the natural logarithm of the top numeric value.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack is empty.</exception>
        /// <exception cref="InvalidArgumentTypeException">Thrown if the token is not a numeric type.</exception>
        /// <exception cref="MathException">Thrown if the natural logarithm operation fails.</exception>
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
                            tokensStack.Push(new Token(Math.Log(val)));
                            break;
                        }

                    case TokenType.Long:
                        {
                            var val = Convert.ToInt64(token.Value);
                            tokensStack.Push(new Token(Math.Log(val)));
                            break;
                        }

                    case TokenType.Double:
                        {
                            var val = Convert.ToDouble(token.Value);
                            tokensStack.Push(new Token(Math.Log(val)));
                            break;
                        }

                    case TokenType.Float:
                        {
                            var val = Convert.ToSingle(token.Value);
                            tokensStack.Push(new Token(Math.Log(val)));
                            break;
                        }

                    case TokenType.Decimal:
                        {
                            var val = Convert.ToDecimal(token.Value);
                            tokensStack.Push(new Token(Math.Log((double)val)));
                            break;
                        }

                    case TokenType.Byte:
                        {
                            var val = Convert.ToByte(token.Value);
                            tokensStack.Push(new Token(Math.Log(val)));
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