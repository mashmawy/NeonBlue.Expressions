using NeonBlue.Expressions.Aggregates.Aggergators;

namespace NeonBlue.Expressions.Tests.AggergatorsTests
{
    public class CountAggergatorUnitTest
    {

        [Fact]
        public void TestCountAggregator()
        {
            double[] x = [1, 2, 3, 4, 5, 6];
            CountAggregator cntAggregator = new();
            for (int i = 0; i < x.Length; i++)
            {
                cntAggregator.Update(x[i]);
            }
            var res = cntAggregator.Return();
            Assert.NotNull(res);
            Assert.True(res.GetType() == typeof(int));
            int avg = Convert.ToInt32(res);
            Assert.Equal(6, avg);
        }
        [Fact]
        public void TestCountAggregatorWithNull()
        {
            double?[] x = [1, 2, null, 4, 5, 6];
            CountAggregator cntAggregator = new();
            for (int i = 0; i < x.Length; i++)
            {
                cntAggregator.Update(x[i]);
            }
            var res = cntAggregator.Return();
            Assert.NotNull(res);
            Assert.True(res.GetType() == typeof(int));
            int avg = Convert.ToInt32(res);
            Assert.Equal(6, avg);
        }
 

    [Fact]
    public void Changing_data_type_should_throw_InvalidArgumentTypeExeception()
    {
        object?[] x = [1, "2", null, DateTime.Now, 5, 6];

        Assert.Throws<AggregateFunctionException>(() =>
        {
            CountAggregator cntAggregator = new();
            for (int i = 0; i < x.Length; i++)
            {
                cntAggregator.Update(x[i]);
            }
            var res = cntAggregator.Return();
        });

    }
    }
}