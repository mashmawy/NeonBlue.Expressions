using NeonBlue.Expressions.Operators;
namespace NeonBlue.Expressions.Tests.OperatorsTests.DivideOperatorsTests;

public class DecimalDivideOperatorUnitTest
{
    [Fact]
    public void DecimalDivideByteReturnCorrectValueAndValueType()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(20, TokenType.Decimal);
        var operand2 = new Token(2, TokenType.Byte);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value is decimal);
        Assert.Equal(10m, Convert.ToDecimal(result.Value));
    }

    [Fact]
    public void DecimalDivideIntegerFunctionReturnCorrectValueAndValueType()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Decimal);
        var operand2 = new Token(20, TokenType.Integer);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value is decimal);
        Assert.Equal(10m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void DecimalDivideLongFunctionReturnCorrectValueAndValueType()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Decimal);
        var operand2 = new Token((long)20, TokenType.Long);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value is decimal);
        Assert.Equal(10m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void DecimalDivideFloatFunctionReturnCorrectValueAndValueType()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Decimal);
        var operand2 = new Token(20f, TokenType.Float);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value is decimal);
        Assert.Equal(10m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void DecimalDivideDecimalFunctionReturnCorrectValueAndValueType()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Decimal);
        var operand2 = new Token(20m, TokenType.Decimal);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value is decimal);
        Assert.Equal(10m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void DecimalDivideDoubleFunctionReturnCorrectValueAndValueType()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Decimal);
        var operand2 = new Token(20.0, TokenType.Double);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value is decimal);
        Assert.Equal(10m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void DecimalDivideZeroFunctionReturnCorrectValueAndValueType()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Decimal);
        var operand2 = new Token(0, TokenType.Double);
        Assert.Throws<DivideByZeroException>(() =>
       {
           divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
       });
    }
    [Fact]
    public void DecimalDivideNullFunctionDefaultOption()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Decimal);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void DecimalDivideNullFunctionPropgateOption()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Decimal);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void DecimalDivideNullFunctionThrowOption()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Decimal);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenException>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void DecimalDivideOtherTypesFunctionThrowOption()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Decimal);
        var operand2 = new Token("545", TokenType.String);
        Assert.Throws<InvalidOperationException>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }

}