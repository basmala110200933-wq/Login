using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login_Admin.Model
{
    public class Courses
    {
        [Key]
        public int COID{ get; set; }
        public string COName { get; set; }
        public List<StudentCourses> StudentCourses { get; set; } = new List<StudentCourses>();
    }
}
