namespace NeonBlue.Expressions.Tests;

public class FunctionalTest
{
    [Theory]
    [InlineData("2 * x + 3", new[] { IntermediateTokenType.Integer, IntermediateTokenType.Operator, IntermediateTokenType.Variable, IntermediateTokenType.Operator, IntermediateTokenType.Integer })]
    [InlineData("(2 * (x + 1)) - 3", new[]
    { IntermediateTokenType.Operator, IntermediateTokenType.Integer, IntermediateTokenType.Operator, IntermediateTokenType.Operator, IntermediateTokenType.Variable, IntermediateTokenType.Operator,
     IntermediateTokenType.Integer, IntermediateTokenType.Operator, IntermediateTokenType.Operator, IntermediateTokenType.Operator, IntermediateTokenType.Integer })]
    public void Tokenize_VariousExpressions_ReturnsCorrectTokens(string expression, IntermediateTokenType[] expectedTokenTypes)
    {
        var tokenizer = new Tokenizer(expression);
        var tokens = tokenizer.Tokenize(new FunctionsLookup());

        Assert.Equal(expectedTokenTypes.Length, tokens.Count);

        for (int i = 0; i < tokens.Count; i++)
        {
            Assert.Equal(expectedTokenTypes[i], tokens[i].TokenType);
        }
    }
    [Fact]
    public void Tokenize_SimpleExpression_ReturnsCorrectTokens()
    {
        var tokenizer = new Tokenizer("2 * x + 3");
        var tokens = tokenizer.Tokenize(new FunctionsLookup());

        Assert.Equal(5, tokens.Count);
        Assert.Equal(IntermediateTokenType.Integer, tokens[0].TokenType);
        Assert.Equal("2", tokens[0].Value);
        Assert.Equal(IntermediateTokenType.Operator, tokens[1].TokenType);
        Assert.Equal("*", tokens[1].Value);
        Assert.Equal(IntermediateTokenType.Variable, tokens[2].TokenType);
        Assert.Equal("x", tokens[2].Value);
        Assert.Equal(IntermediateTokenType.Operator, tokens[3].TokenType);
        Assert.Equal("+", tokens[3].Value);
        Assert.Equal(IntermediateTokenType.Integer, tokens[4].TokenType);
        Assert.Equal("3", tokens[4].Value);
    }

    [Fact]
    public void Can_Add_Custom_Function()
    {
        double[] x = [2, 2];
        double[] x2 = [20, 45, 60];
        double y = 10;
        Expression neonBlueExpression = "-1 + (-sum(x )+countd(x2) + (y -plusone(2)) ) ";

        var evaluator = new Evaluator(new ExecutionOptions(NullStrategy.Throw));
        Func<int, int> plusone = (a) => { return a + 1; };
        evaluator.AddCustomFunction("plusone", plusone);

        var res =
        evaluator.Evaluate<double?>(neonBlueExpression,
        new ExpressionParameters(new ExpressionParameter("x", x), new ExpressionParameter("x2", x2), new ExpressionParameter("y", y)));
        Assert.NotNull(res);
        Assert.Equal(5.0, res);

    }
    [Fact]
    public void Can_Add_Custom_Function2()
    {
        //creating the expression.
        Expression neonBlueExpression = "multiarg(y,maDate,b)";

        //creating the evaluator object.
        var evaluator = new Evaluator(new ExecutionOptions(NullStrategy.Throw));

        //creating multi argument function.
        Func<int, DateTime, bool, string> multiarg = (a, d, i) => { return $"{i} and {d.ToShortDateString()} {a}"; };

        //register the function with a unique name.
        evaluator.AddCustomFunction("multiarg", multiarg);

        //define values.
        int y = 10;
        bool b = false;
        DateTime maDate = DateTime.Now;

        //creating the expression parameters.
        var paramaters =
        new ExpressionParameters(new ExpressionParameter("y", y), new ExpressionParameter("b", b), new ExpressionParameter("maDate", maDate));

        //evaluate the expression given the parameters and expect string result.
        var result = evaluator.Evaluate<string?>(neonBlueExpression, paramaters);

        //display the result
        Console.WriteLine($"the result of the expression is ({result})");


        Assert.NotNull(result);
        Assert.Equal($"{b} and {maDate.ToShortDateString()} {y}", result.ToString());

    }
    [Fact]
    public void Can_Do_Power_Operator()
    {
        //creating the expression.
        Expression neonBlueExpression = "6.4^8.4 * 20 + 3";

        //creating the evaluator object.
        var evaluator = new Evaluator(new ExecutionOptions(NullStrategy.Throw));

        //evaluate the expression given the parameters and expect string result.
        var result = evaluator.Evaluate<double?>(neonBlueExpression, new ExpressionParameters());


        Assert.NotNull(result); 
        Assert.Equal(Math.Pow(6.4, 8.4) * 20 + 3, result);

    }

    [Fact]
    public void Should_Handle_keywords()
    { 
        Expression neonBlueExpression = new($"iif(true,pi,null)");
        var evaluator = new Evaluator();

        var res =
        evaluator.Evaluate(neonBlueExpression );
        Assert.NotNull(res);
        Assert.Equal(typeof(double), res!.GetType());
        Assert.Equal(Math.PI, (double)res);

    }

