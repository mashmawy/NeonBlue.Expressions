﻿using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators;
using NeonBlue.Expressions.Functions.BooleanFunctions;

namespace NeonBlue.Expressions.Operators.ByteValue
{
    public class ByteValue_EqualOperatorOverloads : OperatorsOverload
    {
        public override Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            if (overloads.Count == 0)
            {
                overloads.Add(TokenType.Byte, ByteEqualInteger);
                overloads.Add(TokenType.Integer, ByteEqualInteger);
                overloads.Add(TokenType.Long, ByteEqualLong);
                overloads.Add(TokenType.Decimal, ByteEqualDecimal);
                overloads.Add(TokenType.Double, ByteEqualDouble);
                overloads.Add(TokenType.Float, ByteEqualFloat);
                overloads.Add(TokenType.NULL, ByteEqualNull);


            }
            return base.GetOverloads();
        }

        Token ByteEqualInteger(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            int arg2 = Convert.ToInt32(a2.Value);
            return new Token(arg1 == arg2, TokenType.Boolean);
        }

        Token ByteEqualLong(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            long arg2 = Convert.ToInt64(a2.Value);
            return new Token(arg1 == arg2, TokenType.Boolean);
        }

        Token ByteEqualDecimal(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            var arg2 = Convert.ToDecimal(a2.Value);
            return new Token(arg1 == arg2, TokenType.Boolean);
        }

        Token ByteEqualDouble(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            var arg2 = Convert.ToDouble(a2.Value);
            return new Token(arg1 == arg2, TokenType.Boolean);
        }
        Token ByteEqualFloat(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            var arg1 = Convert.ToByte(a1.Value);
            var arg2 = Convert.ToSingle(a2.Value);
            return new Token(arg1 == arg2, TokenType.Boolean);
        }

        Token ByteEqualNull(Token a1, Token a2, IExecutionOptions executionOptions)
        {
            return BooleanFunctionsUtils.NullCheck(a2, executionOptions.NullStrategy);

        }


    }
}