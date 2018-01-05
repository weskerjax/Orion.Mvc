using System.Collections.Generic;
using System.Web;


namespace Orion.Mvc.Security
{
	/// <summary></summary>
	public interface ISignInManager
	{
		/// <summary></summary>
		void Authenticate(HttpContext context);
	
		/// <summary></summary>
		void SignIn(OrionUserIdentity user, IEnumerable<string> actList, bool rememberBrowser = false);
	
		/// <summary></summary>
		void SignOut();


		/// <summary></summary>
		void DevelopSignIn(IList<string> actList);
	}
}
