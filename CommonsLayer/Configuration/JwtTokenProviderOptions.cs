using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonsLayer.Configuration
{
    public class JwtTokenProviderOptions
    {
        public string SecretKey { get; set; } = string.Empty;
        public TimeSpan ExpirationTime { get; set; }
    }
}
