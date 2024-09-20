using System.Reflection;
using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Functions
{
    /// <summary>
    /// Represents a custom stack update function that can execute arbitrary functions.
    /// </summary>
    public class CustomStackUpdateFunction : StackUpdateFunction
    {
        private readonly Delegate _functionDelegate;
        private readonly ParameterInfo[] _parameters;
        private readonly string _functionName;

        /// <summary>
        /// Initializes a new instance of the CustomStackUpdateFunction class.
        /// </summary>
        /// <param name="functionName">The name of the function.</param>
        /// <param name="functionDelegate">The delegate representing the function.</param>
        public CustomStackUpdateFunction(string functionName, Delegate functionDelegate)
        {
            _functionDelegate = functionDelegate;
            _parameters = _functionDelegate.Method.GetParameters();
            _functionName = functionName;
        }

        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => _functionName;

        /// <summary>
        /// Updates the stack by executing the custom function with the top values on the stack as arguments.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack contains fewer than the required number of elements.</exception>
        /// <exception cref="CustomFunctionException">Thrown if the custom function execution fails.</exception>
        public override void Update(Stack<Token> tokensStack, IExecutionOptions executionOptions)
        {
            if (tokensStack == null || tokensStack.Count < _parameters.Length)
            {
                throw new EmptyStackException();
            }

            object?[] argumentStack = new object[_parameters.Length];
             
            try
            {
                for (int i = _parameters.Length - 1; i >= 0; i--)
                {
                    var token = tokensStack.Pop();
                    if (MathFunctionUtils.NullCheck(tokensStack, token, executionOptions.NullStrategy)) return;
                    argumentStack[i] = Convert.ChangeType(token.Value, _parameters[i].ParameterType);
                }
                var val = _functionDelegate.DynamicInvoke(argumentStack);
                if (val == null)
                {
                    tokensStack.Push(new Token(null, TokenType.NULL));
                }
                else
                {
                    tokensStack.Push(new Token(val, TokensUtils.TypeTokenMap[val.GetType()]));
                }
            }
            catch (Exception ex)
            {
                throw new CustomFunctionException($"Error executing custom function {_functionName}, see inner exception for more details", ex);
            }

        }
    }

}