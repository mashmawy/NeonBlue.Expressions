namespace NeonBlue.Expressions.Operators
{
    /// <summary>
    /// Represents the operator overloads for logical NOT operations.
    /// </summary>
    public class LogicalNotOperatorOverloads : IOperator
    {
        /// <summary>
        /// Gets the operator type.
        /// </summary>
        public TokenType OperatorType { get; } = TokenType.LessThanOrEqual;

        /// <summary>
        /// Executes the logical NOT operation on the operand.
        /// </summary>
        /// <param name="operand1">The operand.</param>
        /// <param name="operand2">The second operand (optional for unary operators).</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the logical NOT operation.</returns>
        public Token Run(Token operand1, Token? operand2, IExecutionOptions executionOptions)
        {
            var arg1Token = Convert.ToBoolean(operand1.Value);
            return new Token(!arg1Token, TokenType.Boolean);
        }
    }
}