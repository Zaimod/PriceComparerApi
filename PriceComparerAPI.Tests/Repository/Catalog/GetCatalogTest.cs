using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceComparerAPI.Tests.Repository.Catalog
{
    public class GetCatalogTest : TestInitializer
    {
        private CatalogRepositoryForTest catalogRepositoryForTest;

        [SetUp]
        protected override void Initialize()
        {
            base.Initialize();
            catalogRepositoryForTest = mockICatalogRepository
        }

    }
}
