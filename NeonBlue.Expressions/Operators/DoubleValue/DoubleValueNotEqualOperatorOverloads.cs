using NeonBlue.Expressions.Functions.BooleanFunctions;

namespace NeonBlue.Expressions.Operators.DoubleValue
{
    /// <summary>
    /// Represents the operator overloads for inequality comparisons involving Double values.
    /// </summary>
    public class DoubleValueNotEqualOperatorOverloads : OperatorsOverload
    {
        private readonly static double epsilon = 1E-6;
        /// <summary>
        /// Gets a dictionary of functions that handle inequality comparisons for different token types.
        /// </summary>
        /// <returns>A dictionary of functions.</returns>
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, DoubleNotEqualInteger);
                overloads.Add(TokenType.Integer, DoubleNotEqualInteger);
                overloads.Add(TokenType.Long, DoubleNotEqualLong);
                overloads.Add(TokenType.Decimal, DoubleNotEqualDecimal);
                overloads.Add(TokenType.Double, DoubleNotEqualDouble);
                overloads.Add(TokenType.Float, DoubleNotEqualFloat);
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
        /// <returns>The result of the inequality comparison.</returns>
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
        /// <returns>The result of the inequality comparison.</returns>
        private static Token DoubleNotEqualInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(Math.Abs(arg1 - arg2) >= epsilon, TokenType.Boolean);
        }

        /// <summary>
        /// Handles the case where one operand is Double and the other is Long.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the inequality comparison.</returns>
        private static Token DoubleNotEqualLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(Math.Abs(arg1 - arg2) >= epsilon, TokenType.Boolean);
        }

        /// <summary>
        /// Handles the case where one operand is Double and the other is Decimal.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the inequality comparison.</returns>
        private static Token DoubleNotEqualDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token((decimal)arg1 != arg2, TokenType.Boolean);
        }

        /// <summary>
        /// Handles the case where both operands are Double.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the inequality comparison.</returns>
        private static Token DoubleNotEqualDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(Math.Abs(arg1 - arg2) >= epsilon, TokenType.Boolean);
        }

        /// <summary>
        /// Handles the case where one operand is Double and the other is Float.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the inequality comparison.</returns>
        private static Token DoubleNotEqualFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(Math.Abs(arg1 - arg2) >= epsilon, TokenType.Boolean);
        }
    }
}