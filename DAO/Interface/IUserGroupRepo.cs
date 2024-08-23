using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity.Model;
using DAO;
using DAO.Implementation;
using Entity.Common;
using DAO.Interface;


using System.Threading.Tasks;


namespace DAO.Interface
{
    public interface IUserGroupRepo
    {
        List<UserGroup> GetActiveUserGroup();
        ResponseData GetByID(int id);
        ResponseData Delete(int id);
		ResponseData SaveData(UserGroup model);
       
    
    }
}
