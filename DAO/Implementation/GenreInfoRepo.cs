using Entity.Common;
using Entity.Model;
using DAO.Interface;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Implementation
{

	public class GenreInfoRepo:IGenreInfoRepo	{
		ApplicationDbContext _context;
		ResponseData _return;

		public GenreInfoRepo(ApplicationDbContext context)
		{
			_context = context;
			_return = new ResponseData();
		}

		public List<GenreInfo> GetActiveGenre()
		{
			return _context.GenreInfo.Where(x => x.Status == 1)
				.ToList();
		}

		public ResponseData SaveData(GenreInfo model)
		{
			_context.GenreInfo.Add(model);
			_context.SaveChanges();

			_return.Success = true;
			_return.Message = "Data Added Succesfully";

			return _return; 
			
		}
	}
}

	
