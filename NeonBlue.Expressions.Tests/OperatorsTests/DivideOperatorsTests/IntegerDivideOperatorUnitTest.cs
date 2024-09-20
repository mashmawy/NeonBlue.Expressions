using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators;
namespace NeonBlue.Expressions.Tests.OperatorsTests.DivideOperatorsTests;

public class IntegerDivideOperatorUnitTest
{
    [Fact]
    public void IntegerDivideFunctionReturnCorrectValueAndValueType()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(20, TokenType.Integer);
        var operand2 = new Token((byte)2, TokenType.Byte);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Integer);
        Assert.True(result.Value.GetType() == typeof(int));
        Assert.Equal(10, Convert.ToInt32(result.Value));
    }

    [Fact]
    public void IntegerDivideIntegerFunctionReturnCorrectValueAndValueType()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Integer);
        var operand2 = new Token(20, TokenType.Integer);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Integer);
        Assert.True(result.Value.GetType() == typeof(int));
        Assert.Equal(10, Convert.ToInt32(result.Value));
    }
    [Fact]
    public void IntegerDivideLongFunctionReturnCorrectValueAndValueType()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Integer);
        var operand2 = new Token((long)20, TokenType.Long);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Long);
        Assert.True(result.Value.GetType() == typeof(long));
        Assert.Equal(10, Convert.ToInt64(result.Value));
    }
    [Fact]
    public void IntegerDivideFloatFunctionReturnCorrectValueAndValueType()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Integer);
        var operand2 = new Token(20f, TokenType.Float);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value.GetType() == typeof(float));
        Assert.Equal(10, Convert.ToSingle(result.Value));
    }
    [Fact]
    public void IntegerDivideDecimalFunctionReturnCorrectValueAndValueType()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Integer);
        var operand2 = new Token(20m, TokenType.Decimal);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(10m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void IntegerDivideDoubleFunctionReturnCorrectValueAndValueType()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Integer);
        var operand2 = new Token(20.0, TokenType.Double);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(10.0, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void DecimalDivideZeroFunctionReturnCorrectValueAndValueType()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Integer);
        var operand2 = new Token(0, TokenType.Double);
        Assert.Throws<DivideByZeroException>(() =>
       {
           divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
       });
    }
    [Fact]
    public void IntegerDivideNullFunctionDefaultOption()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Integer);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void IntegerDivideNullFunctionPropgateOption()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Integer);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void IntegerDivideNullFunctionThrowOption()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Integer);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenException>(() =>
        { 
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void IntegerDivideOtherTypesFunctionThrowOption()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Integer);
        var operand2 = new Token("545",TokenType.String);
        Assert.Throws<InvalidOperationException>(() =>
        { 
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }

}