﻿using System.Globalization;
using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.DateFunctions
{
    public class DayNameFunction : StackUpdateFunction
    {
        public override string FunctionName => "dayname";
        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 2)
            {
                throw new EmptyStackException();
            }
            var token2 = x.Pop();
            var token1 = x.Pop();

            if (DateFunctionsUtils.NullCheck(x, token1, executionOptions)) return;
            if (DateFunctionsUtils.NullCheck(x, token2, executionOptions)) return;
            if (token1.TokenType != TokenType.Datetime)
            {
                throw new InvalidArgumentTypeException(FunctionName, typeof(DateTime));
            }

            var arg1 = Convert.ToDateTime(token1.Value);
            var arg2 = token2.Value!.ToString();
            try
            {
                x.Push(new Token(arg1.ToString("dddd", CultureInfo.CreateSpecificCulture(arg2!))));
            }
            catch (Exception ex)
            {
                throw new InvalidArgumentTypeException(FunctionName, typeof(DateTime), "Invalid date culture", ex);
            }

        }
    }
}