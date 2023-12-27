using BusinessLayer.ResponseModels;
using EntityLayer.AuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.AuthLogic.Abstracts
{
    public interface IEmployeeManagement
    {
        Task<Response<List<UserModelResponse>>> GetAllUser();
    }
}
