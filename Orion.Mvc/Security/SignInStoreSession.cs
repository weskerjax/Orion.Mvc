using System.Web;
using System.Web.Security;


namespace Orion.Mvc.Security
{
	/// <summary></summary>
	public class SignInStoreSession : ISignInStore
    {
        private static string _storeName = "UserTicket";


		/// <summary></summary>
		public FormsAuthenticationTicket Get()
        {
            if (HttpContext.Current.Session == null) { return null; }
            return (HttpContext.Current.Session[_storeName] as FormsAuthenticationTicket);
        }


		/// <summary></summary>
		public void Set(FormsAuthenticationTicket ticket)
        {
            HttpContext.Current.Session[_storeName] = ticket;
        }


		/// <summary></summary>
		public void Remove()
        {
            HttpContext.Current.Session[_storeName] = null;
        }
    }
}
