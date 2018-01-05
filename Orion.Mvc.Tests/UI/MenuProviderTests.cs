using Moq;
using System.Collections.Generic;
using System.Security.Principal;
using Xunit;
using System.Linq;
using Orion.API.Extensions;

namespace Orion.Mvc.UI.Tests
{
	public class MenuProviderTests
	{

		[Fact]
		public void RunTest()
		{
			var mock = new Mock<IPrincipal>();
			mock.Setup(y => y.IsInRole(It.IsAny<string>())).Returns(true);
			IPrincipal user = mock.Object;

			var provider = new MenuProvider("UI/Menu.config");
			var list = provider.GetAllowList(user, "/User/Create");
			Assert.NotEmpty(list);
		}



	}
}
