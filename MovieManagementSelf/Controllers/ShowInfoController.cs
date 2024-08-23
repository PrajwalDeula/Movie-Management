using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
namespace MovieManagementSelf.Controllers
{
    public class ShowInfoController : Controller
    {
        ApplicationDbContext _context;

        public ShowInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        
    
        public IActionResult Index()
        {
            return View();
        }
    }
}
