using NeonBlue.Expressions.Operators.ByteValue;
using NeonBlue.Expressions.Operators.DatetimeValue;
using NeonBlue.Expressions.Operators.DeicmalValue;
using NeonBlue.Expressions.Operators.DoubleValue;
using NeonBlue.Expressions.Operators.FloatValue;
using NeonBlue.Expressions.Operators.IntegerValue;
using NeonBlue.Expressions.Operators.LongValue;
using NeonBlue.Expressions.Operators.NullValue;

namespace NeonBlue.Expressions.Operators
{
    public class GreaterThanOrEqualOperatorOverloads : IOperator
    {
        public TokenType OperatorType { get; } = TokenType.GreaterThanOrEqual;
        private readonly Dictionary<TokenType, OperatorsOverload> typesOverloads = [];

        public GreaterThanOrEqualOperatorOverloads()
        {
            AddIntegerOps();
            AddByteOps();
            AddLongOps();
            AddDeicmalOps();
            AddFloatOps();
            AddDoubleOps();
            AddDateTimeOps();
            AddNullOps();
        }

        private void AddIntegerOps()
        {
            IntegerValue_GreaterThanOrEqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Integer, overloads);
        }

        private void AddByteOps()
        {

            ByteValueGreaterThanOrEqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Byte, overloads);

        }

        private void AddLongOps()
        {

            LongValue_GreaterThanOrEqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Long, overloads);
        }

        private void AddDeicmalOps()
        {
            DecimalValue_GreaterThanOrEqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Decimal, overloads);

        }

        private void AddFloatOps()
        {
            FloatValue_GreaterThanOrEqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Float, overloads);
        }

        private void AddDoubleOps()
        {
            DoubleValue_GreaterThanOrEqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Double, overloads);


        }



        private void AddDateTimeOps()
        {
            DatetimeValue_GreaterThanOrEqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Datetime, overloads);
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