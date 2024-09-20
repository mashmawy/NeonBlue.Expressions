using NeonBlue.Expressions.Functions.BooleanFunctions;
using static System.Collections.Specialized.BitVector32;

namespace NeonBlue.Expressions.Operators.FloatValue
{
    /// <summary>
    /// Represents the operator overloads for equality comparisons involving Float values.
    /// </summary>
    public class FloatValueEqualOperatorOverloads : OperatorsOverload
    {
        static readonly float epsilon = 1E-6f;
        /// <summary>
        /// Gets a dictionary of functions that handle equality comparisons for different token types.
        /// </summary>
        /// <returns>A dictionary of functions.</returns>
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, FloatEqualInteger);
                overloads.Add(TokenType.Integer, FloatEqualInteger);
                overloads.Add(TokenType.Long, FloatEqualLong);
                overloads.Add(TokenType.Decimal, FloatEqualDecimal);
                overloads.Add(TokenType.Double, FloatEqualDouble);
                overloads.Add(TokenType.Float, FloatEqualFloat);
                overloads.Add(TokenType.NULL, FloatLogicalOpNull);
            }

            return base.GetOverloads();
        }

        /// <summary>
        /// Handles the case where one operand is Float and the other is null.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the equality comparison.</returns>
        private static Token FloatLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        /// <summary>
        /// Handles the case where one operand is Float and the other is Integer.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the equality comparison.</returns>
        private static Token FloatEqualInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToSingle(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(Math.Abs(arg1 - arg2) < epsilon, TokenType.Boolean);
        }

        /// <summary>
        /// Handles the case where one operand is Float and the other is Long.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the equality comparison.</returns>
        private static Token FloatEqualLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToSingle(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(Math.Abs(arg1 - arg2) < epsilon, TokenType.Boolean);
        }

        /// <summary>
        /// Handles the case where one operand is Float and the other is Decimal.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the equality comparison.</returns>
        private static Token FloatEqualDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToSingle(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token((decimal)arg1 == arg2, TokenType.Boolean);
        }

        /// <summary>
        /// Handles the case where one operand is Float and the other is Double.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the equality comparison.</returns>
        private static Token FloatEqualDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToSingle(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(Math.Abs(arg1 - arg2) < epsilon, TokenType.Boolean);
        }

        /// <summary>
        /// Handles the case where both operands are Float.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the equality comparison.</returns>
        private static Token FloatEqualFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToSingle(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(Math.Abs(arg1 - arg2) < epsilon, TokenType.Boolean);
        }




    }



}