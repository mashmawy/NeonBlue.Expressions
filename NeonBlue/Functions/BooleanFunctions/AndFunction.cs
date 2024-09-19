using NeonBlue.Expressions;
using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.BooleanFunctions
{
    public class AndFunction : StackUpdateFunction
    {
        public override string FunctionName => "and";

        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x == null || x.Count < 2)
            {
                throw new EmptyStackExecption();
            }
            var token2 = x.Pop();
            var token1 = x.Pop();
            if (BooleanFunctionsUtils.NullCheck(x, token1, executionOptions.NullStrategy)) return;
            if (BooleanFunctionsUtils.NullCheck(x, token2, executionOptions.NullStrategy)) return;
            BooleanFunctionsUtils.AssertBoolean(token1, FunctionName);
            BooleanFunctionsUtils.AssertBoolean(token2, FunctionName);
            var arg1 = Convert.ToBoolean(token1.Value);
            var arg2 = Convert.ToBoolean(token2.Value);
            x.Push(new Token(arg1 && arg2, TokenType.Boolean));
        }
    }
}