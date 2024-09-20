namespace NeonBlue.Expressions.Functions
{
    /// <summary>
    /// Defines the contract for functions that can update a stack of tokens.
    /// </summary>
    public interface IStackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        string FunctionName { get; }

        
        /// <summary>
        /// Updates the given stack of tokens based on the function's logic.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        void Update(Stack<Token> tokensStack, IExecutionOptions executionOptions);
    }
}