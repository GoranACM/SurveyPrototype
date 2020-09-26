using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SurveyPrototype.SurveyDBUtilities
{
    public class SStaffDAO
    {
        public static bool ValidateUser(string username, string password)
        {
            try
            {
                string cn = ConfigurationManager.ConnectionStrings["SurveyDatabase"].ToString();
                using (SqlConnection con = new SqlConnection(cn))
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(staffID) FROM AITRStaff WHERE username=@username AND password=@password", con);

                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    con.Open();
                    int res = (int)cmd.ExecuteScalar();

                    if (res > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }                  
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}