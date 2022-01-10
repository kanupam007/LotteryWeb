using LotteryWeb.Models.DBOperations;
using LotteryWeb.Models.UserModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LotteryWeb.Controllers
{
    [AuthorizeSessionAttribute]
    public class UserController : Controller
    {
        // GET: User
        [Route("Personal-Info")]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UpdateProfile(Users obj)
        {
            return Json(UserOperations.CreateUser(obj));
        }
        [HttpPost]
        public ActionResult UpdateProfilePicture()
        {
            string Filepath = "";
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;
                    HttpPostedFileBase file = files[0];
                    string fname = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
                    Filepath = "/content/assets/images/" + file.FileName;
                    string _path = Path.Combine(Server.MapPath("~/content/assets/images/"), file.FileName);
                    file.SaveAs(_path);
                    var data = UserOperations.GetUsers().Where(x => x.UserId == UserOperations.GetUserData().UserId).FirstOrDefault();
                    data.Image = Filepath;
                    return Json(UserOperations.CreateUser(data));
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }
        [Route("My-Tickets")]
        public ActionResult MyTickets()
        {
            return View();
        }
        [Route("Transactions")]
        public ActionResult Transactions()
        {
            return View();
        }
        
        public ActionResult LogOut()
        {
            Session.RemoveAll();
            return Redirect("/");
        }
    }
}