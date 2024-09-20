namespace NeonBlue.Expressions.Functions
{
    public interface IStackUpdateFunction
    {
        string FunctionName { get; }
        List<StackUpdateFunctionParameter> Parameters { get; set; }

        void Update(Stack<Token> x, IExecutionOptions executionOptions);
    }
}