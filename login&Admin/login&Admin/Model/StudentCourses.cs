using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login_Admin.Model
{
    public class StudentCourses
    {
        [Key, Column(Order = 0)]
        public int coid { get; set; }
        [Key, Column(Order = 1)]
        public int stid { get; set; }
        public decimal grade { get; set; }
        [ForeignKey("stid")]
        public virtual Student Students { get; set; }
        [ForeignKey("coid")]
        public virtual Courses courses { get; set; }
    }

}