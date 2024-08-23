using Microsoft.AspNetCore.Mvc;
using DAO;
using System.Text.Json;
using Entity.ViewModel;
using Entity.Model;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MovieManagementSelf.Controllers
{
	public class GenreInfoController : Controller
	{
		ApplicationDbContext _context;

		public GenreInfoController(ApplicationDbContext context)
		{
			_context = context;
		}

	
		public IActionResult Index()
		{
			return View();
		}
	}
}
