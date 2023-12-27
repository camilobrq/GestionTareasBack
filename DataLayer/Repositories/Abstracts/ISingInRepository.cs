using EntityLayer.AuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Abstracts
{
    public interface ISingInRepository
    {
        Task<List<TUser>> GetUser(string username, string password);
        Task<List<TUser>> ValidateUsername(string username);
        Task RegisterUser(TUser userModel);
    }
}
