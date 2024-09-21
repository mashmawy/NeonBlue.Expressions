namespace NeonBlue.Expressions.Operators
{
    internal static  class PowerOperatorHelper
    { 
        /// <summary>
        /// Compute the power of the top two numeric values.
        /// </summary>
        /// <param name="a1">The first operand.</param>
        /// <param name="a2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the power of the top two numeric values.</returns>
        public static Token Power(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToDouble(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(Math.Pow(arg1,arg2), TokenType.Double);
        }
    }
}
