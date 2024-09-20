using NeonBlue.Expressions.Functions.BooleanFunctions;

namespace NeonBlue.Expressions.Operators.DeicmalValue
{
    /// <summary>
    /// Represents the operator overloads for inequality comparisons involving Decimal values.
    /// </summary>
    public class DecimalValueNotEqualOperatorOverloads : OperatorsOverload
    {
        /// <summary>
        /// Gets a dictionary of functions that handle inequality comparisons for different token types.
        /// </summary>
        /// <returns>A dictionary of functions.</returns>
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, DecimalNotEqualInteger);
                overloads.Add(TokenType.Integer, DecimalNotEqualInteger);
                overloads.Add(TokenType.Long, DecimalNotEqualLong);
                overloads.Add(TokenType.Decimal, DecimalNotEqualDecimal);
                overloads.Add(TokenType.Double, DecimalNotEqualDouble);
                overloads.Add(TokenType.Float, DecimalNotEqualFloat);
                overloads.Add(TokenType.NULL, DecimalLogicalOpNull);
            }

            return base.GetOverloads();
        }

        /// <summary>
        /// Handles the case where one operand is Decimal and the other is null.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the inequality comparison.</returns>
        private static Token DecimalLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        /// <summary>
        /// Handles the case where one operand is Decimal and the other is Integer.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the inequality comparison.</returns>
        private static Token DecimalNotEqualInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 != arg2, TokenType.Boolean);
        }

        /// <summary>
        /// Handles the case where one operand is Decimal and the other is Long.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the inequality comparison.</returns>
        private static Token DecimalNotEqualLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 != arg2, TokenType.Boolean);
        }

        /// <summary>
        /// Handles the case where both operands are Decimal.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the inequality comparison.</returns>
        private static Token DecimalNotEqualDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 != arg2, TokenType.Boolean);
        }

        /// <summary>
        /// Handles the case where one operand is Decimal and the other is Double.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the inequality comparison.</returns>
        private static Token DecimalNotEqualDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 != (decimal)arg2, TokenType.Boolean);
        }

        /// <summary>
        /// Handles the case where one operand is Decimal and the other is Float.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the inequality comparison.</returns>
        private static Token DecimalNotEqualFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDecimal(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 != (decimal)arg2, TokenType.Boolean);
        }
    }
}