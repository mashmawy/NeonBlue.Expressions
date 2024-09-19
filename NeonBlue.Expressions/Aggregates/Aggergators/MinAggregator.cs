using NeonBlue.Expressions;

namespace NeonBlue.Expressions.Aggregates.Aggergators
{
    public class MinAggregator : AggregatorBase
    {
        object? accumelated ; 
        public override void Update(object? val)
        {
            base.Update(val);
            if (accumelated is null)
            {
                accumelated = val;
                return;
            }
            
            if (val is null)
            {
                return;
            }
        
            if (val.GetType() == typeof(int))
            {

                accumelated = Math.Min((int)accumelated, (int)val);
            }
            else
            if (val.GetType() == typeof(float))
            {

                accumelated = Math.Min((float)accumelated, (float)val);
            }
            else
            if (val.GetType() == typeof(decimal))
            {

                accumelated = Math.Min(Convert.ToDecimal(accumelated), (decimal)val);
            }
            else
            if (val.GetType() == typeof(double))
            {

                accumelated = Math.Min((double)accumelated, (double)val);
            }
            else
            if (val.GetType() == typeof(long))
            {

                accumelated = Math.Min((long)accumelated, (long)val);
            }
            else
            if (val.GetType() == typeof(byte))
            {

                accumelated = Math.Min((int)accumelated, (byte)val);
            }
            else
            if (val.GetType() == typeof(string))
            {
                accumelated = val;
            }
            else
            if (val.GetType() == typeof(bool))
            {
                accumelated = val;
            }
            else
            if (val.GetType() == typeof(DateTime))
            {
                accumelated = Convert.ToDateTime(accumelated) > Convert.ToDateTime(val) ? val : accumelated;
            }
            else
            {
                throw new InvalidArgumentTypeExeception("Min", val.GetType(), $"Invalid Argument type {val.GetType().Name} for aggregate function Min");
            }
        }
        public override object? Return()
        {
            return accumelated;
        }
        public override void Reset()
        {
            accumelated = null;
        }
    }
}


