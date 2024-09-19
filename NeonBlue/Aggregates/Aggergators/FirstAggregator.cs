namespace NeonBlue.Expressions.Aggregates.Aggergators
{
    public class FirstAggregator : AggregatorBase
    {
        object? accumelated  ;

        public override void Update(object? val)
        {
            base.Update(val);
            if (accumelated is  null)
            {
                accumelated = val;
                return;
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


