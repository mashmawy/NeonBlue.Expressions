using NeonBlue.Expressions.Aggregates.Aggergators;

namespace NeonBlue.Expressions.Aggregates
{
    public class AggregatedExpressionPart
    {
        public readonly List<string> Variables = [];
        public string Expression { get; set; }
        public string Id { get; set; }
        public string AggregateType { get; set; } 
        Dictionary<string, IAggregator?> Aggregators { get; set; } =[];
        public IAggregator? GetAggregator(string key)
        {
            if (Aggregators.TryGetValue(key, out IAggregator? val))
            {
                return val;
            }

            val = CreateAggregator(AggregateType);

            
            Aggregators.Add(key, val);

            return val;
        }
        public static IAggregator? CreateAggregator(string AggregateType)
        {
            IAggregator? val = null;
           
            if (AggregateType == "sum")
            {
                val = new SumAggregator();
            }
            if (AggregateType == "count")
            {
                val = new CountAggregator();
            }
            if (AggregateType == "countd")
            {
                val = new CountDistinctAggregator();
            }
            if (AggregateType == "max")
            {
                val = new MaxAggregator();
            }
            if (AggregateType == "min")
            {
                val = new MinAggregator();
            }
            if (AggregateType == "first")
            {
                val = new FirstAggregator();
            }
            if (AggregateType == "last")
            {
                val = new LastAggregator();
            }
            if (AggregateType == "avg")
            {
                val = new AvgAggregator();
            }
            if (AggregateType == "var")
            {
                val = new VarAggregator();
            }
            if (AggregateType == "std")
            {
                val = new StdAggregator();
            }
            if (AggregateType == "mean")
            {
                val = new MeanAggregator();
            }
            return val;
        }
        public static bool IsAggregate(string AggregateType)
        {
            if (AggregateType == "sum")
            {
                return true;
            }
            if (AggregateType == "count")
            {
                return true;
            }
            if (AggregateType == "countd")
            {
                return true;
            }
            if (AggregateType == "max")
            {
                return true;
            }
            if (AggregateType == "min")
            {
                return true;
            }
            if (AggregateType == "first")
            {
                return true;
            }
            if (AggregateType == "last")
            {
                return true;
            }
            if (AggregateType == "avg")
            {
                return true;
            }
            if (AggregateType == "var")
            {
                return true;
            }
            if (AggregateType == "std")
            {
                return true;
            }
            if (AggregateType == "mean")
            {
                return true;
            }
            return false;
        }
        public AggregatedExpressionPart(string expression, string id, string aggregateType ,IEnumerable<string> variables)
        {
            Expression = expression;
            Id = id;
            AggregateType = aggregateType; 
            Variables.AddRange(variables);
        }
    } 
}


