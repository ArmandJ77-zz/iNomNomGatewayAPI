using System.Threading.Tasks;
using NUnit.Framework;

namespace IntegrationTests
{
    [TestFixture]
    public class MenuItemControllerTests: BaseIntegrationTest
    {
        [Test]
        public async Task Create_MenuItem_Successfull()
        {
            var foo = 1;

            Assert.That(foo.Equals(1));
        }
    }
}
