using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Operators.IntegerValue
{
    /// <summary>
    /// Represents the operator overloads for division operations involving Integer values.
    /// </summary>
    public class IntegerValueDivideOperatorOverloads : OperatorsOverload
    {
        /// <summary>
        /// Gets a dictionary of functions that handle division operations for different token types.
        /// </summary>
        /// <returns>A dictionary of functions.</returns>
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Integer, IntegerDivideInteger);
                overloads.Add(TokenType.Byte, IntegerDivideInteger);
                overloads.Add(TokenType.Long, IntegerDivideLong);
                overloads.Add(TokenType.Decimal, IntegerDivideDecimal);
                overloads.Add(TokenType.Double, IntegerDivideDouble);
                overloads.Add(TokenType.Float, IntegerDivideFloat);
                overloads.Add(TokenType.NULL, IntegerMathNull);
            }

            return base.GetOverloads();
        }

        /// <summary>
        /// Handles the case where one operand is Integer and the other is null.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the division operation.</returns>
        private static Token IntegerMathNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        /// <summary>
        /// Handles the case where both operands are Integer.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the division operation.</returns>
        private static Token IntegerDivideInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 / arg2, TokenType.Integer);
        }

        /// <summary>
        /// Handles the case where one operand is Integer and the other is Long.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the division operation.</returns>
        private static Token IntegerDivideLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 / arg2, TokenType.Long);
        }

        /// <summary>
        /// Handles the case where one operand is Integer and the other is Decimal.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the division operation.</returns>
        private static Token IntegerDivideDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            decimal arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 / arg2, TokenType.Decimal);
        }

        /// <summary>
        /// Handles the case where one operand is Integer and the other is Double.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the division operation.</returns>
        private static Token IntegerDivideDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 / arg2, TokenType.Double);
        }

        /// <summary>
        /// Handles the case where one operand is Integer and the other is Float.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the division operation.</returns>
        private static Token IntegerDivideFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToInt32(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 / arg2, TokenType.Float);
        }
    }
}