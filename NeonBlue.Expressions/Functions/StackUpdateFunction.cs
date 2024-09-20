namespace NeonBlue.Expressions.Functions
{
    /// <summary>
    /// Represents the base class for functions that can update a stack of tokens.
    /// </summary>
    public abstract class StackUpdateFunction : IStackUpdateFunction
    {
        protected StackUpdateFunction() { }

        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public abstract string FunctionName { get; }

        /// <summary>
        /// Updates the given stack of tokens based on the function's logic.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        public abstract void Update(Stack<Token> tokensStack, IExecutionOptions executionOptions);
         
    }
}