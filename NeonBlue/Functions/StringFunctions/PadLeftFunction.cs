using NeonBlue.Expressions;
using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.StringFunctions
{
    public class PadLeftFunction : StackUpdateFunction
    {
        public override string FunctionName => "padleft";
        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 3)
            {
                throw new EmptyStackExecption();
            }
            var token3 = x.Pop();
            var token2 = x.Pop();
            var token1 = x.Pop();
            if (StringFunctionsHelper.NullCheck(x, token1, executionOptions)) return;
            if (StringFunctionsHelper.NullCheck(x, token2, executionOptions)) return;
            if (StringFunctionsHelper.NullCheck(x, token3, executionOptions)) return;

            if (!TokensUtils.IsNumeric(token2.TokenType))
            {
                throw new InvalidArgumentTypeExeception(FunctionName, typeof(int));
            }


            try
            {
                var arg3 = token3.Value!.ToString();
                var arg2 = Convert.ToInt32(token2.Value);
                var arg1 = token1.Value!.ToString();
                x.Push(new Token(arg1!.PadLeft(arg2, arg3![0]), TokenType.String));
            }
            catch (Exception ex)
            {
                throw new StringException(FunctionName, $"String operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }


        }
    }
}