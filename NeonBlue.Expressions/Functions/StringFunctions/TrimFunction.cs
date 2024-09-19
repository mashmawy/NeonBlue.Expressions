﻿using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.StringFunctions
{
    public class TrimFunction : StackUpdateFunction
    {
        public override string FunctionName => "trim";
        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            // var token1 = x.Pop();
            // if (StringFunctionsHelper.NullCheck(x, token1,executionOptions)) return;
            // var arg1 = token1.Value!.ToString();
            // x.Push(new Token(arg1!.Trim()));
            if (x is null || x.Count < 1)
            {
                throw new EmptyStackExecption();
            }
            var token1 = x.Pop();
            if (StringFunctionsHelper.NullCheck(x, token1, executionOptions)) return;
            try
            {
                var arg1 = token1.Value!.ToString();
                x.Push(new Token(arg1!.Trim()));
            }
            catch (Exception ex)
            {
                throw new StringException(FunctionName, $"String operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }
        }
    }
}