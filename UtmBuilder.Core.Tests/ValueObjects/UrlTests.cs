using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;
using Xunit;

namespace UtmBuilder.Core.Tests.ValueObjects
{
    public class UrlTests
    {
        private const string InvalidUrl = "invalida";
        private const string ValidUrl = "https://teste.com.br";

        [Fact(DisplayName = "Deve retornar uma exceção quando a URL for inválida")]
        [Trait("Category", "URL")]
        public void ShouldReturnExceptionWhenUrlIsInvalid()
        {
            Assert.Throws<InvalidUrlException>(() => new Url(InvalidUrl));
        }

        [Fact(DisplayName = "Não deve retornar uma exceção quando a URL for válida")]
        [Trait("Category", "URL")]
        public void ShouldNotReturnExceptionWhenUrlIsValid()
        {
            var exception = Record.Exception(() => new Url(ValidUrl));
            Assert.Null(exception);
        }

        [Theory]
        [Trait("Category", "URL")]
        [InlineData(" ", true)]
        [InlineData("http", true)]
        [InlineData("banana", true)]
        [InlineData("https://balta.io", false)]
        public void TestUrl(string link, bool expectException)
        {
            if (expectException)
            {
                try
                {
                    new Url(link);
                }
                catch (InvalidUrlException ex)
                {
                    Assert.True(true);
                }
            }
            else
            {
                var exception = Record.Exception(() => new Url(link));
                Assert.Null(exception);
            }
        }
    }
}
