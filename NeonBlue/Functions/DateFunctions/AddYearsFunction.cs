﻿using NeonBlue.Expressions;
using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.DateFunctions
{
    public class AddYearsFunction : StackUpdateFunction
    {
        public override string FunctionName => "addyears";


        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 2)
            {
                throw new EmptyStackExecption();
            }
            var token2 = x.Pop();
            var token1 = x.Pop();

            if (DateFunctionsUtils.NullCheck(x, token1, executionOptions)) return;
            if (DateFunctionsUtils.NullCheck(x, token2, executionOptions)) return;
            if (token2.TokenType != TokenType.Integer || token1.TokenType != TokenType.Datetime)
            {
                throw new InvalidArgumentTypeExeception(FunctionName, typeof(DateTime));
            }
            var arg1 = Convert.ToDateTime(token1.Value);
            var arg2 = Convert.ToInt32(token2.Value);
            x.Push(new Token(arg1.AddYears(arg2)));

        }
    }
}