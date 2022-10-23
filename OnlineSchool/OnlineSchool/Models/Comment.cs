using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineSchool.Models
{
    public class Comment
    {
        [Key]
        public int ComID { set; get; }
        [Required]
        public String Comments { set; get; }

        public List<Student_Tutorial_Comment>
        Student_Tutorial_Comments
       
        { set; get; }

        public List<Teacher_Tutorial_Comment>
        Teacher_Tutorial_Comments

        { set; get; }
        [Required]
        public int AuthID { set; get; }

        //[ForeignKey("Authorization")]
        //public int AuthID { set; get; }

        //public Authorization Authorization { set; get; }
    }
}
