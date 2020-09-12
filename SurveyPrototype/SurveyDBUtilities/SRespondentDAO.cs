/*  
 *  Project: AITResearch
 *  
 *  Developed by: Goran Ilievski
 *  ID: #7108
 *  Date: 30/08/2020
 *  
 *  Subject: Data-Driven Apps
 */

using SurveyPrototype.SurveyEntities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SurveyPrototype.SurveyDBUtilities
{
    public class SRespondentDAO
    {
        public static void InsertRespondent(SRespondent respondent)
        {
            try
            {
                string cn = ConfigurationManager.ConnectionStrings["SurveyDatabase"].ToString();
                using (SqlConnection con = new SqlConnection(cn))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO SRespondent VALUES (@sRespondentID, @sRFirstName, @sRLastName, @sRDateOfBirth, @sRPhoneNumber, @sRIpAddress, @sRDateStamp)", con);

                    cmd.Parameters.AddWithValue("@sRespondentID", respondent.rID);
                    cmd.Parameters.AddWithValue("@sRFirstName", respondent.rFirstName);
                    cmd.Parameters.AddWithValue("@sRLastName", respondent.rLastName);
                    cmd.Parameters.AddWithValue("@sRDateOfBirth", respondent.rDateOfBirth);
                    cmd.Parameters.AddWithValue("@sRPhoneNumber", respondent.rPhoneNumber);
                    cmd.Parameters.AddWithValue("@sRIpAddress", respondent.rIpAddress);
                    cmd.Parameters.AddWithValue("@sRDateStamp", respondent.rDateStamp);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public static int InsertSession(string sessionID)
        {
            string cn = ConfigurationManager.ConnectionStrings["SurveyDatabase"].ToString();
            using (SqlConnection con = new SqlConnection(cn))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO SSession (sSessionID) OUTPUT INSERTED.ID VALUES (@sSessionID)", con);

                cmd.Parameters.AddWithValue("@sSessionID", sessionID);

                con.Open();

                return (int)cmd.ExecuteScalar();
            }
            //try
            //{
              
            //}
            //catch (Exception)
            //{

            //    throw;
            //}           
        }

        public static void InsertSurvey(SAnsweredQuestions answeredQuestions)
        {
            try
            {
                string cn = ConfigurationManager.ConnectionStrings["SurveyDatabase"].ToString();
                using (SqlConnection con = new SqlConnection(cn))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO SAnsweredQuestions VALUES(@sAnsweredQuestionID, @sAnswerID, @sQuestionID, @sRespondentID, @sAnsweredQuestionText");

                    cmd.Parameters.AddWithValue("@sAnsweredQuestionID", answeredQuestions.sAnsweredQuestionID);
                    cmd.Parameters.AddWithValue("@sAnswerID", answeredQuestions.aID);
                    cmd.Parameters.AddWithValue("@sQuestionID", answeredQuestions.qID);
                    cmd.Parameters.AddWithValue("@sRespondentID", answeredQuestions.rID);
                    cmd.Parameters.AddWithValue("@sAnsweredQuestionText", answeredQuestions.aAnsweredQuestionText);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }            
        }
    }
}