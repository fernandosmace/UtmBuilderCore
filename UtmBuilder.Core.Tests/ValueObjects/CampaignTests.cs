using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;
using Xunit;

namespace UtmBuilder.Core.Tests.ValueObjects
{
    public class CampaignTests
    {
        [Fact(DisplayName = "Deve retornar uma exceção quando Source for inválido")]
        [Trait("Category", "Campaign")]
        public void ShouldReturnExceptionWhenSourceIsNull()
        {
            Assert.Throws<InvalidCampaignException>(() => new Campaign("", "teste", "teste"));
        }

        [Fact(DisplayName = "Deve retornar uma exceção quando Medium for inválido")]
        [Trait("Category", "Campaign")]
        public void ShouldReturnExceptionWhenMediumIsNull()
        {
            Assert.Throws<InvalidCampaignException>(() => new Campaign("teste", "", "teste"));
        }

        [Fact(DisplayName = "Deve retornar uma exceção quando Name for inválido")]
        [Trait("Category", "Campaign")]
        public void ShouldReturnExceptionWhenNameIsNull()
        {
            Assert.Throws<InvalidCampaignException>(() => new Campaign("teste", "teste", ""));
        }

        [Fact(DisplayName = "Deve retornar uma exceção quando Name for inválido")]
        [Trait("Category", "Campaign")]
        public void ShouldNotReturnExceptionWhenCampaignIsValid()
        {
            var exception = Record.Exception(() => new Campaign("teste", "teste", "teste"));
            Assert.Null(exception);
        }
    }
}
