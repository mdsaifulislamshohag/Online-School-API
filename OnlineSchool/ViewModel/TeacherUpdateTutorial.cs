using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel
{
  public class TeacherUpdateTutorial
    {
        [Required]
        [MaxLength(500)]
        public String Title { set; get; }
        [Required]
        public String Description { set; get; }
    }
}
