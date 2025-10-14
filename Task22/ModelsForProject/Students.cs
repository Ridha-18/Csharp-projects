using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsForProject
{
     public class Students
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int CourseId { get; set; }   // Foreign Key

        [JsonIgnore]
        public Course? Course { get; set; } // Navigation Property
    }
}
