namespace NeonBlue.Expressions.Functions.DateFunctions
{
    public class AddDaysFunction : StackUpdateFunction
    {
        public override string FunctionName => "adddays";
        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 2)
            {
                throw new EmptyStackException();
            }
            var token2 = x.Pop();

            var token1 = x.Pop();

            if (DateFunctionsUtils.NullCheck(x, token1, executionOptions)) return;
            if (DateFunctionsUtils.NullCheck(x, token2, executionOptions)) return;
            if (token1.TokenType != TokenType.Datetime)
            {
                throw new InvalidArgumentTypeException(FunctionName, typeof(DateTime));
            }

            var arg2 = Convert.ToDouble(token2.Value);
            var arg1 = Convert.ToDateTime(token1.Value);
            x.Push(new Token(arg1.AddDays(arg2)));

        }




    }
}