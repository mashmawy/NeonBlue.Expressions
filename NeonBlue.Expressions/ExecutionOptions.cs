namespace NeonBlue.Expressions
{
    public interface IExecutionOptions
    {
        public NullStrategy NullStrategy { get; }
    }
    public class ExecutionOptions(NullStrategy nullStrategy) : IExecutionOptions
    {
        public NullStrategy NullStrategy { get; private set; } = nullStrategy;
    }
    public enum NullStrategy
    {

        Propagate,
        Throw,
        Default,
    }

}