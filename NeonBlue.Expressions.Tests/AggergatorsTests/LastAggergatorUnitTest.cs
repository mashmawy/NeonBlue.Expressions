using NeonBlue.Expressions.Aggregates.Aggergators;

namespace NeonBlue.Expressions.Tests.AggergatorsTests
{
    public class LastAggergatorUnitTest
    {

        [Fact]
        public void TestLastAggregator()
        {
            double[] x = [1, 2, 2, 5, 5, 6];
            LastAggregator lastAggregator = new();
            for (int i = 0; i < x.Length; i++)
            {
                lastAggregator.Update(x[i]);
            }
            var res = lastAggregator.Return();
            Assert.NotNull(res);
            Assert.True(res.GetType() == typeof(double));
            double avg = Convert.ToDouble(res);
            Assert.Equal(6, avg);
        }
        [Fact]
        public void TestLastAggregatorWithNull()
        {
            double?[] x = [null, 2, null, 4, 5, 6];
            LastAggregator lastAggregator = new();
            for (int i = 0; i < x.Length; i++)
            {
                lastAggregator.Update(x[i]);
            }
            var res = lastAggregator.Return();
            Assert.NotNull(res);
            Assert.True(res.GetType() == typeof(double));
            double avg = Convert.ToDouble(res);
            Assert.Equal(6, avg);
        }
 
        [Fact]
        public void Changing_data_type_should_throw_InvalidArgumentTypeExeception()
        {
            object?[] x = [1, "2", null, DateTime.Now, 5, 6];

            Assert.Throws<AggregateFunctionException>(() =>
            {
                LastAggregator lastAggregator = new();
                for (int i = 0; i < x.Length; i++)
                {
                    lastAggregator.Update(x[i]);
                }
                var res = lastAggregator.Return();
            });

        }

    }
}