using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LotteryWeb.Models.UserModels
{
    public class Users
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public long CreatedBy { get; set; }
        public int Role { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}