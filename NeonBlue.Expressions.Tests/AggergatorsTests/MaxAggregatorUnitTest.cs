using NeonBlue.Expressions.Aggregates.Aggergators;

namespace NeonBlue.Expressions.Tests.AggergatorsTests;

public class MaxAggergatorUnitTest
{

    [Fact]
    public void TestMaxAggregator()
    {
        double[] x = [1, 2, 3, 4, 5, 6];
        MaxAggregator maxAggregator = new();
        for (int i = 0; i < x.Length; i++)
        {
            maxAggregator.Update(x[i]);
        }
        var res = maxAggregator.Return();
        Assert.NotNull(res);
        Assert.True(res is double);
        double avg = Convert.ToDouble(res);
        Assert.Equal(6, avg);
    }
    [Fact]
    public void TestMaxAggregatorWithNull()
    {
        double?[] x = [1, 2, null, 4, 5, 6];
        MaxAggregator maxAggregator = new();
        for (int i = 0; i < x.Length; i++)
        {
            maxAggregator.Update(x[i]);
        }
        var res = maxAggregator.Return();
        Assert.NotNull(res);
        Assert.True(res is double);
        double avg = Convert.ToDouble(res);
        Assert.Equal(6, avg);
    }

    [Fact]
    public void TestMaxAggregatorWithDates()
    {
        DateTime[] x = [new DateTime(2024,9,1), new DateTime(2024,9,2),new DateTime(2024,9,3), new DateTime(2024,9,4), new DateTime(2024,9,5), new DateTime(2024,9,6)];
        MaxAggregator maxAggregator = new();
        for (int i = 0; i < x.Length; i++)
        {
            maxAggregator.Update(x[i]);
        }
        var res = maxAggregator.Return();
        Assert.NotNull(res);
        Assert.True(res is DateTime);
        DateTime avg = Convert.ToDateTime(res);
        Assert.Equal(new DateTime(2024,9,6), avg);
    }
    [Fact]
        public void Changing_data_type_should_throw_InvalidArgumentTypeExeception()
        {
            object?[] x = [1, "2", null, DateTime.Now, 5, 6];

            Assert.Throws<AggregateFunctionException>(() =>
            {
                MaxAggregator maxAggregator = new();
                for (int i = 0; i < x.Length; i++)
                {
                    maxAggregator.Update(x[i]);
                }
                var res = maxAggregator.Return();
            });

        }


}