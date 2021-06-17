using Contracts;
using Moq;
using NUnit.Framework;

namespace PriceComparerAPI.Tests
{
    [TestFixture]
    public abstract class TestInitializer
    {
        protected static Mock<ICatalogRepository> mockICatalogRepository;


        [SetUp]
        protected virtual void Initialize()
        {
            mockICatalogRepository = new Mock<ICatalogRepository>();

            TestContext.WriteLine("Initialize test data");
        }

        [TearDown]
        protected virtual void Cleanup()
        {
            TestContext.WriteLine("Cleanup test data");
        }
    }
}