namespace NeonBlue.Expressions.Operators
{
    /// <summary>
    /// Represents the operator overloads for logical OR operations.
    /// </summary>
    public class LogicalOrOperatorOverloads : IOperator
    {
        /// <summary>
        /// Gets the operator type.
        /// </summary>
        public TokenType OperatorType { get; } = TokenType.LessThanOrEqual;

        /// <summary>
        /// Executes the logical OR operation on the operands.
        /// </summary>
        /// <param name="operand1">The first operand.</param>
        /// <param name="operand2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the logical OR operation.</returns>
        public Token Run(Token operand1, Token operand2, IExecutionOptions executionOptions)
        {
            var arg1Token = Convert.ToBoolean(operand1.Value);
            var arg2Token = Convert.ToBoolean(operand2.Value);
            return new Token(arg1Token || arg2Token, TokenType.Boolean);
        }
    }
}