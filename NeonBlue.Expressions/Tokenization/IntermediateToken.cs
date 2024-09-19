namespace NeonBlue.Expressions
{
    /// <summary>
    /// Represents a token in an intermediate representation of an expression.
    /// </summary>
    /// <param name="type">The type of the token.</param>
    /// <param name="value">The value of the token.</param>
    /// <param name="pos">The starting position of the token in the original expression.</param>

    public class IntermediateToken(IntermediateTokenType type, string value, int pos)
    {
        /// <summary>
        /// Gets the value of the token (e.g., "42", "X", "+").
        /// </summary>
        public string? Value { get; } = value;

        /// <summary>
        /// Gets the type of the token (e.g., Integer, Variable, Operator).
        /// </summary>
        public IntermediateTokenType TokenType { get; } = type;

        /// <summary>
        /// Gets the starting position of the token in the original expression.
        /// </summary>
        public int Pos { get; } = pos;

        /// <summary>
        /// Determines if the token represents a number.
        /// </summary>
        /// <returns>True if the token is a number; otherwise, false.</returns>
        internal bool IsNumber()
        {
            return TokenType == IntermediateTokenType.Double || TokenType == IntermediateTokenType.Integer || TokenType == IntermediateTokenType.Variable;
        }
    }
}