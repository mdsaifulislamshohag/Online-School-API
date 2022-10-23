using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel
{
  public  class TeacherUpdateCv
    {
        [Required]
        public IFormFile Cv { set; get; }
    }
}
