using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.MathFunctions
{
    public class PowFunction : StackUpdateFunction
    {
        public override string FunctionName => "pow";
        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 2)
            {
                throw new EmptyStackExecption();
            }
            var arg2 = x.Pop();
            var arg1 = x.Pop();

            if (MathFunctionUtils.NullCheck(x, arg2, executionOptions.NullStrategy)) return;
            if (MathFunctionUtils.NullCheck(x, arg1, executionOptions.NullStrategy)) return;
            if (!TokensUtils.IsNumeric(arg1.TokenType) || !TokensUtils.IsNumeric(arg2.TokenType))
            {
                throw new InvalidArgumentTypeExeception(FunctionName, arg1.GetType());
            }

            try
            {
                var arg2val = Convert.ToDouble(arg2.Value);


                var arg1val = Convert.ToDouble(arg1.Value);
                x.Push(new Token(Math.Pow(arg1val, arg2val)));
            }
            catch (Exception ex)
            {
                throw new MathException(FunctionName, $"Math operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }




        }

    }
}