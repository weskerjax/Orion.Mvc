using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace Orion.Mvc
{
	/// <summary>透過 IControllerFactory 去處理每一個 Controller 的預設 SessionState</summary>
	public class SessionStateControllerFactory : IControllerFactory
	{
		private IControllerFactory _inner;

		/// <summary>預設的 SessionState</summary>
		public SessionStateBehavior DefalutBehavior { get; set; }

		/// <summary></summary>
		public SessionStateControllerFactory(IControllerFactory inner)
		{
			_inner = inner;
		}

		/// <summary></summary>
		public IController CreateController(RequestContext requestContext, string controllerName)
		{
			return _inner.CreateController(requestContext, controllerName);
		}

		/// <summary></summary>
		public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
		{
			SessionStateBehavior state = _inner.GetControllerSessionBehavior(requestContext, controllerName);
			if (state != SessionStateBehavior.Default) { return state; }
			return DefalutBehavior;
		}

		/// <summary></summary>
		public void ReleaseController(IController controller)
		{
			_inner.ReleaseController(controller);
		}
	}
}
