using BAL.Interface;
using DAO.Implementation;
using DAO.Interface;
using Entity.Common;
using Entity.Model;
using Entity.ViewModel;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Implementation
{


    public class UserGroupService : IUserGroupService
    {
        IUserGroupRepo _repo;
        ResponseData _result;

        public UserGroupService(IUserGroupRepo repo)
        {
            _repo = repo;
            _result = new ResponseData();


        }

		public ResponseData Delete(int id)
		{
            return _repo.Delete(id);
		}

        public ResponseData GetByID(int id)
        {
            return _repo.GetByID(id);
        }

		public List<UserGroupVM> GetActiveUserGroup()
        {
            return _repo.GetActiveUserGroup().Select(s => new UserGroupVM
            {
                UserGroupID = s.UserGroupID,
                UserGroupName = s.UserGroupName,
                UserGroupCode = s.UserGroupCode
            })
               .ToList();
        }



		public ResponseData Save(UserGroupVM vm)
        {


            if (string.IsNullOrEmpty(vm.UserGroupName))
            {

                //_result.Success = false;
                _result.Message = "Enter the UserGroup Name";

            }

            else if (string.IsNullOrEmpty(vm.UserGroupCode))
            {

                //_result.Success = false;
                _result.Message = "Enter the UserGroup Code";
            }
            else
            {
                UserGroup mdl = new UserGroup()
                {
                    UserGroupID = vm.UserGroupID,
                    UserGroupCode = vm.UserGroupCode,
                    UserGroupName = vm.UserGroupName,
                    CreatedBy = 1,
                    Status = 1,
                    CreatedDate = DateTime.Now,
                };

                _result = _repo.SaveData(mdl);

            }


            return _result;
        }

      
    }
     
}



