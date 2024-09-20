﻿namespace NeonBlue.Expressions.Functions.MathFunctions
{
    public class CosFunction : StackUpdateFunction
    {
        public override string FunctionName => "cos";
        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 1)
            {
                throw new EmptyStackException();
            }
            var token = x.Pop();
            if (MathFunctionUtils.NullCheck(x, token, executionOptions.NullStrategy)) return;
            if (!TokensUtils.IsNumeric(token.TokenType))
            {
                throw new InvalidArgumentTypeException(FunctionName, typeof(DateTime));
            }

            try
            {
                if (token.TokenType == TokenType.Integer)
                {
                    var val = Convert.ToInt32(token.Value);
                    x.Push(new Token(Math.Cos(val)));
                }
                else if (token.TokenType == TokenType.Long)
                {
                    var val = Convert.ToInt64(token.Value);
                    x.Push(new Token(Math.Cos(val)));
                }
                else if (token.TokenType == TokenType.Double)
                {

                    var val = Convert.ToDouble(token.Value);
                    x.Push(new Token(Math.Cos(val)));
                }
                else if (token.TokenType == TokenType.Float)
                {
                    var val = Convert.ToSingle(token.Value);
                    x.Push(new Token(Math.Cos(val)));
                }
                else if (token.TokenType == TokenType.Decimal)
                {

                    var val = Convert.ToDecimal(token.Value);
                    x.Push(new Token(Math.Cos((double)val)));
                }
                else if (token.TokenType == TokenType.Byte)
                {
                    var val = Convert.ToByte(token.Value);
                    x.Push(new Token(Math.Cos(val)));
                }
            }
            catch (Exception ex)
            {
                throw new MathException(FunctionName, $"Math operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }


        }

    }
}