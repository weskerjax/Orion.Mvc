using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace TestRunWebApp.Models
{
	public class HtmlViewModel
	{
		[Required]
		[Display(Name="Id")]
		public int Id { get; set; }

		[Required]
		[AllowHtml]
		[Display(Name = "Content")]
		public string Content { get; set; }

	}
}