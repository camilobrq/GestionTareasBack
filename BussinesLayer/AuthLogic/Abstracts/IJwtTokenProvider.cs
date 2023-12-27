using CommonsLayer.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.AuthLogic.Abstracts
{
    public interface IJwtTokenProvider
    {
        string GetJwtToken(UserData user);
    }
}
