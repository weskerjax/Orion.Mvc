using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestRunWebApp.Models
{
	public class TestParamsViewModel
	{

		/// <summary>數量</summary>
		public int? ProductQty { get; set; }

		/// <summary>總計</summary>
		public decimal Sum { get; set; }

		/// <summary>發票字軌</summary>
		[Display(Name= "發票字軌")]
		public string InvoicePrefix { get; set; }

		public TimeSpan TimeSpan { get; set; }

		public List<Floor> Floor { get; set; }

		public bool IsEnable { get; set; }

		/// <summary>修改者 Id</summary>
		public int ModifyBy { get; set; }

		/// <summary>修改時間</summary>
		public DateTime ModifyDate { get; set; }

		/// <summary>修改時間</summary>
		public DateTime? ModifyDate2 { get; set; }

	}
}