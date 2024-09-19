namespace NeonBlue.Expressions
{
    public class ExpressionParameter
    {
        public string Name { get; }
        public object? Value { get; }
        public bool IsArray { get; } = false;
        public int ArrayLength { get; }
        public ExpressionParameter(string name, object? value)
        {
            Name = name;
            Value = value;
            if (Value is not null)
            {
                IsArray = Value.GetType().IsArray;
                if (IsArray)
                    ArrayLength = ((Array)value!).Length;
            }
        }

    }

}