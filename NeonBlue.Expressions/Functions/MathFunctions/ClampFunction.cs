using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.MathFunctions
{
    public class ClampFunction : StackUpdateFunction
    {
        public override string FunctionName => "clamp";
        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 3)
            {
                throw new EmptyStackException();
            }

            var arg3 = x.Pop();
            var arg2 = x.Pop();
            var arg1 = x.Pop();
            if (MathFunctionUtils.NullCheck(x, arg3, executionOptions.NullStrategy)) return;
            if (MathFunctionUtils.NullCheck(x, arg2, executionOptions.NullStrategy)) return;
            if (MathFunctionUtils.NullCheck(x, arg1, executionOptions.NullStrategy)) return;
            if (!TokensUtils.IsNumeric(arg1.TokenType) ||
            !TokensUtils.IsNumeric(arg2.TokenType) ||
            !TokensUtils.IsNumeric(arg3.TokenType))
            {
                throw new InvalidArgumentTypeException(FunctionName, typeof(DateTime));
            }

            try
            {
                if (arg1.TokenType == TokenType.Integer)
                {
                    var arg1val = Convert.ToInt32(arg1.Value);
                    var arg2val = Convert.ToInt32(arg2.Value);
                    var arg3val = Convert.ToInt32(arg3.Value);
                    x.Push(new Token(Math.Clamp(arg1val, arg2val, arg3val)));
                }
                else if (arg1.TokenType == TokenType.Long)
                {
                    var arg1val = Convert.ToInt64(arg1.Value);
                    var arg2val = Convert.ToInt64(arg2.Value);
                    var arg3val = Convert.ToInt64(arg3.Value);
                    x.Push(new Token(Math.Clamp(arg1val, arg2val, arg3val)));
                }
                else if (arg1.TokenType == TokenType.Double)
                {
                    var arg1val = Convert.ToDouble(arg1.Value);
                    var arg2val = Convert.ToDouble(arg2.Value);
                    var arg3val = Convert.ToDouble(arg3.Value);
                    x.Push(new Token(Math.Clamp(arg1val, arg2val, arg3val)));
                }
                else if (arg1.TokenType == TokenType.Float)
                {
                    var arg1val = Convert.ToSingle(arg1.Value);
                    var arg2val = Convert.ToSingle(arg2.Value);
                    var arg3val = Convert.ToSingle(arg3.Value);
                    x.Push(new Token(Math.Clamp(arg1val, arg2val, arg3val)));
                }
                else if (arg1.TokenType == TokenType.Decimal)
                {
                    var arg1val = Convert.ToDecimal(arg1.Value);
                    var arg2val = Convert.ToDecimal(arg2.Value);
                    var arg3val = Convert.ToDecimal(arg3.Value);
                    x.Push(new Token(Math.Clamp(arg1val, arg2val, arg3val)));
                }
                else if (arg1.TokenType == TokenType.Byte)
                {
                    var arg1val = Convert.ToByte(arg1.Value);
                    var arg2val = Convert.ToByte(arg2.Value);
                    var arg3val = Convert.ToByte(arg3.Value);
                    x.Push(new Token(Math.Clamp(arg1val, arg2val, arg3val)));
                }
            }
            catch (Exception ex)
            {
                throw new MathException(FunctionName, $"Math operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }




        }

    }
}