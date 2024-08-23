using System;
using Entity.Model;
using DAO;
using Entity.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Common;

namespace DAO.Interface
{
	public interface IGenreInfoRepo
	{
		List<GenreInfo> GetActiveGenre();
		ResponseData SaveData(GenreInfo model);

	}
}
