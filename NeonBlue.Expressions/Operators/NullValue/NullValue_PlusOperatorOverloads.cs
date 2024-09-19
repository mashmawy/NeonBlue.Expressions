// using NeonBlue.Expressions;

// namespace NeonBlue.Expressions.Operators.NullValue
// {
//     public class NullValue_PlusStringOperatorOverloads:OperatorsOverload
//     {
       
//         public override Dictionary<TokenType, Func<Token, Token,IExecutionOptions, Token>> GetOverloads()
//         {
//             if (overloads.Count == 0)
//             {
//                 overloads.Add(TokenType.Integer, NullPlusNumeric);
//                 overloads.Add(TokenType.Byte, NullPlusNumeric);
//                 overloads.Add(TokenType.Float, NullPlusNumeric);
//                 overloads.Add(TokenType.Long, NullPlusNumeric);
//                 overloads.Add(TokenType.Double, NullPlusNumeric);
//                 overloads.Add(TokenType.Decimal, NullPlusNumeric);
//                 overloads.Add(TokenType.NULL, NullPlusNonNumeric);
//                 overloads.Add(TokenType.String, NullPlusNonNumeric);
//             }
//             return base.GetOverloads();
//         }
//         Token NullPlusNonNumeric(Token a1,Token a2, IExecutionOptions executionOptions)
//         {
//             if (executionOptions.NullStrategy == NullStrategy.Default)
//             {
//                 return a2;
//             }
//             else if (executionOptions.NullStrategy == NullStrategy.Propagate)
//             {
//                 return new Token(null, TokenType.NULL);
//             }
//             else
//             {
//                 throw new NullTokenExecption(a1);
//             }
//         }
//         Token NullPlusNumeric(Token a1,Token a2, IExecutionOptions executionOptions)
//         {

//             if (executionOptions.NullStrategy == NullStrategy.Throw)
//             {
//                 throw new NullTokenExecption(a1);
//             }
//             else
//             {
//                 return new Token(null, TokenType.NULL);
//             }
//         } 

//     }
// }