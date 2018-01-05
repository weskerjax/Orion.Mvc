using System.Linq;
using Xunit;


namespace Orion.Mvc.UI.Tests
{
    public class BreadcrumbProviderTests
    {
        [Fact]
        public void RunTest()
        {
            var provider = new BreadcrumbProvider("UI/Breadcrumb.config");
            var last = provider.GetPathList("/User/Create").Last();

            Assert.Equal(last.Name, "新增");
            Assert.Equal(last.Url, "~/User/Create");
        }


    }
}
