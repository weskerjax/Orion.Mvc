using Orion.API.Models;
using Orion.Mvc.Attributes;
using Orion.Mvc.UI;
using System.Collections.Generic;
using System.Web.Mvc;
using TestRunWebApp.Models;
using System;

namespace TestRunWebApp.Controllers
{
	public class HomeController : Controller
	{

		private MenuProvider _menuProvider;
		private BreadcrumbProvider _breadcrumbProvider;


		public HomeController(
			MenuProvider menuProvider,
			BreadcrumbProvider breadcrumbProvider
		)
		{
			_menuProvider = menuProvider;
			_breadcrumbProvider = breadcrumbProvider;
		}




		[SearchRemember(Ignore = new[] { "f" })]
		public ActionResult Index(TestParamsViewModel vm)
		{
			return View();
		}


		public ActionResult Sidebar()
		{
			var vm = _menuProvider.GetAllowList(User, Request.Url.PathAndQuery);
			return PartialView(vm);
		}

		public ActionResult Breadcrumb()
		{
			var vm = _breadcrumbProvider.GetPathList(Request.Url.LocalPath);
			return PartialView(vm);
		}



		public ActionResult WhereParamsTest(WhereParams<TestParamsViewModel> param)
		{
			return View();
		}


		public ActionResult TimeSpanTest(TestParamsViewModel vm)
		{
			vm.Floor = new List<Floor> { Floor.F1, Floor.F2 };

			return View();
		}

		public ActionResult EnumCheckboxTest(TestParamsViewModel vm)
		{
			vm.Floor = new List<Floor>{ Floor.F1, Floor.F2 };

			return View();
		}


		public ActionResult CnDateTimeTest(TestParamsViewModel vm)
		{
			var isValid = ModelState.IsValid;

			return View(vm);
		}


		public ActionResult CnDateTimeTest2(DateTime? modifyDate = null)
		{
			return View();
		}


		public ActionResult BsRadioList()
		{
			return View();
		}

		public ActionResult ListBsRadioList(List<TestParamsViewModel> vmList)
		{
			if (vmList == null) { vmList = new List<TestParamsViewModel>(); }

			vmList.Add(new TestParamsViewModel { InvoicePrefix = "W" });

			return View(vmList);
		}

		public ActionResult BsBoolRadioList(TestParamsViewModel vm)
		{
			return View(vm);
		}

		public ActionResult DropDownList(TestParamsViewModel vm)
		{

			vm.InvoicePrefix = "Y";
			return View(vm);
		}


		
		public ActionResult HtmlExcelExport()
		{
			return View();
		}


		public ActionResult HtmlTest(HtmlViewModel vm)
		{
			var isValid = ModelState.IsValid;

			//vm.Content = "<p></p>";
			return View(vm);
		}




	}
}