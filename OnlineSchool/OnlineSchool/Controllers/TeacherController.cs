using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineSchool.Models;
using ViewModel;

namespace OnlineSchool.Controllers
{
   
  ////  [ApiController]
    [Authorize(Roles = "Teacher", AuthenticationSchemes = "Teacher")]
    public class TeacherController : Controller
    {

        private readonly DatabaseContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public TeacherController(DatabaseContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        [HeaderAuthorization]
        [Route("Teacher/Registration")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Registration(TeacherRegistrationViewModel teacher)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, error = "Input Formate not Staisfy" });
            }
            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));

            var verify_Email = await _context.Teacher
               .Where(x => (x.Email == teacher.Email && x.AuthID == Auth_ID))
               .FirstOrDefaultAsync();

            if (verify_Email != null)
            {
                return Json(new { success = false, error = "This Email is Already in USE" });
            }


            String UploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "TeacherProfilePicture");
            String UniqueFileName = Guid.NewGuid().ToString() + "_" + teacher.Photo.FileName;
            String FilePath = Path.Combine(UploadFolder, UniqueFileName);
            teacher.Photo.CopyTo(new FileStream(FilePath, FileMode.Create));

            String UploadFolderCV = Path.Combine(_hostingEnvironment.WebRootPath, "TeacherCV");
            String UniqueFileNameCV = Guid.NewGuid().ToString() + "_" + teacher.CV.FileName;
            String FilePathCV = Path.Combine(UploadFolderCV, UniqueFileNameCV);
            teacher.CV.CopyTo(new FileStream(FilePathCV, FileMode.Create));

            var Teacher = new Teacher
            {
                Name = teacher.Name,
                Email = teacher.Email,
                Phone = teacher.Phone,
                Address = teacher.Address,
                Password = teacher.Password,
                CV_Path = UniqueFileNameCV,
                AuthID = Auth_ID,
                Profile_Image_Path = UniqueFileName,
            };

            _context.Teacher.Add(Teacher);
            await _context.SaveChangesAsync();

            return Json(new { success = true, data = "Registration Complete" });
        }

        [HeaderAuthorization]
        [Route("Teacher/Login")]
        [AllowAnonymous]
        [HttpPost]

        public async Task<ActionResult> Login(TeacherLoginViewModel teacher)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, error = "Login Failed" });
            }

            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));

            var data = await _context.Teacher
               .Where(x => (x.Email == teacher.Email && x.Password == teacher.Password && x.AuthID == Auth_ID))
               .FirstOrDefaultAsync();
            if (data == null)
            {
                return Json(new { success = false, error = "Login Failed" });
            }
            else
            {
                await HttpContext.SignOutAsync("Student");
                await HttpContext.SignOutAsync("Provider");
                await HttpContext.SignOutAsync("Admin");
                await HttpContext.SignOutAsync("Teacher");

                ClaimsIdentity identity = null;
                identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Email,teacher.Email),
                        new Claim(ClaimTypes.Role,"Teacher")

                     }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("Teacher", principal);

                HttpContext.Session.SetString("TeID", data.TeID.ToString());


                return Json(new { success = true, ReturnURL = "/Teacher/Profile" });

            }
        }

        [HeaderAuthorization]
        [Route("Teacher/Profile")]
        [HttpGet]

        public async Task<ActionResult> Profile()
        {
            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));
            int TeID = Convert.ToInt32(HttpContext.Session.GetString("TeID"));

            var value = await _context.Teacher
              .Where(x => (x.TeID == TeID && x.AuthID == Auth_ID))
              .Select(y => new { y.TeID, y.Name, y.Email, y.Phone, y.Address, y.Profile_Image_Path, y.CV_Path })
              .FirstOrDefaultAsync();

            if (value == null)
            {
                return Unauthorized();
            }
            else
            {
                return Json(new { success = true, data = value });
            }
        }

        [HeaderAuthorization]
        [Route("Teacher/MyTutorials")]
        [HttpGet]

        public async Task<ActionResult> MyTutorials()
        {
            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));
            int TeID = Convert.ToInt32(HttpContext.Session.GetString("TeID"));

            var value = await _context.Teacher
              .Where(x => (x.TeID == TeID && x.AuthID == Auth_ID))
              .FirstOrDefaultAsync();

            if (value == null)
            {
                return Unauthorized();
            }

            var Tutorial_Course = await _context.Teacher_Course_Tutorial
                .Where(x => x.TeID == TeID && x.AuthID == Auth_ID)
                .Select(y => new { y.TID, y.CID })
                .ToListAsync();

            List<MyTutorial> Mytutorial = new List<MyTutorial>();

            for (int i = 0; i < Tutorial_Course.Count; i++)
            {
                int tid = Tutorial_Course[i].TID;
                int cid = Tutorial_Course[i].CID;

                var tutorial = await _context.Tutorial
                    .Where(x => (x.TID == tid && x.AuthID == Auth_ID))
                    .Select(y => new { y.Title, y.Description, y.Video_Path })
                    .FirstOrDefaultAsync();

                var data = new MyTutorial
                {
                    Title = tutorial.Title,
                    Description = tutorial.Description,
                    Video_Path = tutorial.Video_Path,
                    TID = tid,
                    CID = cid,
                    TeID = TeID
                };

                Mytutorial.Add(data);
            }

            return Json(new { success = true, data = Mytutorial });

        }


        [HeaderAuthorization]
        [Route("Teacher/MyHidenVideo")]
        [HttpGet]

        public async Task<ActionResult> MyHidenVideo()
        {
            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));
            int TeID = Convert.ToInt32(HttpContext.Session.GetString("TeID"));

            int authID = Auth_ID * (-1);

            var value = await _context.Teacher
              .Where(x => (x.TeID == TeID && x.AuthID == Auth_ID))
              .FirstOrDefaultAsync();

            if (value == null)
            {
                return Unauthorized();
            }

            var Tutorial_Course = await _context.Teacher_Course_Tutorial
                .Where(x => x.TeID == TeID && x.AuthID == authID)
                .Select(y => new { y.TID, y.CID })
                .ToListAsync();

            List<MyTutorial> Mytutorial = new List<MyTutorial>();

            for (int i = 0; i < Tutorial_Course.Count; i++)
            {
                int tid = Tutorial_Course[i].TID;
                int cid = Tutorial_Course[i].CID;

                var tutorial = await _context.Tutorial
                    .Where(x => (x.TID == tid && x.AuthID == authID))
                    .Select(y => new { y.Title, y.Description, y.Video_Path })
                    .FirstOrDefaultAsync();

                var data = new MyTutorial
                {
                    Title = tutorial.Title,
                    Description = tutorial.Description,
                    Video_Path = tutorial.Video_Path,
                    TID = tid,
                    CID = cid,
                    TeID = TeID
                };

                Mytutorial.Add(data);
            }

            return Json(new { success = true, data = Mytutorial });

        }




        [HeaderAuthorization]
        [Route("Teacher/ProfileUpdate")]
        [HttpPost]

        public async Task<ActionResult> ProfileUpdate(TeacherUpdateViewModel teacher)
        {
            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));
            int TeID = Convert.ToInt32(HttpContext.Session.GetString("TeID"));

            if (!ModelState.IsValid)
            {
                return Json(new { success = false, error = "Input Formate Wrong" });
            }

            var value = await _context.Teacher
               .Where(x => (x.TeID == TeID && x.AuthID == Auth_ID))
               .FirstOrDefaultAsync();

            if (value == null)
            {
                return Unauthorized();
            }

            var verify_Email = await _context.Teacher
             .Where(x => (x.Email == teacher.Email && x.TeID != TeID))
             .FirstOrDefaultAsync();

            if (verify_Email != null)
            {
                return Json(new { success = false, error = "This Email is Already in USE" });
            }

            value.Name = teacher.Name;
            value.Email = teacher.Email;
            value.Phone = teacher.Phone;
            value.Address = teacher.Address;
            value.Password = teacher.Password;

            await _context.SaveChangesAsync();

            return Json(new { success = true, data = value });

        }

        [HeaderAuthorization]
        [Route("Teacher/ProfileImageUpdate")]
        [HttpPost]

        public async Task<ActionResult> ProfileImageUpdate(TeacherUpdateImage teacher)
        {
            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));
            int TeID = Convert.ToInt32(HttpContext.Session.GetString("TeID"));

            var value = await _context.Teacher
               .Where(x => (x.TeID == TeID && x.AuthID == Auth_ID))
               .FirstOrDefaultAsync();

            if (value == null)
            {
                return Unauthorized();
            }

            String UploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "TeacherProfilePicture");
            String UniqueFileName = Guid.NewGuid().ToString() + "_" + teacher.Photo.FileName;
            String FilePath = Path.Combine(UploadFolder, UniqueFileName);
            teacher.Photo.CopyTo(new FileStream(FilePath, FileMode.Create));

            value.Profile_Image_Path = UniqueFileName;

            await _context.SaveChangesAsync();

            return Json(new { success = true, data = "Image Updated" });
        }

        [HeaderAuthorization]
        [Route("Teacher/ProfileCvUpdate")]
        [HttpPost]

        public async Task<ActionResult> ProfileCvUpdate(TeacherUpdateCv teacher)
        {
            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));
            int TeID = Convert.ToInt32(HttpContext.Session.GetString("TeID"));

            var value = await _context.Teacher
               .Where(x => (x.TeID == TeID && x.AuthID == Auth_ID))
               .FirstOrDefaultAsync();

            if (value == null)
            {
                return Unauthorized();
            }

            String UploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "TeacherCV");
            String UniqueFileName = Guid.NewGuid().ToString() + "_" + teacher.Cv.FileName;
            String FilePath = Path.Combine(UploadFolder, UniqueFileName);
            teacher.Cv.CopyTo(new FileStream(FilePath, FileMode.Create));

            value.CV_Path = UniqueFileName;

            await _context.SaveChangesAsync();

            return Json(new { success = true, data = "Image Updated" });
        }


        [HeaderAuthorization]
        [Route("Teacher/UploadTutorial/{CID}")]
        [HttpPost]
        public async Task<ActionResult> UploadTutorial(int CID, TeacherUploadTutorial tutorial)
        {
            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));
            int TeID = Convert.ToInt32(HttpContext.Session.GetString("TeID"));

            var value = await _context.Teacher
            .Where(x => (x.TeID == TeID && x.AuthID == Auth_ID))
            .FirstOrDefaultAsync();

            if (value == null)
            {
                return Unauthorized();
            }

            var title_Check = await _context.Tutorial
                .Where(x => (x.Title == tutorial.Title && x.AuthID == Auth_ID)).FirstOrDefaultAsync();

            if (title_Check != null)
            {
                return Json(new { success = false, error = "This Title is Already in USE" });
            }

            String UploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Tutorial");
            String UniqueFileName = Guid.NewGuid().ToString() + "_" + tutorial.Video.FileName;
            String FilePath = Path.Combine(UploadFolder, UniqueFileName);
            tutorial.Video.CopyTo(new FileStream(FilePath, FileMode.Create));

            var videoTutorial = new Tutorial
            {
                Title = tutorial.Title,
                Description = tutorial.Description,
                Video_Path = UniqueFileName,
                AuthID = Auth_ID,
            };

            _context.Tutorial.Add(videoTutorial);
            await _context.SaveChangesAsync();

            var TID = await _context.Tutorial
               .Where(x => (x.Title == tutorial.Title && x.AuthID == Auth_ID))
               .Select(y => new { y.TID })
               .FirstOrDefaultAsync();

            var joiningInsert = new Teacher_Course_Tutorial
            {
                TeID = TeID,
                CID = CID,
                TID = TID.TID,
                AuthID = Auth_ID,
            };

            _context.Teacher_Course_Tutorial.Add(joiningInsert);
            await _context.SaveChangesAsync();

            return Json(new { success = true, data = "Tutorial Uploaded Successfully" });


        }

        [HeaderAuthorization]
        [Route("Teacher/UpdateTutorial/{TID}")]
        [HttpPut]

        public async Task<ActionResult> UpdateTutorial(int TID, TeacherUpdateTutorial updateTutorial)
        {
            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));
            int TeID = Convert.ToInt32(HttpContext.Session.GetString("TeID"));

            var verify_Teacher = await _context.Teacher_Course_Tutorial
                .Where(x => (x.TeID == TeID && x.TID == TID && x.AuthID == Auth_ID))
                .FirstOrDefaultAsync();

            if (verify_Teacher == null)
            {
                return Unauthorized();
            }

            var data = await _context.Tutorial
                .Where(x => (x.TID == TID && x.AuthID == Auth_ID))
                .FirstOrDefaultAsync();

            var title_Verify = await _context.Tutorial
                .Where(x => (x.Title == updateTutorial.Title && x.AuthID == Auth_ID && x.TID != TID))
                .FirstOrDefaultAsync();

            if (title_Verify != null)
            {
                return Json(new { success = false, data = "This Title is Already Stored" });
            }

            data.Title = updateTutorial.Title;
            data.Description = updateTutorial.Description;

            await _context.SaveChangesAsync();

            return Json(new { success = true, data = "Tutorial Updated Successfully" });
        }

        [HeaderAuthorization]
        [Route("Teacher/UpdateTutorialVideo/{TID}")]
        [HttpPut]
        public async Task<ActionResult> UpdateTutorialVideo(int TID, TeacherUpdateVideo updateVideo)
        {
            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));
            int TeID = Convert.ToInt32(HttpContext.Session.GetString("TeID"));

            var verify_Teacher = await _context.Teacher_Course_Tutorial
                .Where(x => (x.TeID == TeID && x.TID == TID && x.AuthID == Auth_ID))
                .FirstOrDefaultAsync();

            if (verify_Teacher == null)
            {
                return Unauthorized();
            }

            var data = await _context.Tutorial
              .Where(x => (x.TID == TID && x.AuthID == Auth_ID))
              .FirstOrDefaultAsync();

            String UploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Tutorial");
            String UniqueFileName = Guid.NewGuid().ToString() + "_" + updateVideo.Video.FileName;
            String FilePath = Path.Combine(UploadFolder, UniqueFileName);
            updateVideo.Video.CopyTo(new FileStream(FilePath, FileMode.Create));

            data.Video_Path = UniqueFileName;
            await _context.SaveChangesAsync();

            return Json(new { success = true, data = "Tutorial Video Successfully Updated" });
        }


        [HeaderAuthorization]
        [Route("Teacher/Reaction/{TID}/{reaction}")]
        [HttpGet]
        public async Task<ActionResult> Like(int TID, int reaction)
        {

            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));
            int TeID = Convert.ToInt32(HttpContext.Session.GetString("TeID"));

            var value = await _context.Teacher
                .Where(x => (x.TeID == TeID && x.AuthID == Auth_ID))
                .FirstOrDefaultAsync();

            if (value == null)
            {
                return Unauthorized();
            }

            var LID = await _context.Teacher_Tutorial_Like
                .Where(x => (x.TeID == TeID && x.AuthID == Auth_ID && x.TID == TID))
                .Select(y => new { y.LID }).FirstOrDefaultAsync();

            if (LID == null)
            {
                var like = new Like
                {
                    Likes = reaction,
                    AuthID = Auth_ID
                };
                _context.Like.Add(like);
                await _context.SaveChangesAsync();

                int newLID = like.LID;

                var joiningInsert = new Teacher_Tutorial_Like
                {
                    TeID = TeID,
                    TID = TID,
                    LID = newLID,
                    AuthID = Auth_ID
                };
                _context.Teacher_Tutorial_Like.Add(joiningInsert);
                await _context.SaveChangesAsync();

                return Json(new { success = true });
            }
            else
            {
                var react = await _context.Like
                    .Where(x => (x.LID == LID.LID && x.AuthID == Auth_ID))
                    .FirstOrDefaultAsync();

                react.Likes = reaction;
                await _context.SaveChangesAsync();


                return Json(new { success = true });

            }

        }

        [HeaderAuthorization]
        [Route("Teacher/Comment/{TID}")]
        [HttpPut]
        public async Task<ActionResult> Comment(int TID, TeacherComment com)
        {
            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));
            int TeID = Convert.ToInt32(HttpContext.Session.GetString("TeID"));

            var value = await _context.Teacher
              .Where(x => (x.TeID == TeID && x.AuthID == Auth_ID))
              .FirstOrDefaultAsync();

            if (value == null)
            {
                return Unauthorized();
            }

            var ComID = await _context.Teacher_Tutorial_Comment
                .Where(x => (x.TeID == TeID && x.AuthID == Auth_ID && x.TID == TID))
                .Select(y => new { y.ComID }).FirstOrDefaultAsync();

            if (ComID == null)
            {
                var feedback = new Comment
                {
                    Comments = com.Comment,
                    AuthID = Auth_ID
                };
                _context.Comment.Add(feedback);
                await _context.SaveChangesAsync();

                int newComID = feedback.ComID;

                var joiningInsert = new Teacher_Tutorial_Comment
                {
                    TeID = TeID,
                    TID = TID,
                    ComID = newComID,
                    AuthID = Auth_ID
                };
                _context.Teacher_Tutorial_Comment.Add(joiningInsert);
                await _context.SaveChangesAsync();

                return Json(new { success = true, data = com.Comment });
            }
            else
            {
                var react = await _context.Comment
                    .Where(x => (x.ComID == ComID.ComID && x.AuthID == Auth_ID))
                    .FirstOrDefaultAsync();

                react.Comments = com.Comment;
                await _context.SaveChangesAsync();


                return Json(new { success = true, data = com.Comment });

            }

        }


        [HeaderAuthorization]
        [Route("Teacher/LogOut")]
        [HttpGet]
        public async Task<ActionResult> LogOut()
        {
            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));
            int TeID = Convert.ToInt32(HttpContext.Session.GetString("TeID"));

            var value = await _context.Teacher
                .Where(x => (x.TeID == TeID && x.AuthID == Auth_ID))
                .FirstOrDefaultAsync();

            if (value == null)
            {
                return Unauthorized();
            }


            //// Check The Better Proccess
            HttpContext.Session.Remove("TeID");

            await HttpContext.SignOutAsync("Student");
            await HttpContext.SignOutAsync("Provider");
            await HttpContext.SignOutAsync("Admin");
            await HttpContext.SignOutAsync("Teacher");

            return Json(new { success = true, ReturnURL = "/Home/Courses" });


        }




    }

    struct MyTutorial
    {
        public String Title { set; get; }

        public String Description { set; get; }

        public String Video_Path { set; get; }

        public int TID { set; get; }

        public int CID { set; get; }

        public int TeID { set; get; }
    }
}