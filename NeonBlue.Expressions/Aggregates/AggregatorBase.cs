namespace NeonBlue.Expressions.Aggregates
{
    public abstract class AggregatorBase : IAggregator
    {
        public Type? ValueType { get; private set; }
        public virtual void Update(object? val)
        {
            if (val is not null)
            {
                if (ValueType is null)
                {
                    ValueType = val.GetType();
                }
                else if (ValueType != val.GetType())
                {
                    throw new AggregateFunctionException($"value data type changed from {ValueType.Name} to {val.GetType().Name}");
                }
            }
        }

        public abstract object? Return();

        public abstract void Reset();

    }

}


