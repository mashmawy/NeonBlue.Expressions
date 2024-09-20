using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Operators.DeicmalValue
{
    /// <summary>
    /// Represents the operator overloads for multiplication operations involving Decimal values.
    /// </summary>
    public class DecimalValueMultiplyOperatorOverloads : OperatorsOverload
    {
        /// <summary>
        /// Gets a dictionary of functions that handle multiplication operations for different token types.
        /// </summary>
        /// <returns>A dictionary of functions.</returns>
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, DeciamlMultiplyInteger);
                overloads.Add(TokenType.Integer, DeciamlMultiplyByte);
                overloads.Add(TokenType.Long, DeciamlMultiplyLong);
                overloads.Add(TokenType.Decimal, DeciamlMultiplyDecimal);
                overloads.Add(TokenType.Double, DeciamlMultiplyDouble);
                overloads.Add(TokenType.Float, DeciamlMultiplyFloat);
                overloads.Add(TokenType.NULL, DecimalMathNull);
            }

            return overloads;
        }

        /// <summary>
        /// Handles the case where one operand is Decimal and the other is null.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the multiplication operation.</returns>
        private static Token DecimalMathNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        /// <summary>
        /// Handles the case where one operand is Decimal and the other is Integer.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the multiplication operation.</returns>
        private static Token DeciamlMultiplyInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 * arg2, TokenType.Decimal);
        }

        /// <summary>
        /// Handles the case where one operand is Decimal and the other is Byte.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the multiplication operation.</returns>
        private static Token DeciamlMultiplyByte(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            int arg2 = Convert.ToByte(a2.Value);
            return new Token(arg1 * arg2, TokenType.Decimal);
        }

        /// <summary>
        /// Handles the case where one operand is Decimal and the other is Long.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the multiplication operation.</returns>
        private static Token DeciamlMultiplyLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 * arg2, TokenType.Decimal);
        }

        /// <summary>
        /// Handles the case where both operands are Decimal.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the multiplication operation.</returns>
        private static Token DeciamlMultiplyDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 * arg2, TokenType.Decimal);
        }

        /// <summary>
        /// Handles the case where one operand is Decimal and the other is Double.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the multiplication operation.</returns>
        private static Token DeciamlMultiplyDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 * (decimal)arg2, TokenType.Decimal);
        }

        /// <summary>
        /// Handles the case where one operand is Decimal and the other is Float.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the multiplication operation.</returns>
        private static Token DeciamlMultiplyFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 * (decimal)arg2, TokenType.Decimal);
        }
    }
}