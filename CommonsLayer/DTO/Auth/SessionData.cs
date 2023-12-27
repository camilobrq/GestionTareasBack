using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonsLayer.DTO.Auth
{
    public class SessionData
    {
        public string Token { get; set; } = string.Empty;
        public UserData UserInfo { get; set; } = new UserData();

        public SessionData() { }

        public SessionData(string token, UserData userInfo)
        {
            Token = token;
            UserInfo = userInfo;
        }
    }
}
