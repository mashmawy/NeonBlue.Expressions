using NeonBlue.Expressions.Functions.BooleanFunctions;

namespace NeonBlue.Expressions.Operators.DoubleValue
{
    /// <summary>
    /// Represents the operator overloads for greater than or equal to comparisons involving Double values.
    /// </summary>
    public class DoubleValueGreaterThanOrEqualOperatorOverloads : OperatorsOverload
    {
        /// <summary>
        /// Gets a dictionary of functions that handle greater than or equal to comparisons for different token types.
        /// </summary>
        /// <returns>A dictionary of functions.</returns>
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, DoubleGreaterThanOrEqualInteger);
                overloads.Add(TokenType.Integer, DoubleGreaterThanOrEqualInteger);
                overloads.Add(TokenType.Long, DoubleGreaterThanOrEqualLong);
                overloads.Add(TokenType.Decimal, DoubleGreaterThanOrEqualDecimal);
                overloads.Add(TokenType.Double, DoubleGreaterThanOrEqualDouble);
                overloads.Add(TokenType.Float, DoubleGreaterThanOrEqualFloat);
                overloads.Add(TokenType.NULL, DoubleLogicalOpNull);
            }

            return base.GetOverloads();
        }

        /// <summary>
        /// Handles the case where one operand is Double and the other is null.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the greater than or equal to comparison.</returns>
        private static Token DoubleLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        /// <summary>
        /// Handles the case where one operand is Double and the other is Integer.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the greater than or equal to comparison.</returns>
        private static Token DoubleGreaterThanOrEqualInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }

        /// <summary>
        /// Handles the case where one operand is Double and the other is Long.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the greater than or equal to comparison.</returns>
        private static Token DoubleGreaterThanOrEqualLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }

        /// <summary>
        /// Handles the case where one operand is Double and the other is Decimal.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the greater than or equal to comparison.</returns>
        private static Token DoubleGreaterThanOrEqualDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token((decimal)arg1 >= arg2, TokenType.Boolean);
        }

        /// <summary>
        /// Handles the case where both operands are Double.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the greater than or equal to comparison.</returns>
        private static Token DoubleGreaterThanOrEqualDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }

        /// <summary>
        /// Handles the case where one operand is Double and the other is Float.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the greater than or equal to comparison.</returns>
        private static Token DoubleGreaterThanOrEqualFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 >= arg2, TokenType.Boolean);
        }
    }
}