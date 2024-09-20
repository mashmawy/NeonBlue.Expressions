namespace NeonBlue.Expressions.Functions.CastingFunctions
{
    public class CDateTimeFunction : StackUpdateFunction
    {
        public override string FunctionName => "cdatetime";

        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 1)
            {
                throw new EmptyStackException();
            }
            var arg1 = x.Pop();
            if (CastingFunctionsUtils.NullCheck(x, arg1, new Token(null), executionOptions))
            {
                return;
            }
            try
            {
                x.Push(new Token(Convert.ToDateTime(arg1.Value)));
            }
            catch (Exception ex)
            {
                throw new CastingException($"Can't cast input of type {arg1.TokenType} to datetime, see inner exception", ex);
            }
        }
    }

}