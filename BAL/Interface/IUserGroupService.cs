using Entity.Common;
using Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface
{
    public interface IUserGroupService
    {
        List<UserGroupVM> GetActiveUserGroup();

		ResponseData Save(UserGroupVM vm);

		ResponseData GetByID(int id);
		ResponseData Delete(int id);


	
	}
}
