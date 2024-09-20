﻿using System.Globalization;

namespace NeonBlue.Expressions.Functions.DateFunctions
{
    /// <summary>
    /// Represents the MonthName function for extracting the month name of a date.
    /// </summary>
    public class MonthNameFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "monthname";

        /// <summary>
        /// Updates the stack by extracting the month name of the top date value using the specified culture.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack contains fewer than two elements.</exception>
        /// <exception cref="InvalidArgumentTypeException">Thrown if the first token is not a DateTime or the second token is not a string.</exception>
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

            if (token1.TokenType != TokenType.Datetime)
            {
                throw new InvalidArgumentTypeException(FunctionName, typeof(DateTime));
            }

            var arg1 = Convert.ToDateTime(token1.Value);
            var arg2 = Convert.ToString(token2.Value);

            try
            {
                tokensStack.Push(new Token(arg1.ToString("MMMM", CultureInfo.CreateSpecificCulture(arg2!))));
            }
            catch (Exception ex)
            {
                throw new InvalidArgumentTypeException(FunctionName, typeof(DateTime), "Invalid date culture", ex);
            }
        }
    }
}