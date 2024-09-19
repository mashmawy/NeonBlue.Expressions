using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.StringFunctions
{
    public class CapFunction : StackUpdateFunction
    {
        public override string FunctionName => "cap";
        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 1)
            {
                throw new EmptyStackExecption();
            }
            var token = x.Pop();

            if (StringFunctionsHelper.NullCheck(x, token, executionOptions)) return;
            try
            {

                var arg1 = token.Value!.ToString();
                x.Push(new Token(FirstCharToUpper(arg1!.ToLower())));
            }
            catch (Exception ex)
            {
                throw new StringException(FunctionName, $"String operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }

        }
        static string FirstCharToUpper(string input) =>
                     input switch
                     {
                         null => throw new ArgumentNullException(nameof(input)),
                         "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                         _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
                     };
    }
}