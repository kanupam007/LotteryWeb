using LotteryWeb.Models.DBOperations;
using LotteryWeb.Models.UserModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LotteryWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public delegate bool SaveUsers(Users Obj);
        public ActionResult Index()
        {
            return View();
        }
        [AuthorizeSessionAttribute]
        [Route("Lottery-Contest")]
        public ActionResult Contest()
        {
            return View();
        }
        [Route("About-Us")]
        public ActionResult About()
        {
            return View();
        }
        [Route("Contact-Us")]
        public ActionResult Contact()
        {
            return View();
        }
        [Route("FAQs")]
        public ActionResult FAQs()
        {
            return View();
        }
        [Route("Term-Conditions")]
        public ActionResult Terms()
        {
            return View();
        }
        [Route("Checkout")]
        public ActionResult Checkout()
        {
            return View();
        }
        
        [Route("Privacy-Policy")]
        public ActionResult Privacy()
        {
            return View();
        }
        [Route("Cookies-Policy")]
        public ActionResult Cookies()
        {
            return View();
        }
        #region Signup/Login
        [Route("Register")]
        public ActionResult Register(Users Obj)
        {
            //ArrayList arrAsyncResult = new ArrayList();
            //IAsyncResult asyncResult = default(IAsyncResult);
            //SaveUsers ObjThread = null;
            //ObjThread = new SaveUsers(UserOperations.CreateUser);
            //asyncResult = ObjThread.BeginInvoke(Obj, null,"Test");
            //arrAsyncResult.Add(asyncResult);
            //foreach (IAsyncResult item in arrAsyncResult)
            //{
            //    try
            //    {
            //        if (item.AsyncState.ToString().ToUpper() == "Test" && ObjThread != null)
            //        {
            //            var data = ObjThread.EndInvoke(item);
            //        }
                    
            //    }
            //    catch (Exception ex)
            //    {
                    
            //    }
            //}
            return Json(UserOperations.CreateUser(Obj));
        }
        [Route("Login")]
        public ActionResult Login(Users Obj)
        {
            return Json(UserOperations.CheckUser(Obj));
        }
        #endregion
        
        public ActionResult SucessPay()
        {
            if (Convert.ToString(Request.Form["razorpay_payment_id"]) != null)
            {
                var Token = Request.Form["razorpay_payment_id"].ToString();

            }
            return null;
        }
    }
}