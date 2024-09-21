using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Operators.StringValue
{
    /// <summary>
    /// Represents the operator overloads for addition operations involving String values.
    /// </summary>
    public class StringValuePlusOperatorOverloads : OperatorsOverload
    {
        /// <summary>
        /// Gets a dictionary of functions that handle addition operations for different token types.
        /// </summary>
        /// <returns>A dictionary of functions.</returns>
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.String, StringPlusString);
                overloads.Add(TokenType.Byte, StringPlusString);
                overloads.Add(TokenType.Integer, StringPlusString);
                overloads.Add(TokenType.Long, StringPlusString);
                overloads.Add(TokenType.Decimal, StringPlusString);
                overloads.Add(TokenType.Double, StringPlusString);
                overloads.Add(TokenType.Float, StringPlusString);
                overloads.Add(TokenType.NULL, StringMathNull);
            }

            return base.GetOverloads();
        }

        /// <summary>
        /// Handles the case where one operand is String and the other is null.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the addition operation.</returns>
        private static Token StringMathNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return MathFunctionUtils.NullCheck(a2, executionOptions.NullStrategy);
        }

        /// <summary>
        /// Handles the case where both operands are Strings (for concatenation).
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the concatenation operation.</returns>
        private static Token StringPlusString(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToString(a1.Value);
            var arg2 = Convert.ToString(a2.Value);
            return new Token(arg1 + arg2, TokenType.String);
        }
    }
}