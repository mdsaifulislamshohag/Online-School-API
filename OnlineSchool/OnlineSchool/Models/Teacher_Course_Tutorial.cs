using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineSchool.Models
{
    public class Teacher_Course_Tutorial
    {
        [Key]
        public int TeCT { set; get; }

        [ForeignKey("Teacher")]
        public int TeID { set; get; }

        public Teacher Teacher { set; get; }

        [ForeignKey("Course")]
        public int CID { set; get; }

        public Course Course { set; get; }

        [ForeignKey("Tutorial")]
        public int TID { set; get; }

        public Tutorial Tutorial { set; get; }
        [Required]
        public int AuthID { set; get; }

        //[ForeignKey("Authorization")]
        //public int AuthID { set; get; }

        //public Authorization Authorization { set; get; }


    }
}
