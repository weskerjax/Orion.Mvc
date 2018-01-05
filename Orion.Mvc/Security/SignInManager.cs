using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Web;
using System.Web.Security;


namespace Orion.Mvc.Security
{
	/// <summary></summary>
	public class SignInManager : ISignInManager
    {
        private ISignInStore _store;

		/// <summary></summary>
		public SignInManager(ISignInStore store)
        {
            _store = store;
        }




		/// <summary></summary>
		public void Authenticate(HttpContext context)
        {
            FormsAuthenticationTicket ticket = _store.Get();
            if (ticket == null) { return;  }

            JObject info = JObject.Parse(ticket.UserData);
            if (info == null) { return; }


            var identity = new OrionUserIdentity
            {
                Name = ticket.Name,
                UserId = (int)info["UserId"],
                UserName = (string)info["UserName"],
                Account = ticket.Name,
                AuthenticationType = "site",
                IsAuthenticated = true,
            };

            string[] roles = ((string)info["ActList"]).Split(',');
            context.User = new GenericPrincipal(identity, roles);
        }




		/// <summary></summary>
		public void SignIn(OrionUserIdentity user, IEnumerable<string> actList, bool rememberBrowser = false)
        {

            string userData = JsonConvert.SerializeObject(new
            {
                user.UserId,            
                user.UserName,
                ActList = String.Join(",", actList)
            });


            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1,
                user.Name, 
                DateTime.Now,
                DateTime.Now.AddMinutes(rememberBrowser ? 518400 : 120),
				rememberBrowser, /*將管理者登入的 Cookie 設定成 Session Cookie*/
                userData, 
                FormsAuthentication.FormsCookiePath
            );

            _store.Set(ticket);
        }




		/// <summary></summary>
		public void SignOut()
        {
            _store.Remove();
        }



		/// <summary></summary>
		public void DevelopSignIn(IList<string> actList)
        {
            var identity = new OrionUserIdentity
            {
                UserId = 1,
                UserName = "Admin",
                Account = "admin",
                Name = "admin",
            };

            SignIn(identity, actList);
        }






    }

}
