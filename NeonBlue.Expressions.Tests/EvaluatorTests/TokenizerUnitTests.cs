using NeonBlue.Expressions.Functions;
using NeonBlue.Expressions.Tokenization;

namespace NeonBlue.Expressions.Tests.EvaluatorTests
{
    public class TokenizerUnitTests
    {

        [Fact]
        public void TestName()
        { 
            Tokenizer t = new(" this is  just a random  text"); 
             var tokens= t.Tokenize(new FunctionsLookup());
            Assert.Equal(6, tokens.Count);
            
        }
    }
}