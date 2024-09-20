using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.StringFunctions
{
    public class SubstringFunction : StackUpdateFunction
    {
        public override string FunctionName => "substring";
        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {

            // var token3 = x.Pop();
            // var token2 = x.Pop();
            // var token1 = x.Pop();
            // if (StringFunctionsHelper.NullCheck(x, token1,executionOptions)) return;
            // if (StringFunctionsHelper.NullCheck(x, token2,executionOptions)) return;
            // if (StringFunctionsHelper.NullCheck(x, token3,executionOptions)) return;

            // var arg3 = Convert.ToInt32(token3.Value);
            // var arg2 = Convert.ToInt32(token2.Value);
            // var arg1 = token1.ToString();
            // x.Push(new Token(arg1.Substring(arg2, arg3)));





            if (x is null || x.Count < 3)
            {
                throw new EmptyStackException();
            }
            var token3 = x.Pop();
            var token2 = x.Pop();
            var token1 = x.Pop();
            if (StringFunctionsHelper.NullCheck(x, token1, executionOptions)) return;
            if (StringFunctionsHelper.NullCheck(x, token2, executionOptions)) return;
            if (StringFunctionsHelper.NullCheck(x, token3, executionOptions)) return;
            if (!TokensUtils.IsNumeric(token2.TokenType))
            {
                throw new InvalidArgumentTypeException(FunctionName, typeof(int));
            }
            if (!TokensUtils.IsNumeric(token3.TokenType))
            {
                throw new InvalidArgumentTypeException(FunctionName, typeof(int));
            }
            try
            {
                var arg3 = Convert.ToInt32(token3.Value);
                var arg2 = Convert.ToInt32(token2.Value);
                var arg1 = token1.ToString();
                x.Push(new Token(arg1.Substring(arg2, arg3)));


            }
            catch (Exception ex)
            {
                throw new StringException(FunctionName, $"String operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }
        }
    }
}