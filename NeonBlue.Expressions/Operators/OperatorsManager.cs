namespace NeonBlue.Expressions.Operators
{
    public class OperatorsManager
    {
        static Dictionary<TokenType, IOperator>? operators = null;
        public static Dictionary<TokenType, IOperator> GetOperators()
        {
            if (operators == null)
            {
                operators = new(){
                    {TokenType.Plus, new PlusOperatorOverloads()},

                    {TokenType.Minuse, new MinusOperatorOverloads()},

                    {TokenType.Multiply, new MultiplyOperatorOverloads()},

                    {TokenType.Divide, new DivideOperatorOverloads()},

                    {TokenType.Percentage, new PercentageOperatorOverloads()},

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
            }
            return operators;
        }


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