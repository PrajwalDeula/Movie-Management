using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using BAL.Interface;
using BAL.Implementation;
using DAO.Implementation;
using DAO.Interface;
using Entity.Common;
using Entity.Model;
using Entity.ViewModel;
using Microsoft.EntityFrameworkCore.Diagnostics;



namespace BAL.Implementation
{

    public class GenreInfoService:IGenreInfoService {
        IGenreInfoRepo _repo;
        ResponseData _result;

        public GenreInfoService(IGenreInfoRepo repo)
        {
            _repo = repo;
            _result = new ResponseData();
        }
        public List<GenreInfoVM> GetActiveGenre()
        {
            return _repo.GetActiveGenre().Select(s => new GenreInfoVM
            {
                GenreInfoID = s.GenreInfoID,
                GenreName = s.GenreName,
                GenreCode = s.GenreCode
            })
             .ToList();  
            }

        public ResponseData Save(GenreInfoVM vm)
        {
            if (string.IsNullOrEmpty(vm.GenreName))
            {
                _result.Success = false;
                _result.Message = "Enter Genre Name";

            }
            else if (string.IsNullOrEmpty(vm.GenreCode)){
                _result.Success = false;
                _result.Message = "Enter Genre Code";
            }
            else
            {
                GenreInfo mdl = new GenreInfo()
                {
                    GenreName = vm.GenreName,
                    GenreCode = vm.GenreCode,
                    Status = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = vm.CreatedBy,
                    ModifiedBy = vm.ModifiedBy,
                    ModifiedDate = vm.ModifiedDate
                };

                _result = _repo.SaveData(mdl);

            }
            return _result;
        }

       
    }
      
}
