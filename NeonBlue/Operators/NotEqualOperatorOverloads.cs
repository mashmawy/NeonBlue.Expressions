using NeonBlue.Expressions;
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
    public class NotEqualOperatorOverloads : IOperator
    {

        public TokenType OperatorType { get; } = TokenType.NotEqual;
        private readonly Dictionary<TokenType, OperatorsOverload> typesOverloads = [];


        public NotEqualOperatorOverloads()
        {
            AddIntegerOps();
            AddByteOps();
            AddLongOps();
            AddDeicmalOps();
            AddFloatOps();
            AddDoubleOps();
            AddBooleanOps();
            AddStringOps();
            AddDateTimeOps();
            AddNullOps();
        }

        private void AddIntegerOps()
        {
            IntegerValue_NotEqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Integer, overloads);
        }

        private void AddByteOps()
        {
            ByteValue_NotEqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Byte, overloads);
        }

        private void AddLongOps()
        {
            LongValue_NotEqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Long, overloads);
        }

        private void AddDeicmalOps()
        {
            DecimalValue_NotEqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Decimal, overloads);
        }

        private void AddFloatOps()
        {
            FloatValue_NotEqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Float, overloads);
        }

        private void AddDoubleOps()
        {
            DoubleValue_NotEqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Double, overloads);
        }

        private void AddBooleanOps()
        {
            BooleanValue_NotEqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Boolean, overloads);
        }



        private void AddDateTimeOps()
        {
            DatetimeValue_NotEqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Datetime, overloads);
        }

        private void AddStringOps()
        {
            StringValue_NotEqualOperatorOverloads overloads = new();
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