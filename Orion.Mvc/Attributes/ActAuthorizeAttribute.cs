using System.Linq;
using System.Web.Mvc;

namespace Orion.Mvc.Attributes
{
	/// <summary>ACT 驗證使用者權限</summary>
	public class ActAuthorizeAttribute : AuthorizeAttribute
    {
		/// <summary>ACT 驗證使用者權限</summary>
		public ActAuthorizeAttribute() { }

		/// <summary>ACT 驗證使用者權限</summary>
		public ActAuthorizeAttribute(params object[] actLits)
        {
            if (actLits.Length == 0) { return; }
            Roles = string.Join(",", actLits.Select(x => x.ToString()));
        }
    }
}