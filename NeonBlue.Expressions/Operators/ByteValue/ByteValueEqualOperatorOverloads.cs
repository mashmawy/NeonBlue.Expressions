﻿using NeonBlue.Expressions.Functions.BooleanFunctions;

namespace NeonBlue.Expressions.Operators.ByteValue
{
    /// <summary>
    /// Represents the operator overloads for equality comparisons involving Byte values.
    /// </summary>
    public class ByteValueEqualOperatorOverloads : OperatorsOverload
    {
        /// <summary>
        /// Gets a dictionary of functions that handle equality comparisons for different token types.
        /// </summary>
        /// <returns>A dictionary of functions.</returns>
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, ByteEqualInteger);
                overloads.Add(TokenType.Integer, ByteEqualInteger);
                overloads.Add(TokenType.Long, ByteEqualLong);
                overloads.Add(TokenType.Decimal, ByteEqualDecimal);
                overloads.Add(TokenType.Double, ByteEqualDouble);
                overloads.Add(TokenType.Float, ByteEqualFloat);
                overloads.Add(TokenType.NULL, ByteEqualNull);
            }

            return base.GetOverloads();
        }

        /// <summary>
        /// Handles the case where one operand is Byte and the other is Integer.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the equality comparison.</returns>
        private static Token ByteEqualInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 == (byte) arg2, TokenType.Boolean);
        }

        /// <summary>
        /// Handles the case where one operand is Byte and the other is Long.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the equality comparison.</returns>
        private static Token ByteEqualLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 == arg2, TokenType.Boolean);
        }

        /// <summary>
        /// Handles the case where one operand is Byte and the other is Decimal.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the equality comparison.</returns>
        private static Token ByteEqualDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            var arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 == arg2, TokenType.Boolean);
        }

        /// <summary>
        /// Handles the case where one operand is Byte and the other is Double.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the equality comparison.</returns>
        private static Token ByteEqualDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 == (byte)arg2, TokenType.Boolean);
        }

        /// <summary>
        /// Handles the case where one operand is Byte and the other is Float.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the equality comparison.</returns>
        private static Token ByteEqualFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 == (byte)arg2, TokenType.Boolean);
        }

        /// <summary>
        /// Handles the case where one operand is Byte and the other is null.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the equality comparison.</returns>
        private static Token ByteEqualNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
    }
}