using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Operators.ByteValue
{
    /// <summary>
    /// Represents the operator overloads for subtraction operations involving Byte values.
    /// </summary>
    public class ByteValueMinusOperatorOverloads : OperatorsOverload
    {
        /// <summary>
        /// Gets a dictionary of functions that handle subtraction operations for different token types.
        /// </summary>
        /// <returns>A dictionary of functions.</returns>
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, ByteMinusByte);
                overloads.Add(TokenType.Integer, ByteMinusInteger);
                overloads.Add(TokenType.Long, ByteMinusLong);
                overloads.Add(TokenType.Decimal, ByteMinusDecimal);
                overloads.Add(TokenType.Double, ByteMinusDouble);
                overloads.Add(TokenType.Float, ByteMinusFloat);
                overloads.Add(TokenType.NULL, ByteMinusNull);
            }

            return base.GetOverloads();
        }

        /// <summary>
        /// Handles the case where one operand is Byte and the other is null.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the subtraction operation.</returns>
        private static Token ByteMinusNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        /// <summary>
        /// Handles the case where both operands are Byte.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the subtraction operation.</returns>
        private static Token ByteMinusByte(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            int arg2 = Convert.ToByte(a2.Value);
            return new Token(arg1 - arg2, TokenType.Integer);
        }

        /// <summary>
        /// Handles the case where one operand is Byte and the other is Integer.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the subtraction operation.</returns>
        private static Token ByteMinusInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 - arg2, TokenType.Integer);
        }

        /// <summary>
        /// Handles the case where one operand is Byte and the other is Long.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the subtraction operation.</returns>
        private static Token ByteMinusLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 - arg2, TokenType.Long);
        }

        /// <summary>
        /// Handles the case where one operand is Byte and the other is Decimal.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the subtraction operation.</returns>
        private static Token ByteMinusDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 - arg2, TokenType.Decimal);
        }

        /// <summary>
        /// Handles the case where one operand is Byte and the other is Double.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the subtraction operation.</returns>
        private static Token ByteMinusDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 - arg2, TokenType.Double);
        }

        /// <summary>
        /// Handles the case where one operand is Byte and the other is Float.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the subtraction operation.</returns>
        private static Token ByteMinusFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 - arg2, TokenType.Float);
        }
    }
}