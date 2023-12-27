using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonsLayer.DTO.Auth
{
    public class UserData
    {
        public string UserId { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string? Role { get; set; } = string.Empty;
        public UserState State { get; set; }
    }
}
