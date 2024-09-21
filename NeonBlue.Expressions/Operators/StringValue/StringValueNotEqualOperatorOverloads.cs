using NeonBlue.Expressions.Functions.BooleanFunctions;

namespace NeonBlue.Expressions.Operators.StringValue
{
    /// <summary>
    /// Represents the operator overloads for inequality comparisons involving String values.
    /// </summary>
    public class StringValueNotEqualOperatorOverloads : OperatorsOverload
    {
        /// <summary>
        /// Gets a dictionary of functions that handle inequality comparisons for different token types.
        /// </summary>
        /// <returns>A dictionary of functions.</returns>
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.String, StringNotEqualString);
                overloads.Add(TokenType.NULL, StringLogicalOpNull);
            }

            return base.GetOverloads();
        }

        /// <summary>
        /// Handles the case where one operand is String and the other is null.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the inequality comparison.</returns>
        private static Token StringLogicalOpNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        /// <summary>
        /// Handles the case where both operands are Strings.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the inequality comparison.</returns>
        private static Token StringNotEqualString(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = a1.Value as string;
            var arg2 = Convert.ToString(a2.Value);
            var res = arg1 != arg2;
            return new Token(res, TokenType.Boolean);
        }
    }
}