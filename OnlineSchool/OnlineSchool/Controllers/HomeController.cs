using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineSchool.Models;

namespace OnlineSchool.Controllers
{
   
  ///  [ApiController]
    public class HomeController : Controller
    {

        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }
        /// <summary>
        /// (Gets All The Courses Added by the Adminstration)
        /// </summary>
        /// <returns></returns>
        [HeaderAuthorization]
        [Route("Home/Courses")]
        [HttpGet]
        public async Task<ActionResult> Courses()
        {
            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));

            var course = await _context.Course
                .Where(x => x.AuthID == Auth_ID)
                .Select(y => new { y.CID, y.Title, y.Description })
                .ToListAsync();

            if (course.Count == 0)
            {
                return Json(new { success = false, error = "NO DATA" });
            }

            List<Course> courses = new List<Course>();

            for (int i = 0; i < course.Count; i++)
            {

                var data = new Course()
                {
                    CID = course[i].CID,
                    Course_Title = course[i].Title,
                    Course_Description = course[i].Description,
                };
                courses.Add(data);
            }


            return Json(new { success = true, data = courses });
        }

        /// <summary>
        /// (Gets All The Tutorials Under a Specific Course ID)
        /// </summary>
        /// <param name="CID">1</param>
        /// <returns>Tutorial</returns>
      
        [HeaderAuthorization]
        [Route("Home/Tutorials/{CID}")]
        [HttpGet]
        public async Task<ActionResult> Tutorials(int CID)
        {

            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));

            var ID = await _context.Teacher_Course_Tutorial
                .Where(x => (x.CID == CID && x.AuthID == Auth_ID))
                .Select(y => new { y.TID, y.TeID })
                .ToListAsync();

            if (ID.Count == 0)
            {
                return Json(new { success = false, error = "NO DATA" });
            }

            List<TutorialAndDetails> list = new List<TutorialAndDetails>();

            for (int i = 0; i < ID.Count; i++)
            {
                var Tutorials = await _context.Tutorial
                    .Where(x => x.TID == ID[i].TID)
                    .Select(y => new { y.Title, y.Description })
                    .FirstOrDefaultAsync();

                var Teacher = await _context.Teacher
                    .Where(x => x.TeID == ID[i].TeID)
                    .Select(y => new { y.Name }).FirstOrDefaultAsync();

                var data = new TutorialAndDetails()
                {

                    TeID = ID[i].TeID,
                    TID = ID[i].TID,
                    Tutorial_Title = Tutorials.Title,
                    Tutorial_Description = Tutorials.Description,
                    Teacher_Name = Teacher.Name,
                };

                list.Add(data);


            }

            return Json(new { success = true, data = list });
        }
        [HeaderAuthorization]
        [Route("Home/WatchTutorial/{TID}/{TeID}")]
        [HttpGet]
        public async Task<ActionResult> Watch_Tutorial(int TID, int TeID)
        {
            String NULL;

            String StudentID = (HttpContext.Session.GetString("SID"));

            String TeacherID = (HttpContext.Session.GetString("TeID"));

            Boolean student = false;
            Boolean teacher = false;

            if (StudentID != null)
            {
                student = true;
            }
            if (TeacherID != null)
            {
                teacher = true;
            }

            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));

            var Tutorial = await _context.Tutorial
                .Where(x => (x.TID == TID && x.AuthID == Auth_ID))
                .Select(y => new { y.Title, y.Description, y.Video_Path })
                .FirstOrDefaultAsync();

            if (Tutorial == null)
            {
                return BadRequest();
            }



            var Teacher = await _context.Teacher
               .Where(x => (x.TeID == TeID && x.AuthID == Auth_ID))
               .Select(y => new { y.Name, y.Email, y.Phone })
               .FirstOrDefaultAsync();

            if (Teacher == null)
            {
                return BadRequest();
            }

            List<TutorialPage.Student_Comment> sc = new List<TutorialPage.Student_Comment>();

            var ScomId = await _context.Student_Tutorial_Comment
                .Where(x => (x.TID == TID && x.AuthID == Auth_ID))
                .Select(y => new { y.ComID, y.SID }).ToListAsync();

            for (int i = 0; i < ScomId.Count; i++)
            {
                int comID = ScomId[i].ComID;

                var comment = await _context.Comment
                    .Where(x => x.ComID == comID && x.AuthID == Auth_ID)
                    .FirstOrDefaultAsync();

                int sid = ScomId[i].SID;

                var StudentName = await _context.Student
                    .Where(x => x.SID == sid && x.AuthID == Auth_ID)
                    .Select(y => new { y.SID, y.Name })
                    .FirstOrDefaultAsync();

                var data = new TutorialPage.Student_Comment
                {
                    SID = StudentName.SID,
                    StudentName = StudentName.Name,
                    ComID = comID,
                    Comments = comment.Comments
                };

                sc.Add(data);

            }

            List<TutorialPage.Teacher_Comment> tc = new List<TutorialPage.Teacher_Comment>();

            var TcomId = await _context.Teacher_Tutorial_Comment
                .Where(x => (x.TID == TID && x.AuthID == Auth_ID))
                .Select(y => new { y.ComID, y.TeID }).ToListAsync();

            for (int i = 0; i < TcomId.Count; i++)
            {
                int comID = TcomId[i].ComID;

                var comment = await _context.Comment
                    .Where(x => x.ComID == comID && x.AuthID == Auth_ID)
                    .FirstOrDefaultAsync();

                int teid = TcomId[i].TeID;

                var teacherName = await _context.Teacher
                    .Where(x => x.TeID == teid && x.AuthID == Auth_ID)
                    .Select(y => new { y.TeID, y.Name })
                    .FirstOrDefaultAsync();

                var data = new TutorialPage.Teacher_Comment
                {
                    TeID = teacherName.TeID,
                    TeacherName = teacherName.Name,
                    ComID = comID,
                    Comments = comment.Comments
                };

                tc.Add(data);

            }


            var SLID = await _context.Student_Tutorial_Like
               .Where(x => (x.TID == TID && x.AuthID == Auth_ID))
               .Select(y => new { y.LID, y.SID }).ToListAsync();

            Dictionary<int, String> Sdict = new Dictionary<int, String>();

            List<TutorialPage.Student_Like> reactByStudent = new List<TutorialPage.Student_Like>();

            Boolean svr = false;

            int ThisPersonReaction = 0;


            for (int i = 0; i < SLID.Count; i++)
            {
                int slID = SLID[i].LID;

                var reaction = await _context.Like
                    .Where(x => x.LID == slID && x.AuthID == Auth_ID)
                    .FirstOrDefaultAsync();

                int sid = SLID[i].SID;

                if (student == true && !svr)
                {
                    if (Convert.ToInt32(StudentID) == sid)
                    {
                        svr = true;
                        ThisPersonReaction = reaction.Likes;
                    }
                }

                if (!Sdict.TryGetValue(reaction.Likes , out NULL))
                {

                    int x = 1;
                    Sdict.Add(reaction.Likes, x.ToString());
                }
                else
                {
                    int x = Convert.ToInt32(Sdict[reaction.Likes]);
                    x++;
                    Sdict.Remove(reaction.Likes);
                    Sdict.Add(reaction.Likes, x.ToString());
                }
            }

            foreach (var item in Sdict)
            {
                var eachReact = new TutorialPage.Student_Like
                {
                    reactionName = item.Key,
                    totalReaction = Convert.ToInt32(item.Value)
                };
                reactByStudent.Add(eachReact);

                ///  Console.WriteLine(item.Key + " = " + item.Value);
            }


            var TLID = await _context.Teacher_Tutorial_Like
              .Where(x => (x.TID == TID && x.AuthID == Auth_ID))
              .Select(y => new { y.LID, y.TeID }).ToListAsync();

            Dictionary<int, String> Tdict = new Dictionary<int, String>();

            List<TutorialPage.Teacher_Like> reactByTeacher = new List<TutorialPage.Teacher_Like>();

            for (int i = 0; i < TLID.Count; i++)
            {
                int tlID = TLID[i].LID;

                var reaction = await _context.Like
                    .Where(x => x.LID == tlID && x.AuthID == Auth_ID)
                    .FirstOrDefaultAsync();

                int teid = TLID[i].TeID;

                if (teacher == true && !svr)
                {
                    if (Convert.ToInt32(TeacherID) == teid)
                    {
                        svr = true;
                        ThisPersonReaction = reaction.Likes;
                    }
                }

              

                if (!Tdict.TryGetValue(reaction.Likes, out NULL))
                {

                    int x = 1;
                    Tdict.Add(reaction.Likes, x.ToString());
                }
                else
                {
                    int x = Convert.ToInt32(Tdict[reaction.Likes]);
                    x++;
                    Tdict.Remove(reaction.Likes);
                    Tdict.Add(reaction.Likes, x.ToString());
                }
            }

            foreach (var item in Tdict)
            {
                var eachReact = new TutorialPage.Teacher_Like
                {
                    reactionName = item.Key,
                    totalReaction = Convert.ToInt32(item.Value)
                };
                reactByTeacher.Add(eachReact);

                ///  Console.WriteLine(item.Key + " = " + item.Value);
            }


            var value = new TutorialPage()
            {
                MyReactionToThisVideo = ThisPersonReaction,
                Tutorial_Title = Tutorial.Title,
                Tutorial_Description = Tutorial.Description,
                Tutorial_VideoPath = Tutorial.Video_Path,
                Teacher_Name = Teacher.Name,
                Teacher_Email = Teacher.Email,
                Teacher_Phone = Teacher.Phone,
                StudentComment = sc,
                TeacherComment = tc,
                StudentLike = reactByStudent,
                TeacherLike = reactByTeacher

            };


            return Json(new { success = true, data = value });
        }

     /*   [HttpPost]
        public ActionResult Best_Search()
        {
            //// ML.NET()
            return View();
        }
        */

    }
   
    struct Course
    {
        public int CID { set; get; }
        public String Course_Title { set; get; }

        public String Course_Description { set; get; }

    }

    struct TutorialAndDetails
    {
        public int TeID { set; get; }
        public int TID { set; get; }
        public String Tutorial_Title { set; get; }

        public String Tutorial_Description { set; get; }

        public String Teacher_Name { set; get; }
    }

    struct TutorialPage
    {
        public int MyReactionToThisVideo { set; get; }
        public String Tutorial_Title { set; get; }

        public String Tutorial_Description { set; get; }

        public String Tutorial_VideoPath { set; get; }

        public String Teacher_Name { set; get; }

        public String Teacher_Email { set; get; }

        public String Teacher_Phone { set; get; }

        public List<Student_Comment> StudentComment { set; get; }
        public List<Student_Like> StudentLike { set; get; }

        public List<Teacher_Comment> TeacherComment { set; get; }
        public List<Teacher_Like> TeacherLike { set; get; }


        public struct Student_Comment
        {
            public int SID { set; get; }
            public String StudentName { set; get; }
            public int ComID { set; get; }
            public String Comments { set; get; }
        }

        public struct Teacher_Comment
        {
            public int TeID { set; get; }
            public String TeacherName { set; get; }
            public int ComID { set; get; }
            public String Comments { set; get; }
        }

        public struct Student_Like
        {
            public int reactionName { set; get; }

            public int totalReaction { set; get; }
        }

        public struct Teacher_Like
        {
            public int reactionName { set; get; }

            public int totalReaction { set; get; }
        }




    }



}