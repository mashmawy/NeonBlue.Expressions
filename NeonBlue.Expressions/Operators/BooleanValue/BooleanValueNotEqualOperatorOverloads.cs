namespace NeonBlue.Expressions.Operators.BooleanValue
{
    /// <summary>
    /// Represents the operator overloads for inequality comparisons involving Boolean values.
    /// </summary>
    public class BooleanValueNotEqualOperatorOverloads : OperatorsOverload
    {
        /// <summary>
        /// Gets a dictionary of functions that handle inequality comparisons for different token types.
        /// </summary>
        /// <returns>A dictionary of functions.</returns>
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Boolean, BooleanNotEqualBoolean);
                overloads.Add(TokenType.NULL, BooleanNotEqualNull);
            }

            return base.GetOverloads();
        }

        /// <summary>
        /// Handles the case where one operand is null.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the inequality comparison.</returns>
        private static Token BooleanNotEqualNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            if (executionOptions.NullStrategy == NullStrategy.Default)
            {
                return a1;
            }
            else if (executionOptions.NullStrategy == NullStrategy.Propagate)
            {
                return new Token(null, TokenType.NULL);
            }
            else
            {
                throw new NullTokenException(a2);
            }
        }

        /// <summary>
        /// Handles the case where both operands are Boolean.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the inequality comparison.</returns>
        private static Token BooleanNotEqualBoolean(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToBoolean(a1.Value);
            var arg2 = Convert.ToBoolean(a2.Value);
            var res = arg1 != arg2;

            return new Token(res, TokenType.Boolean);
        }
    }
}