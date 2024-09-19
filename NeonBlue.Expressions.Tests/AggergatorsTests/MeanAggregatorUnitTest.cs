using NeonBlue.Expressions.Aggregates.Aggergators;
using NeonBlue.Expressions.Exceptions;

namespace NeonBlue.Expressions.Tests.AggergatorsTests;

public class MeanAggregatorUnitTest
{

    [Fact]
    public void TestMeanAggregator()
    {
        double[] x = [1, 2, 3, 4, 5, 6];
        MeanAggregator meanAggregator = new();
        for (int i = 0; i < x.Length; i++)
        {
            meanAggregator.Update(x[i]);
        }
        var res = meanAggregator.Return();
        Assert.NotNull(res);
        Assert.True(res.GetType() == typeof(double));
        double meaniance = Convert.ToDouble(res);
        Assert.Equal(3.5, Math.Round(meaniance, 2));
    }

    [Fact]
    public void TestMeanAggregatorWithNull()
    {
        double?[] x = [null, 2, null, 4, 5, 6];
        MeanAggregator meanAggregator = new();
        for (int i = 0; i < x.Length; i++)
        {
            meanAggregator.Update(x[i]);
        }
        var res = meanAggregator.Return();
        Assert.NotNull(res);
        Assert.True(res.GetType() == typeof(double));
        double meaniance = Convert.ToDouble(res);
        Assert.Equal(4.25, Math.Round(meaniance, 2));
    }

    [Fact]
    public void None_numerical_data_should_throw_InvalidArgumentTypeExeception()
    {
        object?[] x = ["2", "2", "2", "2", "2", "2"];

        Assert.Throws<InvalidArgumentTypeExeception>(() =>
        {
            MeanAggregator meanAggregator = new();
            for (int i = 0; i < x.Length; i++)
            {
                meanAggregator.Update(x[i]);
            }
            var res = meanAggregator.Return();
        });

    }
    [Fact]
    public void Changing_data_type_should_throw_InvalidArgumentTypeExeception()
    {
        object?[] x = [1, "2", null, DateTime.Now, 5, 6];

        Assert.Throws<AggregateFunctionException>(() =>
        {
            MeanAggregator meanAggregator = new();
            for (int i = 0; i < x.Length; i++)
            {
                meanAggregator.Update(x[i]);
            }
            var res = meanAggregator.Return();
        });

    }
}
