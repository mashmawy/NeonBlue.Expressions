namespace NeonBlue.Expressions.Functions
{
    public abstract class StackUpdateFunction : IStackUpdateFunction
    {
        public StackUpdateFunction() { }

        public abstract string FunctionName { get; }

        public abstract void Update(Stack<Token> x, IExecutionOptions executionOptions);

        public List<StackUpdateFunctionParameter> Parameters { get; set; } = [];






    }
}