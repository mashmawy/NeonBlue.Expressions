using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions
{
    /// <summary>
    /// Manages operator overloading for various token types.
    /// </summary>
    public static class OperatorsManager
    {
        /// <summary>
        /// A dictionary mapping token types (operators) to their corresponding IOperator implementations.
        /// </summary>
        private static Dictionary<TokenType, IOperator>? operators = null;

        /// <summary>
        /// Gets the dictionary of operators. Creates it on first call (lazy initialization).
        /// </summary>
        /// <returns>The dictionary of operators.</returns>
        public static Dictionary<TokenType, IOperator> GetOperators()
        {
            operators ??= new(){
                    {TokenType.Plus, new PlusOperatorOverloads()},

                    {TokenType.Minus, new MinusOperatorOverloads()},

                    {TokenType.Multiply, new MultiplyOperatorOverloads()},

                    {TokenType.Divide, new DivideOperatorOverloads()},

                    {TokenType.Percentage, new PercentageOperatorOverloads()},
                    {TokenType.Power, new PowerOperatorOverloads()},

                    {TokenType.Equal, new EqualOperatorOverloads()},

                    {TokenType.NotEqual, new NotEqualOperatorOverloads()},

                    {TokenType.GreaterThan, new GreaterThanOperatorOverloads()},

                    {TokenType.GreaterThanOrEqual, new GreaterThanOrEqualOperatorOverloads()},

                    {TokenType.LessThan, new LessThanOperatorOverloads()},

                    {TokenType.LessThanOrEqual, new LessThanOrEqualOperatorOverloads()},

                    {TokenType.LogicalAnd, new LogicalAndOperatorOverloads()},

                    {TokenType.LogicalOr, new LogicalOrOperatorOverloads()},

                    {TokenType.LogicalNot, new LogicalNotOperatorOverloads()},

                };
            return operators;
        }


        /// <summary>
        /// Executes the operation based on the provided token type and operands.
        /// </summary>
        /// <param name="function">The token type representing the operator.</param>
        /// <param name="stack">The stack containing operands.</param>
        /// <param name="executionOptions">The execution options.</param>
        public static void Exec(TokenType function, Stack<Token> stack, IExecutionOptions executionOptions)
        {
            if (GetOperators().TryGetValue(function, out IOperator? oper))
            {
                Token arg2Token = new(null);

                if (oper.OperatorType != TokenType.LogicalNot)
                    arg2Token = stack.Pop();

                if (stack.Count == 0)
                {
                    throw new InvalidOperationException($"Stack is empty, Operator {oper.OperatorType} ");
                }
                var arg1Token = stack.Pop();
                var res = oper.Run(arg1Token, arg2Token, executionOptions);
                stack.Push(res);
            }
        }


    }
}