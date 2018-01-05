using System.ComponentModel.DataAnnotations;

namespace TestRunWebApp.Models
{
	/// <summary>樓層</summary>
	public enum Floor
	{
		/// <summary>無</summary>
		[Display(Name = "無")]
		None,

		/// <summary>1樓</summary>
		[Display(Name = "1樓")]
		F1,

		/// <summary>2樓</summary>
		[Display(Name = "2樓")]
		F2,

		/// <summary>3樓</summary>
		[Display(Name = "3樓")]
		F3,

		/// <summary>4樓</summary>
		[Display(Name = "4樓")]
		F4,
	}

}
