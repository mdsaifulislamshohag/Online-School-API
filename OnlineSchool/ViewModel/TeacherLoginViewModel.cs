using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel
{
   public class TeacherLoginViewModel
    {
        [MaxLength(100)]
        public String Email { set; get; }
        [MaxLength(100)]
        public String Password { set; get; }
    }
}
