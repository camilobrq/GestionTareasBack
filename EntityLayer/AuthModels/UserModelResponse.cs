using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.AuthModels
{
    public class UserModelResponse
    {
        public Guid idUser { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
    }
}
