using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonsLayer.DTO.TaskManagement
{
    public class TaskCreateDto
    {

        public Guid idTask { get; set; }
        public string taskTitle { get; set; }
        public string description { get; set; }
        public Guid idState { get; set; }
        public string state { get; set; }
        public int priority { get; set; } 
        public Guid idUser { get; set; }
    }
}
