﻿namespace NeonBlue.Expressions.Functions.MathFunctions
{
    public class RoundFunction : StackUpdateFunction
    {
        public override string FunctionName => "round";
        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 2)
            {
                throw new EmptyStackException();
            }
            var arg2 = x.Pop();
            var arg1 = x.Pop();

            if (MathFunctionUtils.NullCheck(x, arg2, executionOptions.NullStrategy)) return;
            if (MathFunctionUtils.NullCheck(x, arg1, executionOptions.NullStrategy)) return;
            if (!TokensUtils.IsNumeric(arg1.TokenType) || !TokensUtils.IsNumeric(arg2.TokenType))
            {
                throw new InvalidArgumentTypeException(FunctionName, arg1.GetType());
            }

            try
            {
                var arg2val = Convert.ToInt32(arg2.Value);
                if (arg1.TokenType == TokenType.Decimal)
                {
                    var val = Convert.ToDecimal(arg1.Value);
                    x.Push(new Token(Math.Round(val, arg2val)));
                }
                else
                {
                    var val = Convert.ToDouble(arg1.Value);
                    x.Push(new Token(Math.Round(val, arg2val)));
                }
            }
            catch (Exception ex)
            {
                throw new MathException(FunctionName, $"Math operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }

        }

    }
}