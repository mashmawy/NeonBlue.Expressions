namespace NeonBlue.Expressions.Functions.MathFunctions
{
    public class AtanFunction : StackUpdateFunction
    {
        public override string FunctionName => "atan";

        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 1)
            {
                throw new EmptyStackException();
            }
            var token = x.Pop();
            if (MathFunctionUtils.NullCheck(x, token, executionOptions.NullStrategy)) return;
            if (!TokensUtils.IsNumeric(token.TokenType))
            {
                throw new InvalidArgumentTypeException(FunctionName, typeof(DateTime));
            }


            try
            {

                var val = Convert.ToDouble(token.Value);
                x.Push(new Token(Math.Atan(val)));


            }
            catch (Exception ex)
            {
                throw new MathException(FunctionName, $"Math operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }
        }
    }


}