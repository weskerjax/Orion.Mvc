using System;
using System.Linq;
using System.Security.Principal;


namespace Orion.Mvc.Security
{
	/// <summary></summary>
	public static class IPrincipalExtensions
    {
		/// <summary></summary>
		public static bool AnyAct(this IPrincipal user, params Enum[] actLits)
        {
            if (actLits.Length == 0) { return user.Identity.IsAuthenticated; }
            return actLits.Any(x => user.IsInRole(x.ToString()));
        }

		/// <summary></summary>
		public static bool AllAct(this IPrincipal user, params Enum[] actLits)
        {
            if (actLits.Length == 0) { return user.Identity.IsAuthenticated; }
            return actLits.All(x => user.IsInRole(x.ToString()));
        }

    }
}