    [Fact]
    public void Should_Handle_Nasted_Expressions()
    {
        var x = 2;
        var y = 1;

        var innerCondition = "x > 2 || y  = 3";
        var innerTrue = "5+5";
        var innerFalse = "abs(-50)-20";
        var innerIff = $"iif({innerCondition},{innerTrue},{innerFalse})";

        Expression neonBlueExpression = new($"iif( or(2 == 2 , 1  = 3),{innerIff} + 5,50-20) + 22");
        var evaluator = new Evaluator(new ExecutionOptions(NullStrategy.Throw));

        var res =
        evaluator.Evaluate(neonBlueExpression,
        new ExpressionParameters(new ExpressionParameter("x", x), new ExpressionParameter("y", y)));
        Assert.NotNull(res);
        Assert.Equal(typeof(int), res!.GetType());
        Assert.Equal(57, (int)res);

    }
    [Fact]
    public void Should_Handle_Arrays_With_Diffrent_Length()
    {
        double[] x = [2, 2];
        double[] x2 = [20, 45, 60];
        double y = 10;

        Expression neonBlueExpression = "-1 + (-sum(x )+countd(x2) + (y -2) ) ";

        var evaluator = new Evaluator(new ExecutionOptions(NullStrategy.Throw));
        var paramaters = new ExpressionParameters(new ExpressionParameter("x", x), new ExpressionParameter("x2", x2), new ExpressionParameter("y", y));
        var res =
        evaluator.Evaluate<double?>(neonBlueExpression, paramaters);
        Assert.NotNull(res);
        Assert.Equal(6.0, res);

    }
    [Fact]
    public void Should_Handle_Aggregate_Of_Expression_probably()
    {
        double[] x = [2, 2];
        double[] x2 = [20, 45, 60];
        Expression neonBlueExpression = new("-1 + (-sum(x +1)+sum(x2 +3) + (10 -2) ) ");

        var evaluator = new Evaluator(new ExecutionOptions(NullStrategy.Throw));

        var res =
        evaluator.Evaluate(neonBlueExpression,
        new ExpressionParameters(new ExpressionParameter("x", x), new ExpressionParameter("x2", x2)));
        Assert.NotNull(res);
        Assert.Equal(typeof(double), res!.GetType());
        Assert.Equal(135.0, (double)res);

    }
    [Fact]
    public void Should_Handle_Aggregate_Of_Null_probably()
    {
        double[] x = [2, 2];
        double?[] x2 = [20, null, null];
        Expression neonBlueExpression = "-1 + (-sum(x +1)+sum(x2 +3) + (10 -2) ) ";

        var evaluator = new Evaluator(new ExecutionOptions(NullStrategy.Propagate));

        var res =
        evaluator.Evaluate(neonBlueExpression,
        new ExpressionParameters(new("x", x), new("x2", x2)));
        Assert.NotNull(res);
        Assert.Equal(typeof(double), res!.GetType());
        Assert.Equal(24.0, (double)res);

    }
    public class Should_Handle_Null_Values_Probably
    {
        [Fact]
        public void With_NullStrategy_default()
        {
            double? x2 = null;
            Expression neonBlueExpression = new("x =3  ");

            var evaluator = new Evaluator(new ExecutionOptions(NullStrategy.Default));

            var res =
            evaluator.Evaluate(neonBlueExpression,
            new ExpressionParameters(new ExpressionParameter("x", x2)));
            Assert.NotNull(res);
            Assert.False((bool)res);
        }

        [Fact]
        public void With_NullStrategy_Propagate()
        {
            bool? x2 = null;
            bool? x1 = true;
            Expression neonBlueExpression = new("x2 =x1  ");

            var evaluator = new Evaluator(new ExecutionOptions(NullStrategy.Propagate));

            var res =
            evaluator.Evaluate(neonBlueExpression,
            new ExpressionParameters(new ExpressionParameter("x2", x2), new ExpressionParameter("x1", x1)));
            Assert.Null(res);
        }
        [Fact]
        public void With_NullStrategy_Throw()
        {
            bool? x2 = null;
            bool? x1 = true;
            Expression neonBlueExpression = new("x2 =x1  ");

            var evaluator = new Evaluator(new ExecutionOptions(NullStrategy.Throw));


            Assert.Throws<NeonBlueExpressionException>(() =>
            {
                evaluator.Evaluate(neonBlueExpression,
                        new ExpressionParameters(new ExpressionParameter("x2", x2), new ExpressionParameter("x1", x1)));
            });
        }
    }
    public class Should_Handle_Null_Values_In_Plus
    {


        [Fact]
        public void With_NullStrategy_PropagateAndDefault()
        {
            double? x2 = null;
            double? x1 = 3;
            Expression neonBlueExpression = new("x2 +x1  ");

            var evaluator = new Evaluator(new ExecutionOptions(NullStrategy.Propagate));

            var res =
            evaluator.Evaluate(neonBlueExpression,
            new ExpressionParameters(new ExpressionParameter("x2", x2), new ExpressionParameter("x1", x1)));
            Assert.Null(res);
        }
        [Fact]
        public void With_NullStrategy_Throw()
        {
            double? x2 = null;
            double? x1 = 3;
            Expression neonBlueExpression = new("x2 + x1");

            var evaluator = new Evaluator(new ExecutionOptions(NullStrategy.Throw));


            Assert.Throws<NeonBlueExpressionException>(() =>
            {
                evaluator.Evaluate(neonBlueExpression,
                        new ExpressionParameters(new ExpressionParameter("x2", x2), new ExpressionParameter("x1", x1)));
            });
        }
    }

}