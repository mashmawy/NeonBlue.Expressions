namespace NeonBlue.Expressions.Aggregates.Aggergators
{
    public class MinAggregator : AggregatorBase
    {
        object? accumelated;
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
            if (val is int intVal)
            { 
                accumelated = Math.Min((int)accumelated, intVal);
            }
            else if (val is float floatVal)
            { 
                accumelated = Math.Min((float)accumelated, floatVal);
            }
            else if (val is decimal decimalVal)
            { 
                accumelated = Math.Min(Convert.ToDecimal(accumelated), decimalVal);
            }
            else if (val is double doubleVal)
            { 
                accumelated = Math.Min((double)accumelated, doubleVal);
            }
            else if (val is long longVal)
            { 
                accumelated = Math.Min((long)accumelated, longVal);
            }
            else if (val is byte byteVal)
            { 
                accumelated = Math.Min((int)accumelated, byteVal);
            }
            else if (val is string)
            {
                accumelated = val;
            }
            else if (val is bool)
            {
                accumelated = val;
            }
            else if (val is DateTime)
            {
                accumelated = Convert.ToDateTime(accumelated) > Convert.ToDateTime(val) ? val : accumelated;
            }
            else
            {
                throw new InvalidArgumentTypeException("Min", val.GetType(), $"Invalid Argument type {val.GetType().Name} for aggregate function Min");
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


