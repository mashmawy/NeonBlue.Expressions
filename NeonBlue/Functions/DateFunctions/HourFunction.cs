﻿using NeonBlue.Expressions;
using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.DateFunctions
{
    public class HourFunction : StackUpdateFunction
    {
        public override string FunctionName => "hour";
        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 1)
            {
                throw new EmptyStackExecption();
            }
            var token1 = x.Pop();

            if (DateFunctionsUtils.NullCheck(x, token1, executionOptions)) return;
            if (token1.TokenType != TokenType.Datetime)
            {
                throw new InvalidArgumentTypeExeception(FunctionName, typeof(DateTime));
            }
            var arg1 = Convert.ToDateTime(token1.Value);
            x.Push(new Token(arg1.Hour));

        }
    }
}