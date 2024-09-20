namespace NeonBlue.Expressions.Functions.BooleanFunctions
{
    public class NotFunction : StackUpdateFunction
    {
        public override string FunctionName => "not";

        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 1)
            {
                throw new EmptyStackException();
            }
            var token1 = x.Pop();
            if (BooleanFunctionsUtils.NullCheck(x, token1, executionOptions.NullStrategy)) return;

            var arg1 = Convert.ToBoolean(token1.Value);
            x.Push(new Token(!arg1, TokenType.Boolean));

        }
    }
}