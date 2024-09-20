using NeonBlue.Expressions.Aggregates.Aggergators;
using NeonBlue.Expressions;

namespace NeonBlue.Expressions.Tests.AggergatorsTests;
public class StdAggregatorUnitTest
{

    [Fact]
    public void TestStdAggregator()
    {
        double[] x = [1, 2, 3, 4, 5, 6];
        StdAggregator stdAggregator = new();
        for (int i = 0; i < x.Length; i++)
        {
            stdAggregator.Update(x[i]);
        }
        var res = stdAggregator.Return();
        Assert.NotNull(res);
        Assert.True(res.GetType() == typeof(double));
        double variance = Convert.ToDouble(res);
        Assert.Equal(Math.Round(Math.Sqrt(2.9167), 4), Math.Round(variance, 4));
    }

    [Fact]
    public void TestStdAggregatorWithNull()
    {
        double?[] x = [null, 2, null, 4, 5, 6];
        StdAggregator stdAggregator = new();
        for (int i = 0; i < x.Length; i++)
        {
            stdAggregator.Update(x[i]);
        }
        var res = stdAggregator.Return();
        Assert.NotNull(res);
        Assert.True(res.GetType() == typeof(double));
        double variance = Convert.ToDouble(res);
        Assert.Equal(Math.Round(Math.Sqrt(2.1875), 4), Math.Round(variance, 4));
    }

    [Fact]
    public void None_numerical_data_should_throw_InvalidArgumentTypeExeception()
    {
        object?[] x = ["2", "2", "2", "2", "2", "2"];

        Assert.Throws<InvalidArgumentTypeException>(() =>
        {
            StdAggregator stdAggregator = new();
            for (int i = 0; i < x.Length; i++)
            {
                stdAggregator.Update(x[i]);
            }
            var res = stdAggregator.Return();
        });

    }
    [Fact]
    public void Changing_data_type_should_throw_InvalidArgumentTypeExeception()
    {
        object?[] x = [1, "2", null, DateTime.Now, 5, 6];

        Assert.Throws<AggregateFunctionException>(() =>
        {
            StdAggregator stdAggregator = new();
            for (int i = 0; i < x.Length; i++)
            {
                stdAggregator.Update(x[i]);
            }
            var res = stdAggregator.Return();
        });

    }
}