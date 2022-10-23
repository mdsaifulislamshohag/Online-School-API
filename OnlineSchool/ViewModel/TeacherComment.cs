using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel
{
  public class TeacherComment
    {
        [Required]
        public String Comment { set; get; }
    }
}
