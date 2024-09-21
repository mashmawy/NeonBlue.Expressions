using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Operators.DoubleValue
{
    /// <summary>
    /// Represents the operator overloads for the power operator (^) when the left operand is a double value.
    /// </summary>
    public class DoubleValuePowerOperatorOverloads : OperatorsOverload
    {
        /// <summary>
        /// Gets the dictionary of overloads for the power operator.
        /// </summary>
        /// <returns>The dictionary of overloads.</returns>
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            // Ensure the overloads are populated only once
            if (overloads.Count == 0)
            {
                // Add overloads for valid operand types
                overloads.Add(TokenType.Byte, PowerOperatorHelper.Power);
                overloads.Add(TokenType.Integer, PowerOperatorHelper.Power);
                overloads.Add(TokenType.Long, PowerOperatorHelper.Power);
                overloads.Add(TokenType.Decimal, PowerOperatorHelper.Power);
                overloads.Add(TokenType.Double, PowerOperatorHelper.Power);
                overloads.Add(TokenType.Float, PowerOperatorHelper.Power);
                overloads.Add(TokenType.NULL, DoublePowerNull);
            }

            // Return the dictionary of overloads
            return base.GetOverloads();
        }
        /// <summary>
        /// Handles the case where one operand is Double and the other is null.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the power operation.</returns>
        private static Token DoublePowerNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }
    }
}