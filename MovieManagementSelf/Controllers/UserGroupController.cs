using Microsoft.AspNetCore.Mvc;
using BAL.Interface;
using Entity.ViewModel;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MovieManagementSelf.Controllers
{
    public class UserGroupController : Controller
    {
        IUserGroupService _iug;

        public UserGroupController(IUserGroupService iug)
        {
            _iug = iug;
        }

        public IActionResult Index()
        {
            var data = _iug.GetActiveUserGroup();
            return View(data);


        }

        [HttpGet]

        public JsonResult GetAllData()
        {
            return Json(new
            {
                Success = true,
                Data = _iug.GetActiveUserGroup()
            });

        }

        [HttpGet]

        public JsonResult Delete(int id)
        {
            var res = _iug.Delete(id);
            return Json(res);
        }

        [HttpGet]

        public JsonResult GetByID(int id)
        {
            var res = _iug.GetByID(id);
            return Json(res);
        }
        [HttpPost]

        public JsonResult Save([FromBody] UserGroupVM vm)
        {
            var res = _iug.Save(vm);
            return Json(res);
        }


        



        }




    }


