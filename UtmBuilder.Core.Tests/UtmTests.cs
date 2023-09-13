using UtmBuilder.Core.ValueObjects;
using Xunit;

namespace UtmBuilder.Core.Tests
{
    public class UtmTests
    {
        private const string _result = "https://balta.io/?utm_source=src&utm_medium=med&utm_campaign=nme&utm_id=id&utm_term=term&utm_content=content";
        private readonly Url _url = new("https://balta.io/");
        private readonly Campaign _campaign = new(
            "src",
            "med",
            "nme",
            "id",
            "term",
            "content"
        );

        [Fact]
        public void ShouldReturnUrlFromUtm()
        {
            var utm = new Utm(_url, _campaign);

            Assert.Equal(utm.ToString(), _result);
            Assert.Equal((string)utm, _result);
        }

        [Fact]
        public void ShouldReturnUtmFromUrl()
        {
            Utm utm = _result;
            Assert.Equal(utm.Url.Address, "https://balta.io/");
            Assert.Equal(utm.Campaign.Source, "src");
            Assert.Equal(utm.Campaign.Medium, "med");
            Assert.Equal(utm.Campaign.Name, "nme");
            Assert.Equal(utm.Campaign.Id, "id");
            Assert.Equal(utm.Campaign.Term, "term");
            Assert.Equal(utm.Campaign.Content, "content");
        }
    }
}
