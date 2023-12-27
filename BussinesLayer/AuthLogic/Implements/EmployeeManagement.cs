using BusinessLayer.ResponseModels;
using BussinesLayer.AuthLogic.Abstracts;
using DataLayer.Repositories.Abstracts;
using EntityLayer.AuthModels;
using EntityLayer.TaskModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.AuthLogic.Implements
{
    public class EmployeeManagement:IEmployeeManagement
    {
        private readonly IEmployeeRepository repository;


        public EmployeeManagement(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Response<List<UserModelResponse>>> GetAllUser()
        {
            try
            {

                var result = await repository.GetAllUser();

                return Response<List<UserModelResponse>>.Successful("Successful", result);

            }
            catch (Exception)
            {
                return Response<List<UserModelResponse>>.Error("Ha ocurrido un error, no se ha podido registrar el evento.", null);
            }
        }
    }
}
