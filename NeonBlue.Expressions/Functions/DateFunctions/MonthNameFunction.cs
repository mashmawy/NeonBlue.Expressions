using System.Globalization;
using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.DateFunctions
{
    public class MonthNameFunction : StackUpdateFunction
    {
        public override string FunctionName => "monthname";
        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 2)
            {
                throw new EmptyStackExecption();
            }
            var token2 = x.Pop();
            var token1 = x.Pop();

            if (DateFunctionsUtils.NullCheck(x, token1, executionOptions)) return;
            if (DateFunctionsUtils.NullCheck(x, token2, executionOptions)) return;
            if (token1.TokenType != TokenType.Datetime)
            {
                throw new InvalidArgumentTypeExeception(FunctionName, typeof(DateTime));
            }

            var arg1 = Convert.ToDateTime(token1.Value);
            var arg2 = Convert.ToString(token2.Value);

            try
            {
                x.Push(new Token(arg1.ToString("MMMM", CultureInfo.CreateSpecificCulture(arg2!))));

            }
            catch (Exception ex)
            {
                throw new InvalidArgumentTypeExeception(FunctionName, typeof(DateTime), "Invalid date culture", ex);
            }
        }
    }
}