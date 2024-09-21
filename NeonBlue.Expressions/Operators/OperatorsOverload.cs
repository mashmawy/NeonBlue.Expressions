namespace NeonBlue.Expressions.Operators
{
    /// <summary>
    /// Represents the base class for operator overloading.
    /// </summary>
    public abstract class OperatorsOverload
    {
        /// <summary>
        /// A dictionary mapping token types to functions that handle specific operations.
        /// </summary>
        protected readonly Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> overloads = new();

        /// <summary>
        /// Gets the dictionary of overloads.
        /// </summary>
        /// <returns>The dictionary of overloads.</returns>
        public virtual Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            return overloads;
        }

        /// <summary>
        /// Evaluates the operation based on the operand types and the provided execution options.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the operation.</returns>
        public Token Evaluate(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            if (GetOverloads().TryGetValue(a2.TokenType, out var overload))
            {
                return overload.Invoke(a1, a2, executionOptions);
            }
            else
            {
                throw new InvalidOperationException($" {a1.TokenType} has no overload for type {a2.TokenType}");
            }
        }
    }
}