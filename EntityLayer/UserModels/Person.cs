using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.UserModels
{
    [Table("Person", Schema = "basic_data")]
    public class Person
    {
        [Key]
        public Guid idPerson { get; set; }
        [Required]
        [MaxLength(55)]
        public string firstName { get; set; }
        [MaxLength(55)]
        public string lastName { get; set; }
        [MaxLength(55)]
        public string email { get; set; }
        [MaxLength(13)]
        public string cellPhone { get; set; }
        [MaxLength(255)]
        public string address { get; set; }

    }
}
