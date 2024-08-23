using System;
using System.Collections.Generic;
using System.Linq;
using BAL;
using Entity.ViewModel;
using System.Text;
using System.Threading.Tasks;
using Entity.Common;

namespace BAL.Interface
{
	public interface IGenreInfoService
	{
		List<GenreInfoVM> GetActiveGenre();
		ResponseData Save(GenreInfoVM vm);
	}
}
