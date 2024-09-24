
using NeonBlue.Expressions;
using NeonBlue.Expressions.Examples.RuleEngine;

var rule1 = new Rule("Rule 1", "x > 10");
var rule2 = new Rule("Rule 2", "y < 5");
var rule3 = new Rule("Rule 3", "z == 0");

rule1.AddChild(rule2);
rule1.AddChild(rule3);

var parameters = new ExpressionParameters(
    new ExpressionParameter("x", 12),
    new ExpressionParameter("y", 3),
    new ExpressionParameter("z", 0)
);

var result = rule1.Evaluate(parameters);

Console.WriteLine(result.ToString());