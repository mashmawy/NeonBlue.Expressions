﻿using NeonBlue.Expressions;
using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.MathFunctions
{
    public class CeilingFunction : StackUpdateFunction
    {
        public override string FunctionName => "ceiling";
        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 1)
            {
                throw new EmptyStackExecption();
            }
            var token = x.Pop();
            if (MathFunctionUtils.NullCheck(x, token, executionOptions.NullStrategy)) return;
            if (!TokensUtils.IsNumeric(token.TokenType))
            {
                throw new InvalidArgumentTypeExeception(FunctionName, typeof(DateTime));
            }
            try
            {
                if (token.TokenType == TokenType.Decimal)
                {
                    var arg2val = Convert.ToDecimal(token.Value);
                    x.Push(new Token(Math.Ceiling(arg2val)));
                }
                else
                {

                    var arg2val = Convert.ToDouble(token.Value);
                    x.Push(new Token(Math.Ceiling(arg2val)));
                }
            }
            catch (Exception ex)
            {
                throw new MathException(FunctionName, $"Math operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }


        }

    }
}