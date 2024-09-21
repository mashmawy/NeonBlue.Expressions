namespace NeonBlue.Expressions
{
    /// <summary>
    /// Represents the execution options for expression evaluation.
    /// </summary>
    public interface IExecutionOptions
    {
        /// <summary>
        /// Gets the null strategy to be used during evaluation.
        /// </summary>
        NullStrategy NullStrategy { get; }
    }

    /// <summary>
    /// Concrete implementation of IExecutionOptions, providing null strategy options.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the ExecutionOptions class with the specified null strategy.
    /// </remarks>
    /// <param name="nullStrategy">The null strategy to use.</param>
    public class ExecutionOptions(NullStrategy nullStrategy) : IExecutionOptions
    {

        /// <summary>
        /// Gets or sets the null strategy to be used during evaluation.
        /// </summary>
        public NullStrategy NullStrategy { get; private set; } = nullStrategy;
    }

    /// <summary>
    /// Enum representing different null handling strategies.
    /// </summary>
    public enum NullStrategy
    {
        /// <summary>
        /// Propagate null values through the expression.
        /// </summary>
        Propagate,

        /// <summary>
        /// Throw an exception if a null value is encountered.
        /// </summary>
        Throw,

        /// <summary>
        /// Use the default null handling behavior.
        /// </summary>
        Default
    }

}