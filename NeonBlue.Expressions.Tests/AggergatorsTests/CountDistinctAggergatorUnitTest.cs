using NeonBlue.Expressions.Aggregates.Aggergators;

namespace NeonBlue.Expressions.Tests.AggergatorsTests
{
    public class CountDistinctAggergatorUnitTest
    {

        [Fact]
        public void TestCountDistinctAggregator()
        {
            double[] x = [1, 2, 2, 5, 5, 6];
            CountDistinctAggregator cntAggregator = new();
            for (int i = 0; i < x.Length; i++)
            {
                cntAggregator.Update(x[i]);
            }
            var res = cntAggregator.Return();
            Assert.NotNull(res);
            Assert.True(res is int);
            int avg = Convert.ToInt32(res);
            Assert.Equal(4, avg);
        }
        [Fact]
        public void TestCountDistinctAggregatorWithNull()
        {
            double?[] x = [1, 2, null, 4, 5, 6];
            CountDistinctAggregator cntAggregator = new();
            for (int i = 0; i < x.Length; i++)
            {
                cntAggregator.Update(x[i]);
            }
            var res = cntAggregator.Return();
            Assert.NotNull(res);
            Assert.True(res is int);
            int avg = Convert.ToInt32(res);
            Assert.Equal(5, avg);
        }
 

    [Fact]
    public void Changing_data_type_should_throw_InvalidArgumentTypeExeception()
    {
        object?[] x = [1, "2", null, DateTime.Now, 5, 6];

        Assert.Throws<AggregateFunctionException>(() =>
        {
            CountDistinctAggregator cntAggregator = new();
            for (int i = 0; i < x.Length; i++)
            {
                cntAggregator.Update(x[i]);
            }
            var res = cntAggregator.Return();
        });

    }
    }
}