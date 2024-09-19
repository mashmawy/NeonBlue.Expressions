using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.StringFunctions
{
    public class LowerFunction : StackUpdateFunction
    {
        public override string FunctionName => "lower";
        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 1)
            {
                throw new EmptyStackExecption();
            }
            var token1 = x.Pop();
            if (StringFunctionsHelper.NullCheck(x, token1, executionOptions)) return;
            try
            {
                var arg1 = token1.Value!.ToString();
                x.Push(new Token(arg1!.ToLower()));
            }
            catch (Exception ex)
            {
                throw new StringException(FunctionName, $"String operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }
        }
    }
}