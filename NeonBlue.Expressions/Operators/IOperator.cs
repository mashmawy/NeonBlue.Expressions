namespace NeonBlue.Expressions.Operators
{
    public interface IOperator
    {
        /// <summary>
        /// Gets the type of the operator.
        /// </summary>
        TokenType OperatorType { get; }

        /// <summary>
        /// Executes the operator on the given operands.
        /// </summary>
        /// <param name="operand1">The first operand.</param>
        /// <param name="operand2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the operation.</returns>
        Token Run(Token operand1, Token operand2, IExecutionOptions executionOptions);
    }
}