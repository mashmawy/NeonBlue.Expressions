using NeonBlue.Expressions;
using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.StringFunctions
{
    public class RightFunction : StackUpdateFunction
    {
        public override string FunctionName => "right";
        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 2)
            {
                throw new EmptyStackExecption();
            }
            var token2 = x.Pop();
            var token1 = x.Pop();
            if (StringFunctionsHelper.NullCheck(x, token1, executionOptions)) return;
            if (StringFunctionsHelper.NullCheck(x, token2, executionOptions)) return;
            if (!TokensUtils.IsNumeric(token2.TokenType))
            {
                throw new InvalidArgumentTypeExeception(FunctionName, typeof(int));
            }

            try
            {
                var arg2 = Convert.ToInt32(token2.Value);
                var arg1 = token1.Value!.ToString();
                x.Push(new Token(arg1![(arg1!.Length - arg2)..]));
            }
            catch (Exception ex)
            {
                throw new StringException(FunctionName, $"String operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }
        }
    }
}


// static string _right(string value, int length)
// {
//     if (string.IsNullOrEmpty(value)) return string.Empty;

//     return value.Length <= length ? value : value.Substring(value.Length - length);
// }