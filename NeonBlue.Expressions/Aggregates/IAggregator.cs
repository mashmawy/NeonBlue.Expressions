namespace NeonBlue.Expressions.Aggregates
{
    public interface IAggregator
    {
        void Update(object? val);
        object? Return();
        void Reset();
    }
}


