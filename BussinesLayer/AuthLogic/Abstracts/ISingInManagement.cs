using BusinessLayer.ResponseModels;
using CommonsLayer.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.AuthLogic.Abstracts
{
    public interface ISingInManagement
    {
        Task<Response<SessionData>> SingIn(UserCredentials user);
        Task<Response> RegisterUser(UserRegister userRegister);
    }
}
