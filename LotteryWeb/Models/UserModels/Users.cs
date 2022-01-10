using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LotteryWeb.Models.UserModels
{
    public class Users
    {
        public long UserId { get; set; }
        public decimal Balance { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public long CreatedBy { get; set; }
        public int Role { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
    public class Transactions
    {
        public long UserId { get; set; }
        public string Detail { get; set; }
        public string Description { get; set; }
        public string RPId { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public bool IsCredit { get; set; }
        public bool IsDebit { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class Contest
    {
        public long UserId { get; set; }
        public string ContestNo { get; set; }
        public int LotteryNo { get; set; }
        public bool IsWin { get; set; }
        public DateTime ContestDate { get; set; }
    }
}