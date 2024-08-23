using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DAO.Interface;
using Entity.Common;
using Entity.Model;
using Entity.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;


namespace DAO.Implementation
{
    public class UserGroupRepo : IUserGroupRepo
    {
        ApplicationDbContext _context;
        ResponseData _return;


        public UserGroupRepo(ApplicationDbContext context)
        {
            _context = context;
            _return = new ResponseData();
        }


        public List<UserGroup> GetActiveUserGroup()
        {
            return _context.UserGroup.Where(x => x.Status == 1).ToList();

        }




        public ResponseData SaveData(UserGroup model)
        {

            if (model.UserGroupID == 0)
            {
                _context.UserGroup.Add(model);
                _context.SaveChanges();
                _return.Success = true;
                _return.Message = "Data saved succesfully";

                return _return;
            }

            else
            {
                var data = _context.UserGroup.Where(x => x.UserGroupID == model.UserGroupID).FirstOrDefault();
                if (data == null)
                {
                    _return.Message = "Data not found";
                }
                else
                {
                    data.UserGroupName = model.UserGroupName;
                    data.UserGroupCode = model.UserGroupCode;

                    _context.SaveChanges();
                    _return.Success = true;
                    _return.Message = "Data Updated Succesfully";
                }


                return _return;

            }

        }



        public ResponseData Delete(int id)
        {
            var data = _context.UserGroup.Where(x => x.UserGroupID == id).FirstOrDefault();
            if (data == null)
            {

                _return.Message = "Usergroup data not found";
            }

            else
            {
                data.Status = 0;
                _context.SaveChanges();
                _return.Success = true;
                _return.Message = "Data deleted succesfully";
            }

            return _return;
        }



      
       public ResponseData GetByID(int id)
        {
            var data = _context.UserGroup.Where(x => x.UserGroupID == id).FirstOrDefault();
            if(data == null)
            {
                _return.Message = "Data not found";
            }
            else
            {
                UserGroupVM usergroupdata = new UserGroupVM()
                {
                    UserGroupName = data.UserGroupName,
                    UserGroupCode = data.UserGroupCode
                };

                _return.Success = true;
                _return.Data = usergroupdata;
            }

            return _return;
        }


	}

}
