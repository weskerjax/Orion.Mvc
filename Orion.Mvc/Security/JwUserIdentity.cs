using System.Security.Principal;


namespace Orion.Mvc.Security
{
	/// <summary></summary>
	public class OrionUserIdentity : IIdentity
    {
		/// <summary></summary>
		public int UserId { get; set; }

		/// <summary></summary>
		public string UserName { get; set; }

		/// <summary></summary>
		public string Account { get; set; }

		/// <summary></summary>
		public string Name { get; set; }

		/// <summary></summary>
		public string AuthenticationType { get; set; }

		/// <summary></summary>
		public bool IsAuthenticated { get; set; }
    }
}
