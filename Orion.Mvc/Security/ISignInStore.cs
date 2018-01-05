using System.Web.Security;


namespace Orion.Mvc.Security
{
	/// <summary></summary>
	public interface ISignInStore
    {
		/// <summary></summary>
		FormsAuthenticationTicket Get();
		
		/// <summary></summary>
		void Set(FormsAuthenticationTicket ticket);
		
		/// <summary></summary>
		void Remove();
    }
}
