using LotteryWeb.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace LotteryWeb.Models.DBOperations
{
    public class UserOperations
    {
        public static bool CreateUser(Users Obj)
        {
            bool r = true;
            try
            {
                using (SqlConnection con = DataConnection.GetConnection())
                {
                    SqlParameter[] parameters = {
                       new SqlParameter("@FirstName",Obj.Name),
                       new SqlParameter("@Email",Obj.Email),
                       new SqlParameter("@Phone",Obj.Phone),
                       new SqlParameter("@Password",Obj.Password),
                       new SqlParameter("@Image",Obj.Image),
                       new SqlParameter("@Address",Obj.Address),
                       new SqlParameter("@Balance",Obj.Balance),
                       new SqlParameter("@Id",Obj.UserId)
                        };
                    int rr = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Sp_EditUsers", parameters);
                    r=rr>0?true:false;
                }
            }
            catch (Exception ex)
            {
                r = false;
            }
            return r;
        }
        public static bool CreateTransaction(Transactions Obj)
        {
            bool r = true;
            try
            {
                using (SqlConnection con = DataConnection.GetConnection())
                {
                    SqlParameter[] parameters = {
                       new SqlParameter("@UserId",Obj.UserId),
                       new SqlParameter("@Detail",Obj.Detail),
                       new SqlParameter("@Description",Obj.Description),
                       new SqlParameter("@Type",Obj.Type),
                       new SqlParameter("@Amount",Obj.Amount),
                       new SqlParameter("@IsCredit",Obj.IsCredit),
                       new SqlParameter("@IsDebit",Obj.IsDebit),
                       new SqlParameter("@RPId",Obj.RPId),
                       new SqlParameter("@IsActive",Obj.IsActive)
                        };
                    int rr = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Sp_InsertTransactions", parameters);
                    r = rr > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                r = false;
            }
            return r;
        }
        public static bool CreateContest(long UserId,int LotteryNo,string ContestNo)
        {
            bool r = true;
            try
            {
                using (SqlConnection con = DataConnection.GetConnection())
                {
                    SqlParameter[] parameters = {
                       new SqlParameter("@UserId",UserId),
                       new SqlParameter("@ContestNo",ContestNo),
                       new SqlParameter("@LotteryNo",LotteryNo),
                       new SqlParameter("@IsWin",false)
                        };
                    int rr = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Sp_InsertContest", parameters);
                    r = rr > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                r = false;
            }
            return r;
        }
        public static Users GetUserData()
        {
            Users Obj = null;
            if(HttpContext.Current.Session["User"]!=null)
            {
                Obj = HttpContext.Current.Session["User"] as Users;
            }
            return Obj;
        }
        public static Users CheckUser(Users Obj)
        {
            try
            {
                using (SqlConnection con = DataConnection.GetConnection())
                {
                    SqlParameter[] parameters = {
                       new SqlParameter("@Email",Obj.Email),
                       new SqlParameter("@Password",Obj.Password)
                        };
                    DataSet ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Sp_CheckLogin", parameters);
                    if(ds!=null&&ds.Tables.Count>0&&ds.Tables[0]!=null&& ds.Tables[0].Rows.Count>0)
                    {
                        Obj= GetItem<Users>(ds.Tables[0].Rows[0]);
                        if(Obj.UserId>0)
                        {
                            HttpContext.Current.Session["User"] = Obj;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Obj = null;
            }
            return Obj;
        }
        public static List<Users> GetUsers()
        {
            List<Users> Obj = new List<Users>();
            try
            {
                using (SqlConnection con = DataConnection.GetConnection())
                {
                    DataSet ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Sp_GetUsers");
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        Obj = ConvertDataTable<Users>(ds.Tables[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                Obj = null;
            }
            return Obj;
        }
        public static List<Transactions> GetAllTransactions()
        {
            List<Transactions> Obj = new List<Transactions>();
            try
            {
                using (SqlConnection con = DataConnection.GetConnection())
                {
                    DataSet ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Sp_GetTransactions");
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        Obj = ConvertDataTable<Transactions>(ds.Tables[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                Obj = null;
            }
            return Obj;
        }
        public static List<Contest> GetAllContests()
        {
            List<Contest> Obj = new List<Contest>();
            try
            {
                using (SqlConnection con = DataConnection.GetConnection())
                {
                    DataSet ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Sp_GetContest");
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        Obj = ConvertDataTable<Contest>(ds.Tables[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                Obj = null;
            }
            return Obj;
        }
        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            try
            {
                foreach (DataColumn column in dr.Table.Columns)
                {
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        if(column.ColumnName=="Address")
                        {
                            var dataaa = "";
                        }
                        if (pro.Name == column.ColumnName&&DBNull.Value!= dr[column.ColumnName])
                            pro.SetValue(obj, dr[column.ColumnName], null);
                        else
                            continue;
                    }
                }
            }
            catch (Exception ex)
            {

                
            }
            
            return obj;
        }
    }
}