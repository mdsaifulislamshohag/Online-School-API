using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineSchool.Models
{
    public class Student_Tutorial_Like
    {
        [Key]
        public int STL { set; get; }

        [ForeignKey("Student")]

        public int SID { set; get; }

        public Student Student { set; get; }

        [ForeignKey("Tutorial")]
        public int TID { set; get; }
        public Tutorial Tutorial { set; get; }

        [ForeignKey("Like")]
        public int LID { set; get; }

        public Like Like{ set; get; }
        [Required]
        public int AuthID { set; get; }

        //[ForeignKey("Authorization")]
        //public int AuthID { set; get; }

        //public Authorization Authorization { set; get; }



    }
}
