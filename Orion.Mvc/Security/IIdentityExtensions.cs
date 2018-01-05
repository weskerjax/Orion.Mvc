using System;
using System.Security.Principal;


namespace Orion.Mvc.Security
{
	/// <summary></summary>
	public static class IIdentityExtensions
	{
		private static OrionUserIdentity getUserIdentity(IIdentity identity)
		{
			if (identity == null) { throw new ArgumentNullException("identity"); }
			return identity as OrionUserIdentity;
		}


		/// <summary></summary>
		public static int GetUserId(this IIdentity identity)
		{
			var userIdentity = getUserIdentity(identity);
			if (userIdentity == null) { return 0; }

			return userIdentity.UserId; 
		}


		/// <summary></summary>
		public static string GetUserName(this IIdentity identity)
		{
			var userIdentity = getUserIdentity(identity);
			if (userIdentity == null) { return null; }

			return userIdentity.UserName; 
		}



		/// <summary></summary>
		public static string GetAccount(this IIdentity identity)
		{
			var userIdentity = getUserIdentity(identity);
			if (userIdentity == null) { return null; }

			return userIdentity.Account;
		}


	}
}
