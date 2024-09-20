namespace NeonBlue.Expressions.Aggregates.Aggergators
{
    public class MeanAggregator : AggregatorBase
    {
        private int count;
        private double mean;

        public override void Update(object? val)
        {
            base.Update(val);
            if (val is null) return;

            if (val.GetType() != typeof(double) &&
             val.GetType() != typeof(int) &&
             val.GetType() != typeof(byte) &&
             val.GetType() != typeof(long) &&
             val.GetType() != typeof(float) &&
             val.GetType() != typeof(decimal))
            {
                throw new InvalidArgumentTypeException
                       ("Mean", val.GetType(), $"Invalid Argument type {val.GetType().Name} for aggregate function Mean");

            }
            var new_value = Convert.ToDouble(val); count++;
            double delta = new_value - mean;
            mean += delta / count;

        }
        public override object? Return()
        {

            if (count < 2)
            {
                return double.NaN;
            }

            return mean;

        }
        public override void Reset()
        {
            count = 0;
            mean = 0;

        }
    }



}


