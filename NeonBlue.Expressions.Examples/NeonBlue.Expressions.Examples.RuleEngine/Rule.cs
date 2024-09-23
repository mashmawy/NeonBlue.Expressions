// See https://aka.ms/new-console-template for more information 
namespace NeonBlue.Expressions.Examples.RuleEngine
{
    public class Rule
    {
        public string Name { get; set; }
        public string Expression { get; set; }
        public List<Rule> Children { get; set; }

        public Rule(string name, string expression)
        {
            Name = name;
            Expression = expression;
            Children = [];
        }

        public void AddChild(Rule child)
        {
            Children.Add(child);
        }

        public bool Evaluate(ExpressionParameters parameters)
        {
            // Evaluate the expression using your preferred expression evaluator
            var result = EvaluateExpression(Expression, parameters);

            // If the rule has children, evaluate them recursively
            if (Children.Any())
            {
                foreach (var child in Children)
                {
                    if (!child.Evaluate(parameters))
                    {
                        return false;
                    }
                }
            }

            return result;
        }

        private static bool EvaluateExpression(string expression, ExpressionParameters parameters)
        {
            // Implement your expression evaluation logic here
            // For example, you could use the NeonBlue.Expressions library
            var evaluator = new Evaluator();
            return evaluator.Evaluate<bool>(expression, parameters);
        }
    }
}