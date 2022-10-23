using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineSchool.Models
{
    public class Like
    {
        [Key]
        public int LID { set; get; }
        [Required]
        public int Likes { set; get; }

        public List<Student_Tutorial_Like>
        Student_Tutorial_Like

        { set; get; }

        public List<Teacher_Tutorial_Like>
        Teacher_Tutorial_Like

        { set; get; }
        [Required]
        public int AuthID { set; get; }

        //[ForeignKey("Authorization")]
        //public int AuthID { set; get; }

        //public Authorization Authorization { set; get; }
    }
}
