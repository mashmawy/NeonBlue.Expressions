using NeonBlue.Expressions.Aggregates.Aggergators;
using NeonBlue.Expressions.Exceptions;

namespace NeonBlue.Expressions.Tests.AggergatorsTests;

public class AvgAggergatorUnitTest
{

    [Fact]
    public void TestAvgAggregator()
    {
        double[] x = [1, 2, 3, 4, 5, 6];
        AvgAggregator avgAggregator = new();
        for (int i = 0; i < x.Length; i++)
        {
            avgAggregator.Update(x[i]);
        }
        var res = avgAggregator.Return();
        Assert.NotNull(res);
        Assert.True(res.GetType() == typeof(double));
        double avg = Convert.ToDouble(res);
        Assert.Equal(3.5, avg);
    }
    [Fact]
    public void TestAvgAggregatorWithNull()
    {
        double?[] x = [1, 2, null, 4, 5, 6];
        AvgAggregator avgAggregator = new();
        for (int i = 0; i < x.Length; i++)
        {
            avgAggregator.Update(x[i]);
        }
        var res = avgAggregator.Return();
        Assert.NotNull(res);
        Assert.True(res.GetType() == typeof(double));
        double avg = Convert.ToDouble(res);
        Assert.Equal(3, avg);
    }

    [Fact]
    public void None_numerical_data_should_throw_InvalidArgumentTypeExeception()
    {
        object?[] x = ["2", "2", "2", "2", "2", "2"];

        Assert.Throws<InvalidArgumentTypeExeception>(() =>
        {
            AvgAggregator avgAggregator = new();
            for (int i = 0; i < x.Length; i++)
            {
                avgAggregator.Update(x[i]);
            }
            var res = avgAggregator.Return();
        });

    }

    [Fact]
    public void Changing_data_type_should_throw_InvalidArgumentTypeExeception()
    {
        object?[] x = [1, "2", null, DateTime.Now, 5, 6];

        Assert.Throws<AggregateFunctionException>(() =>
        {
            AvgAggregator avgAggregator = new();
            for (int i = 0; i < x.Length; i++)
            {
                avgAggregator.Update(x[i]);
            }
            var res = avgAggregator.Return();
        });

    }

}