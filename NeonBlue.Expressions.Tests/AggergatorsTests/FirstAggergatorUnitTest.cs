using NeonBlue.Expressions.Aggregates.Aggergators;
using NeonBlue.Expressions;

namespace NeonBlue.Expressions.Tests.AggergatorsTests
{
    public class FirstAggergatorUnitTest
    {

        [Fact]
        public void TestFirstAggregator()
        {
            double[] x = [1, 2, 2, 5, 5, 6];
            FirstAggregator firstAggregator = new();
            for (int i = 0; i < x.Length; i++)
            {
                firstAggregator.Update(x[i]);
            }
            var res = firstAggregator.Return();
            Assert.NotNull(res);
            Assert.True(res.GetType() == typeof(double));
            double avg = Convert.ToDouble(res);
            Assert.Equal(1, avg);
        }
        [Fact]
        public void TestFirstAggregatorWithNull()
        {
            double?[] x = [null, 2, null, 4, 5, 6];
            FirstAggregator firstAggregator = new();
            for (int i = 0; i < x.Length; i++)
            {
                firstAggregator.Update(x[i]);
            }
            var res = firstAggregator.Return();
            Assert.NotNull(res);
            Assert.True(res.GetType() == typeof(double));
            double avg = Convert.ToDouble(res);
            Assert.Equal(2, avg);
        }

        [Fact]
        public void Changing_data_type_should_throw_InvalidArgumentTypeExeception()
        {
            object?[] x = [1, "2", null, DateTime.Now, 5, 6];

            Assert.Throws<AggregateFunctionException>(() =>
            {
                FirstAggregator firstAggregator = new();
                for (int i = 0; i < x.Length; i++)
                {
                    firstAggregator.Update(x[i]);
                }
                var res = firstAggregator.Return();
            });

        }

    }
}