namespace NeonBlue.Expressions
{
    public interface IExecutionOptions
    {
        public NullStrategy NullStrategy { get; }
    }
    public class ExecutionOptions : IExecutionOptions
    {
        public NullStrategy NullStrategy { get; private set; }
        public ExecutionOptions(NullStrategy nullStrategy)
        {
            NullStrategy = nullStrategy;
        }
    }
    public enum NullStrategy
    {

        Propagate,
        Throw,
        Default,
    }

}