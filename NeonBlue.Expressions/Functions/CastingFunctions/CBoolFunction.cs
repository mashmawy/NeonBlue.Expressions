namespace NeonBlue.Expressions.Functions.CastingFunctions
{
    /// <summary>
    /// Conversions to Boolean function
    /// </summary>
    public class CBoolFunction : StackUpdateFunction
    {
        public override string FunctionName => "cbool";

        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 1)
            {
                throw new EmptyStackException();
            }
            var arg1 = x.Pop();
            if (CastingFunctionsUtils.NullCheck(x, arg1, new Token(false, TokenType.Boolean), executionOptions))
            {
                return;
            }
            try
            {
                x.Push(new Token(Convert.ToBoolean(arg1.Value)));
            }
            catch (Exception ex)
            {
                throw new CastingException($"Can't cast input of type {arg1.TokenType} to boolean, see inner exception", ex);
            }
        }
    }

}