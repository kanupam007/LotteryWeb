using LotteryWeb.Models.DBOperations;
using LotteryWeb.Models.UserModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
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
        public ActionResult Checkout(string ContestNo,string LotteryNum,string UserId)
        {
            if(!string.IsNullOrEmpty(ContestNo))
            {
                UserOperations.CreateContest(Convert.ToInt64(UserId), Convert.ToInt32(LotteryNum), ContestNo);
            }
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
        [Route("Admin-Login")]
        public ActionResult AdminLogin()
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
        [Route("SucessPay")]
        public ActionResult SucessPay(string ContestNo,string UserId)
        {
            string Token = null;
            if (Convert.ToString(Request.Form["razorpay_payment_id"]) != null)
            {
                Token =Convert.ToString(Request.Form["razorpay_payment_id"]);
            }
            Transactions Obj = new Transactions();
            Obj.UserId =Convert.ToInt64(UserId);
            Obj.Amount = Convert.ToDecimal(ConfigurationManager.AppSettings["BookingAmount"]);
            Obj.Description = "Contest No.: " + ContestNo;
            Obj.Detail = "LOTTERY PURCHASE";
            Obj.IsDebit = true;
            Obj.RPId = Token;
            Obj.Type = "RAZOR PAY";
            Obj.IsActive = string.IsNullOrEmpty(Token) ? false : true;
            UserOperations.CreateTransaction(Obj);
            return Redirect("/Transactions");
        }
    }
}