using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.UserModels
{
    [Table("User", Schema = "basic_data")]
    public class User : Person
    {
        public Guid idUser { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string rol { get; set; }

    }
}
