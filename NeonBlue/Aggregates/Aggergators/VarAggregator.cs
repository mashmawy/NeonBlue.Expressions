using NeonBlue.Expressions.Exceptions;

namespace NeonBlue.Expressions.Aggregates.Aggergators
{ 
    public class VarAggregator : AggregatorBase
    {
        private int count;
        private double mean;
        private double M2;

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
                throw new InvalidArgumentTypeExeception
                       ("Var", val.GetType(), $"Invalid Argument type {val.GetType().Name} for aggregate function Var");

            }
            double new_value = Convert.ToDouble(val);

            count++;
            double delta = new_value - mean;
            mean += delta / count;
            double delta2 = new_value - mean;
            M2 += delta * delta2;

        }
        public override object? Return()
        {

            if (count < 2)
            {
                return double.NaN;
            }

            double variance = M2 / count;
            // double sample_variance = M2 / (count - 1);

            return variance;

        }
        public override void Reset()
        {
            count = 0;
            mean = 0;
            M2 = 0;

        }
    }



}


