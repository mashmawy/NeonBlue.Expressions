using NeonBlue.Expressions.Aggregates.Aggergators;

namespace NeonBlue.Expressions.Tests.AggergatorsTests;

public class SumAggergatorUnitTest
{

    [Fact]
    public void TestSumAggregator()
    {
        double[] x = [1, 2, 3, 4, 5, 6];
        SumAggregator sumAggregator = new();
        for (int i = 0; i < x.Length; i++)
        {
            sumAggregator.Update(x[i]);
        }
        var res = sumAggregator.Return();
        Assert.NotNull(res);
        Assert.True(res.GetType() == typeof(double));
        double sum = Convert.ToDouble(res);
        Assert.Equal(21, sum);
    }
    [Fact]
    public void TestSumAggregatorWithNull()
    {
        double?[] x = [1, 2, null, 4, 5, 6];
        SumAggregator sumAggregator = new();
        for (int i = 0; i < x.Length; i++)
        {
            sumAggregator.Update(x[i]);
        }
        var res = sumAggregator.Return();
        Assert.NotNull(res);
        Assert.True(res.GetType() == typeof(double));
        double sum = Convert.ToDouble(res);
        Assert.Equal(18, sum);
    }

    [Fact]
    public void None_numerical_data_should_throw_InvalidArgumentTypeExeception()
    {
        object?[] x = ["2", "2", "2", "2", "2", "2"];

        Assert.Throws<InvalidArgumentTypeException>(() =>
        {
            SumAggregator sumAggregator = new();
            for (int i = 0; i < x.Length; i++)
            {
                sumAggregator.Update(x[i]);
            }
            var res = sumAggregator.Return();
        });

    }

    [Fact]
    public void Changing_data_type_should_throw_InvalidArgumentTypeExeception()
    {
        object?[] x = [1, "2", null, DateTime.Now, 5, 6];

        Assert.Throws<AggregateFunctionException>(() =>
        {
            SumAggregator sumAggregator = new();
            for (int i = 0; i < x.Length; i++)
            {
                sumAggregator.Update(x[i]);
            }
            var res = sumAggregator.Return();
        });

    }

}