using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Operators.DoubleValue
{
    /// <summary>
    /// Represents the operator overloads for subtraction operations involving Double values.
    /// </summary>
    public class DoubleValueMinusOperatorOverloads : OperatorsOverload
    {
        /// <summary>
        /// Gets a dictionary of functions that handle subtraction operations for different token types.
        /// </summary>
        /// <returns>A dictionary of functions.</returns>
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, DoubleMinusInteger);
                overloads.Add(TokenType.Integer, DoubleMinusInteger);
                overloads.Add(TokenType.Long, DoubleMinusLong);
                overloads.Add(TokenType.Decimal, DoubleMinusDecimal);
                overloads.Add(TokenType.Double, DoubleMinusDouble);
                overloads.Add(TokenType.Float, DoubleMinusFloat);
                overloads.Add(TokenType.NULL, DoubleMathNull);
            }

            return base.GetOverloads();
        }

        /// <summary>
        /// Handles the case where one operand is Double and the other is null.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the subtraction operation.</returns>
        private static Token DoubleMathNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        /// <summary>
        /// Handles the case where one operand is Double and the other is Integer.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the subtraction operation.</returns>
        private static Token DoubleMinusInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 - arg2, TokenType.Double);
        }

        /// <summary>
        /// Handles the case where one operand is Double and the other is Long.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the subtraction operation.</returns>
        private static Token DoubleMinusLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 - arg2, TokenType.Double);
        }

        /// <summary>
        /// Handles the case where one operand is Double and the other is Decimal.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the subtraction operation.</returns>
        private static Token DoubleMinusDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token((decimal)arg1 - arg2, TokenType.Decimal);
        }

        /// <summary>
        /// Handles the case where both operands are Double.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the subtraction operation.</returns>
        private static Token DoubleMinusDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 - arg2, TokenType.Double);
        }

        /// <summary>
        /// Handles the case where one operand is Double and the other is Float.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the subtraction operation.</returns>
        private static Token DoubleMinusFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 - arg2, TokenType.Double);
        }
    }
}