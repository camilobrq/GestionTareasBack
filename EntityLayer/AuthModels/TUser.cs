using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.AuthModels
{
    [Table("User", Schema = "Auth")]
    public class TUser
    {
        [Key]
        public Guid idUser { get; set; }
        [MaxLength(75)]
        public string role { get; set; }
        [MaxLength(75)]
        public string email { get; set; }
        [MaxLength(255)]
        public string password { get; set; }
        [MaxLength(155)]
        public string name { get; set; }
        [MaxLength(155)]
        public string lastName { get; set; }
        [MaxLength(20)]
        public string identification { get; set; }
        [MaxLength(13)]
        public string telephone { get; set; }
        [MaxLength(155)]
        public string address { get; set; }
    }

   
}
