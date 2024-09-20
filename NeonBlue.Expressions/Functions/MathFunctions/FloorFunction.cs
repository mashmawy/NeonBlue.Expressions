namespace NeonBlue.Expressions.Functions.MathFunctions
{
    public class FloorFunction : StackUpdateFunction
    {
        public override string FunctionName => "floor";
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
                if (token.TokenType == TokenType.Decimal)
                {

                    var arg2val = Convert.ToDecimal(token.Value);
                    x.Push(new Token(Math.Floor(arg2val)));
                }
                else
                {
                    var arg2val = Convert.ToDouble(token.Value);
                    x.Push(new Token(Math.Floor(arg2val)));
                }
            }
            catch (Exception ex)
            {
                throw new MathException(FunctionName, $"Math operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }

        }
    }
}