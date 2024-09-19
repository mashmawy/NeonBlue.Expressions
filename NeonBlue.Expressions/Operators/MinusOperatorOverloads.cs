using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators.ByteValue;
using NeonBlue.Expressions.Operators.DeicmalValue;
using NeonBlue.Expressions.Operators.DoubleValue;
using NeonBlue.Expressions.Operators.FloatValue;
using NeonBlue.Expressions.Operators.IntegerValue;
using NeonBlue.Expressions.Operators.LongValue;
using NeonBlue.Expressions.Operators.NullValue;

namespace NeonBlue.Expressions.Operators
{
    public class MinusOperatorOverloads : IOperator
    {
        public TokenType OperatorType { get; } = TokenType.Minuse;
        private readonly Dictionary<TokenType, OperatorsOverload> typesOverloads = [];

        public MinusOperatorOverloads()
        {
            AddIntegerOps();
            AddByteOps();
            AddLongOps();
            AddDeicmalOps();
            AddFloatOps();
            AddDoubleOps();
            AddNullOps();
        }

        private void AddIntegerOps()
        {
            IntegerValue_MinusOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Integer, overloads);
        }

        private void AddByteOps()
        {
            ByteValue_MinusOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Byte, overloads);
        }

        private void AddLongOps()
        {
            LongValue_MinusOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Long, overloads);
        }

        private void AddDeicmalOps()
        {
            DecimalValue_MinusOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Decimal, overloads);
        }

        private void AddFloatOps()
        {
            FloatValue_MinusOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Float, overloads);
        }

        private void AddDoubleOps()
        {

            DoubleValue_MinusOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Double, overloads);
        }

        private void AddNullOps()
        {
            NullValue_MathOperatorsOverloads overloads = new();
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