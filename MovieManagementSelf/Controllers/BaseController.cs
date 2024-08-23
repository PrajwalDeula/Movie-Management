using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MovieManagementSelf.Controllers
{
	public class BaseController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}

	protected async Task<string> renderViewPartial (string viewName, ICompositeViewEngine _viewEngine, object model = null)
	{
		if (string.IsNullOrEmpty(viewName){
			viewName = ControllerContext.ActionView.ActionName
		})
	}
