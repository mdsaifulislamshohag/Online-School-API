using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineSchool.Models
{
    public class Teacher_Tutorial_Comment
    {
        [Key]
        public int TTC { set; get; }

        [ForeignKey("Teacher")]
        public int TeID { set; get; }

        public Teacher Teacher { set; get; }

        [ForeignKey("Tutorial")]
        public int TID { set; get; }
        public Tutorial Tutorial { set; get; }
        [ForeignKey("Comment")]
        public int ComID { set; get; }
        public Comment Comment { set; get; }
        [Required]
        public int AuthID { set; get; }

        //[ForeignKey("Authorization")]
        //public int AuthID { set; get; }

        //public Authorization Authorization { set; get; }
    }
}
