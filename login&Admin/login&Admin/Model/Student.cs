using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login_Admin.Model
{
    public class Student
    {
        [Key]
        public int STID { get; set; } 
        public string STName { get; set; }
        public string SUsername { get; set; }
        public string SPassword { get; set; }
        public List<StudentCourses> StudentCourses { get; set; } = new List<StudentCourses>();

    }
}
