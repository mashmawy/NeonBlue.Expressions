using NeonBlue.Expressions.Functions.BooleanFunctions;

namespace NeonBlue.Expressions.Operators.DatetimeValue
{
    /// <summary>
    /// Represents the operator overloads for equality comparisons involving DateTime values.
    /// </summary>
    public class DatetimeValueEqualOperatorOverloads : OperatorsOverload
    {
        /// <summary>
        /// Gets a dictionary of functions that handle equality comparisons for different token types.
        /// </summary>
        /// <returns>A dictionary of functions.</returns>
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Datetime, DatetimeEqualDatetime);
                overloads.Add(TokenType.NULL, DatetimeEqualNull);
            }

            return base.GetOverloads();
        }

        /// <summary>
        /// Handles the case where one operand is null.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the equality comparison.</returns>
        private static Token DatetimeEqualNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        /// <summary>
        /// Handles the case where both operands are DateTime.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the equality comparison.</returns>
        private static Token DatetimeEqualDatetime(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDateTime(a1.Value);
            var arg2 = Convert.ToDateTime(a2.Value);
            var res = arg1 == arg2;
            return new Token(res, TokenType.Boolean);
        }
    }
}