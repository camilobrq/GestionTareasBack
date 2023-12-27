using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.TaskModels
{
    [Table("TaskManager", Schema = "basic_data")]
    public class TaskManager
    {
        [Key]
        public Guid idTask { get; set; }

        [Required]
        [MaxLength(255)]
        public string taskTitle { get; set; }
        [MaxLength(255)]
        public string description { get; set; }
        public Guid idStateTask { get; set; }
        public string state { get; set; }
        public string priority { get; set; } //tendra 3 niveles de prioridad donde 1 es la mas alta y 3 la mas baja

        public Guid idUser { get; set; }

    }
}
