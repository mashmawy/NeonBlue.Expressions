using NeonBlue.Expressions.Operators.BooleanValue;
using NeonBlue.Expressions.Operators.ByteValue;
using NeonBlue.Expressions.Operators.DatetimeValue;
using NeonBlue.Expressions.Operators.DeicmalValue;
using NeonBlue.Expressions.Operators.DoubleValue;
using NeonBlue.Expressions.Operators.FloatValue;
using NeonBlue.Expressions.Operators.IntegerValue;
using NeonBlue.Expressions.Operators.LongValue;
using NeonBlue.Expressions.Operators.NullValue;
using NeonBlue.Expressions.Operators.StringValue;

namespace NeonBlue.Expressions.Operators
{
    public class EqualOperatorOverloads : IOperator
    {
        public TokenType OperatorType { get; } = TokenType.Equal;
        private readonly Dictionary<TokenType, OperatorsOverload> typesOverloads = [];

        public EqualOperatorOverloads()
        {
            AddDoubleOps();
            AddIntegerOps();
            AddByteOps();
            AddLongOps();
            AddDecimalOps();
            AddFloatOps();
            AddStringOps();
            AddDateTimeOps();
            // AddObjectOps();
            AddBooleanOps();
            AddNullOps();
        }

        private void AddIntegerOps()
        {
            IntegerValue_EqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Integer, overloads);
        }

        private void AddByteOps()
        {
            ByteValue_EqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Byte, overloads);
        }

        private void AddLongOps()
        {
            LongValue_EqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Long, overloads);

        }

        private void AddDecimalOps()
        {
            DecimalValue_EqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Decimal, overloads);
        }

        private void AddFloatOps()
        {
            FloatValue_EqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Float, overloads);
        }

        private void AddDoubleOps()
        {
            DoubleValue_EqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Double, overloads);

        }

        private void AddBooleanOps()
        {
            BooleanValue_EqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Boolean, overloads);
        }

        // private  void AddObjectOps()
        // {
        //     ObjectValue_EqualOperatorOverloads overloads = new();
        //     typesOverloads.Add(TokenType.Object, overloads); 
        // }

        private void AddDateTimeOps()
        {
            DatetimeValue_EqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Datetime, overloads);

        }

        private void AddStringOps()
        {
            StringValue_EqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.String, overloads);

        }

        private void AddNullOps()
        {
            NullValue_CompareOperatorsOverloads overloads = new();
            typesOverloads.Add(TokenType.NULL, overloads);
        }
        public Token Run(Token operand1, Token operand2, IExecutionOptions executionOptions)
        {
            if (typesOverloads.TryGetValue(operand1.TokenType, out OperatorsOverload? overloads))
            {
                return overloads.Evaluate(operand1, operand2, executionOptions);
            }
            throw new InvalidOperationException();
        }
    }
}