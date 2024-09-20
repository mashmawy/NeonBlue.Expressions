using NeonBlue.Expressions;

namespace NeonBlue.Expressions.Aggregates.Aggergators
{
    public class SumAggregator : AggregatorBase
    {
        object? accumelated;

       
        public override void Update(object? val)
        {
            base.Update(val);
            if (accumelated == null)
            {
                accumelated = val;
                return;
            }
            else
            if (val is null)
            {
                return;
            }
            else
            if (val.GetType() == typeof(int))
            {

                accumelated = (int)accumelated + (int)val;
            }
            else
            if (val.GetType() == typeof(float))
            {

                accumelated = (float)accumelated + (float)val;
            }
            else
            if (val.GetType() == typeof(decimal))
            {

                accumelated = Convert.ToDecimal(accumelated) + (decimal)val;
            }
            else
            if (val.GetType() == typeof(double))
            {

                accumelated = (double)accumelated + (double)val;
            }
            else
            if (val.GetType() == typeof(long))
            {

                accumelated = (long)accumelated + (long)val;
            }
            else
            if (val.GetType() == typeof(byte))
            {

                accumelated = (int)accumelated + (byte)val;
            }
            else
            {
                throw new InvalidArgumentTypeException("Sum", val.GetType(), $"Invalid Argument type {val.GetType().Name} for aggregate function Sum");
            }
        }
        public override object Return()
        {
            return accumelated ?? 0;
        }
        public override void Reset()
        {
            accumelated = 0;
        }
    }
}


