using NeonBlue.Expressions.Aggregates.Aggergators;

namespace NeonBlue.Expressions.Tests.AggergatorsTests;
public class VarAggregatorUnitTest
{

    [Fact]
    public void TestVarAggregator()
    {
        double[] x = [1, 2, 3, 4, 5, 6];
        VarAggregator varAggregator = new();
        for (int i = 0; i < x.Length; i++)
        {
            varAggregator.Update(x[i]);
        }
        var res = varAggregator.Return();
        Assert.NotNull(res);
        Assert.True(res is double);
        double variance = Convert.ToDouble(res);
        Assert.Equal(2.9167, Math.Round(variance, 4));
    }

    [Fact]
    public void TestVarAggregatorWithNull()
    {
        double?[] x = [null, 2, null, 4, 5, 6];
        VarAggregator varAggregator = new();
        for (int i = 0; i < x.Length; i++)
        {
            varAggregator.Update(x[i]);
        }
        var res = varAggregator.Return();
        Assert.NotNull(res);
        Assert.True(res is double);
        double variance = Convert.ToDouble(res);
        Assert.Equal(2.1875, Math.Round(variance, 4));
    }

    [Fact]
    public void None_numerical_data_should_throw_InvalidArgumentTypeExeception()
    {
        object?[] x = ["2", "2", "2", "2", "2", "2"];

        Assert.Throws<InvalidArgumentTypeException>(() =>
        {
            VarAggregator varAggregator = new();
            for (int i = 0; i < x.Length; i++)
            {
                varAggregator.Update(x[i]);
            }
            var res = varAggregator.Return();
        });

    }
    [Fact]
    public void Changing_data_type_should_throw_InvalidArgumentTypeExeception()
    {
        object?[] x = [1, "2", null, DateTime.Now, 5, 6];

        Assert.Throws<AggregateFunctionException>(() =>
        {
            VarAggregator varAggregator = new();
            for (int i = 0; i < x.Length; i++)
            {
                varAggregator.Update(x[i]);
            }
            var res = varAggregator.Return();
        });

    }
}