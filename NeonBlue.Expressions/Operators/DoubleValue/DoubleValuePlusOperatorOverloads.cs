using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Operators.DoubleValue
{
    /// <summary>
    /// Represents the operator overloads for addition operations involving Double values.
    /// </summary>
    public class DoubleValuePlusOperatorOverloads : OperatorsOverload
    {
        /// <summary>
        /// Initializes a new instance of the DoubleValuePlusOperatorOverloads class.
        /// </summary>
        public DoubleValuePlusOperatorOverloads()
        {
            // Pre-populate the overloads dictionary to avoid redundant calculations
            GetOverloads();
        }

        /// <summary>
        /// Gets a dictionary of functions that handle addition operations for different token types.
        /// </summary>
        /// <returns>A dictionary of functions.</returns>
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, DoublePlusInteger);
                overloads.Add(TokenType.Integer, DoublePlusInteger);
                overloads.Add(TokenType.Long, DoublePlusLong);
                overloads.Add(TokenType.Decimal, DoublePlusDecimal);
                overloads.Add(TokenType.Double, DoublePlusDouble);
                overloads.Add(TokenType.Float, DoublePlusFloat);
                overloads.Add(TokenType.String, DoublePlusString);
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
        /// <returns>The result of the addition operation.</returns>
        public static Token DoubleMathNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        /// <summary>
        /// Handles the case where one operand is Double and the other is Integer.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the addition operation.</returns>
        public static Token DoublePlusInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 + arg2, TokenType.Double);
        }

        /// <summary>
        /// Handles the case where one operand is Double and the other is Long.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the addition operation.</returns>
        public static Token DoublePlusLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 + arg2, TokenType.Double);
        }

        /// <summary>
        /// Handles the case where both operands are Decimal.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the addition operation.</returns>
        public static Token DoublePlusDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token((decimal)arg1 + arg2, TokenType.Decimal);
        }

        /// <summary>
        /// Handles the case where both operands are Double.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the addition operation.</returns>
        public static Token DoublePlusDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 + arg2, TokenType.Double);
        }

        /// <summary>
        /// Handles the case where one operand is Decimal and the other is Float.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the addition operation.</returns>
        public static Token DoublePlusFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 +  arg2, TokenType.Double);
        }

        /// <summary>
        /// Handles the case where one operand is Decimal and the other is String (for concatenation).
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the concatenation operation.</returns>
        public static Token DoublePlusString(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            var arg2 = Convert.ToString(a2.Value);
            return new Token((arg1 + arg2).ToString(), TokenType.String);
        }
    }
}