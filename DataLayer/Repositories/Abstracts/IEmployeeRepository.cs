using EntityLayer.AuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Abstracts
{
    public interface IEmployeeRepository
    {
        Task<List<UserModelResponse>> GetAllUser();
    }
}
