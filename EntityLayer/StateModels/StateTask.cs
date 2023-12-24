using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.StateModels
{
    [Table("StateTask", Schema = "states_data")]
    public class StateTask
    {
        [Key]
        public Guid idStateTask { get; set; }
        [MaxLength(255)]
        public string stateName { get; set; }
        [MaxLength(255)]
        public string stateDescription { get; set; }
        public bool state { get; set; }

    }
}
