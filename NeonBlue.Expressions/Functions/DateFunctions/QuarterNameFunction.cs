using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.DateFunctions
{
    public class QuarterNameFunction : StackUpdateFunction
    {
        public override string FunctionName => "quartername";
        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 1)
            {
                throw new EmptyStackExecption();
            }
            var token1 = x.Pop();

            if (DateFunctionsUtils.NullCheck(x, token1, executionOptions)) return;
            if (token1.TokenType != TokenType.Datetime)
            {
                throw new InvalidArgumentTypeExeception(FunctionName, typeof(DateTime));
            }
            var arg1 = Convert.ToDateTime(token1.Value);
            string res;
            if (arg1.Month is >= 1 and <= 3)
            {
                res = "Q1";
            }
            else if (arg1.Month is >= 4 and <= 6)
            {
                res = "Q2";
            }
            else if (arg1.Month is >= 7 and <= 9)
            {
                res = "Q3";
            }
            else
            {
                res = "Q4";
            }
            x.Push(new Token(res));

        }
    }
}