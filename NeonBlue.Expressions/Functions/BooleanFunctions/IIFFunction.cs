using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.BooleanFunctions
{
    public class IIFFunction : StackUpdateFunction
    {
        public override string FunctionName => "iif";

        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 3)
            {
                throw new EmptyStackExecption();
            }

            var token3 = x.Pop();
            var token2 = x.Pop();
            var token1 = x.Pop();

            if (BooleanFunctionsUtils.NullCheck(x, token1, NullStrategy.Throw)) return;
            BooleanFunctionsUtils.AssertBoolean(token1, FunctionName);
            var arg1 = Convert.ToBoolean(token1.Value);
            if (arg1)
            {
                x.Push(token2);
            }
            else
            {
                x.Push(token3);
            }

        }
    }
}