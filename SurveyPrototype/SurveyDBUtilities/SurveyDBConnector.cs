/*  
 *  Project: AITResearch
 *  
 *  Developed by: Goran Ilievski
 *  ID: #7108
 *  Date: 30/08/2020
 *  
 *  Subject: Data-Driven Apps
 */

using System.Configuration;
using System.Data.SqlClient;

namespace SurveyPrototype.SurveyDBUtilities
{
    /// <summary>
    /// Class for the connection to the Database
    /// </summary>
    public class SurveyDBConnector
    {
        public SqlConnection connection;
        
        /// <summary>
        /// Class constructor to establish connection and open Database
        /// </summary>
        public SurveyDBConnector()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SurveyDatabase"].ConnectionString;

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
            }
        }
    }
}