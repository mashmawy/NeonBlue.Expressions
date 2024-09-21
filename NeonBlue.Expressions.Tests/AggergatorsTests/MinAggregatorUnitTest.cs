using NeonBlue.Expressions.Aggregates.Aggergators;

namespace NeonBlue.Expressions.Tests.AggergatorsTests;

public class MinAggergatorUnitTest
{

    [Fact]
    public void TestMinAggregator()
    {
        double[] x = [1, 2, 3, 4, 5, 6];
        MinAggregator minAggregator = new();
        for (int i = 0; i < x.Length; i++)
        {
            minAggregator.Update(x[i]);
        }
        var res = minAggregator.Return();
        Assert.NotNull(res);
        Assert.True(res is double);
        double avg = Convert.ToDouble(res);
        Assert.Equal(1, avg);
    }
    [Fact]
    public void TestMinAggregatorWithNull()
    {
        double?[] x = [1, 2, null, 4, 5, 6];
        MinAggregator minAggregator = new();
        for (int i = 0; i < x.Length; i++)
        {
            minAggregator.Update(x[i]);
        }
        var res = minAggregator.Return();
        Assert.NotNull(res);
        Assert.True(res is double);
        double avg = Convert.ToDouble(res);
        Assert.Equal(1, avg);
    }

    [Fact]
    public void TestMinAggregatorWithDates()
    {
        DateTime[] x = [new DateTime(2024, 9, 1, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 2, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 3, 0, 0, 0, DateTimeKind.Utc),
            new DateTime(2024, 9, 4,0,0,0, DateTimeKind.Utc), new DateTime(2024, 9, 5,0,0,0, DateTimeKind.Utc), new DateTime(2024, 9, 6,0,0,0, DateTimeKind.Utc)];
        MinAggregator minAggregator = new();
        for (int i = 0; i < x.Length; i++)
        {
            minAggregator.Update(x[i]);
        }
        var res = minAggregator.Return();
        Assert.NotNull(res);
        Assert.True(res is DateTime);
        DateTime avg = Convert.ToDateTime(res);
        Assert.Equal(new DateTime(2024, 9, 1, 0, 0, 0, DateTimeKind.Utc), avg);
    }
    [Fact]
    public void Changing_data_type_should_throw_InvalidArgumentTypeExeception()
    {
        object?[] x = [1, "2", null, DateTime.Now, 5, 6];

        Assert.Throws<AggregateFunctionException>(() =>
        {
            MinAggregator minAggregator = new();
            for (int i = 0; i < x.Length; i++)
            {
                minAggregator.Update(x[i]);
            }
            minAggregator.Return();
        });

    }


}