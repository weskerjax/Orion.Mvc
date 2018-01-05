using Orion.Mvc.Security;
using Orion.Mvc.UI;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Web.Mvc;
using Orion.API;

namespace TestRunWebApp.Controllers
{
	public class TestController : Controller
	{
		private MenuProvider _menuProvider;
		private BreadcrumbProvider _breadcrumbProvider;
		private ISignInManager _signInManager;

		public TestController(
			MenuProvider menuProvider,
			BreadcrumbProvider breadcrumbProvider,
			ISignInManager signInManager
		)
		{
			_menuProvider = menuProvider;
			_breadcrumbProvider = breadcrumbProvider;
			_signInManager = signInManager;
		}


		/*=================================================================*/




		//
		//[ActAuthorize(ACT.UserEdit, ACT.UserView)]
		public ActionResult Test()
		{

			var user = new OrionUserIdentity
			{
				UserId = 1,
				UserName = "Jax Hu",
				Account = "jax.hu",
				Name = "jax.hu",
			};

			_signInManager.SignIn(user, new string[]{
				ACT.UserView.ToString(),
				"ProgramView",
				"ProgramInsert",
				"ProgramUpdate",
				"PeoplePicsView",
				"PeoplePicsInsert",
				"SystemMng",

			});


			return Content("OK " + User.AnyAct(ACT.UserView));

		}



		public ActionResult Exception()
		{
			throw new OrionNoDataException("檢驗單列印記錄資料不存在");
		}







		public ActionResult NpoiTest()
		{

			var workbook = new XSSFWorkbook();
			ISheet sheet1 = workbook.CreateSheet("Sheet1");
			sheet1.CreateRow(0).CreateCell(0).SetCellValue("This is a Sample");

			int x = 1;
			for (int i = 1; i <= 15; i++)
			{
				IRow row = sheet1.CreateRow(i);
				for (int j = 0; j < 15; j++)
				{
					row.CreateCell(j).SetCellValue(x++);
				}
			}

			var stream = new MemoryStream();
			workbook.Write(stream);

			return File(stream.ToArray(), "application/vnd.ms-excel");
		}


	}
}