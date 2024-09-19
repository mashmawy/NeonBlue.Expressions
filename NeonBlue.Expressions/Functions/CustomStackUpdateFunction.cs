using System.Reflection;
using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Functions
{
    public class CustomStackUpdateFunction : StackUpdateFunction
    {

        readonly Delegate _functionDeleget;
        readonly ParameterInfo[] _parameters;
        readonly string _functionName;
        public CustomStackUpdateFunction(string functionName, Delegate functionDeleget)
        {
            _functionDeleget = functionDeleget;
            _parameters = _functionDeleget.Method.GetParameters();
            _functionName = functionName;
        }
        public override string FunctionName => _functionName;

        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x == null || x.Count < _parameters.Length)
            {
                throw new EmptyStackException();
            }

            object?[] argumentStack = new object[_parameters.Length];


            try
            {
                for (int i = _parameters.Length - 1; i >= 0; i--)
                {
                    var token = x.Pop();
                    if (MathFunctionUtils.NullCheck(x, token, executionOptions.NullStrategy)) return;
                    argumentStack[i] = Convert.ChangeType(token.Value, _parameters[i].ParameterType);
                }
                var val = _functionDeleget.DynamicInvoke(argumentStack);
                if (val == null)
                {
                    x.Push(new Token(null, TokenType.NULL));
                }
                else
                {
                    x.Push(new Token(val, TokensUtils.TypeTokenMap[val.GetType()]));
                }
            }
            catch (Exception ex)
            {
                throw new CustomFunctionException($"Error executing custom function {_functionName}, see inner exception for more details", ex);
            }

        }
    }

}