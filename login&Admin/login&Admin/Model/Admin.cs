using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login_Admin.Model
{
    public class Admin
    {
        [Key]
        public int ADID { get; set; }
        public string ADName { get; set; }
        public string AUsername { get; set; }
        public string APassword { get; set; }
    }

}
