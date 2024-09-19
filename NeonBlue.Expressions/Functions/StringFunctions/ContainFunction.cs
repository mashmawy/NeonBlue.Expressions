using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.StringFunctions
{
    public class ContainFunction : StackUpdateFunction
    {
        public override string FunctionName => "contain";
        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 2)
            {
                throw new EmptyStackException();
            }
            var token2 = x.Pop();
            var token1 = x.Pop();
            if (StringFunctionsHelper.NullCheck(x, token1, executionOptions)) return;
            if (StringFunctionsHelper.NullCheck(x, token2, executionOptions)) return;
            try
            {
                var arg2 = token2.Value!.ToString();
                var arg1 = token1.Value!.ToString();
                x.Push(new Token(arg1!.Contains(arg2!)));
            }
            catch (Exception ex)
            {
                throw new StringException(FunctionName, $"String operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }

        }
    }
}