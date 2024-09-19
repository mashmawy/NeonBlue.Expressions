using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators.ByteValue;
using NeonBlue.Expressions.Operators.DeicmalValue;
using NeonBlue.Expressions.Operators.DoubleValue;
using NeonBlue.Expressions.Operators.FloatValue;
using NeonBlue.Expressions.Operators.IntegerValue;
using NeonBlue.Expressions.Operators.LongValue;
using NeonBlue.Expressions.Operators.NullValue;
using NeonBlue.Expressions.Operators.StringValue;

namespace NeonBlue.Expressions.Operators
{

    public class PlusOperatorOverloads : IOperator
    {
        public TokenType OperatorType { get; } = TokenType.Plus;
        private readonly Dictionary<TokenType, OperatorsOverload> typesOverloads = [];

        public PlusOperatorOverloads()
        {
            AddIntegerOps();
            AddByteOps();
            AddLongOps();
            AddDeicmalOps();
            AddFloatOps();
            AddDoubleOps();
            AddStringOps();
            AddNullOps();
        }

        private void AddIntegerOps()
        {
            IntegerValue_PlusOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Integer, overloads);
        }

        private void AddByteOps()
        {
            ByteValue_PlusOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Byte, overloads);
        }

        private void AddLongOps()
        {
            LongValue_PlusOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Long, overloads);
        }

        private void AddDeicmalOps()
        {
            DecimalValue_PlusOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Decimal, overloads);
        }

        private void AddFloatOps()
        {
            FloatValue_PlusOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Float, overloads);
        }

        private void AddDoubleOps()
        {
            DoubleValue_PlusOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Double, overloads);
        }

        private void AddStringOps()
        {
            StringValue_PlusOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.String, overloads);
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