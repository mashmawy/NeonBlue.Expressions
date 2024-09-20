using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.DateFunctions
{
    public class QuarterFunction : StackUpdateFunction
    {
        public override string FunctionName => "quarter";
        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 1)
            {
                throw new EmptyStackException();
            }
            var token1 = x.Pop();

            if (DateFunctionsUtils.NullCheck(x, token1, executionOptions)) return;
            if (token1.TokenType != TokenType.Datetime)
            {
                throw new InvalidArgumentTypeException(FunctionName, typeof(DateTime));
            }
            var arg1 = Convert.ToDateTime(token1.Value);
            int res;
            if (arg1.Month is >= 1 and <= 3)
            {
                res = 1;
            }
            else if (arg1.Month is >= 4 and <= 6)
            {
                res = 2;
            }
            else if (arg1.Month is >= 7 and <= 9)
            {
                res = 3;
            }
            else
            {
                res = 4;
            }
            x.Push(new Token(res));

        }
    }
}