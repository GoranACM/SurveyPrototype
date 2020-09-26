﻿/*  
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
using System.Configuration;
using System.Data.SqlClient;

namespace SurveyPrototype.SurveyDBUtilities
{
    public class SRespondentDAO
    {
        /// <summary>
        /// Method for Inserting a Respondent in the DB
        /// </summary>
        /// <param name="respondent"></param>
        public static void InsertRespondent(SRespondent respondent)
        {
            try
            {
                string cn = ConfigurationManager.ConnectionStrings["SurveyDatabase"].ToString();
                using (SqlConnection con = new SqlConnection(cn))
                {
                    
                    SqlCommand cmd = new SqlCommand("INSERT INTO SRespondent (sRFirstName, sRIpAddress, sRDateStamp) VALUES (@sRFirstName, @sRIpAddress, @sRDateStamp) SELECT CAST(scope_identity() AS int)", con);

                    //cmd.Parameters.AddWithValue("@sRespondentID", respondent.rID);
                    cmd.Parameters.AddWithValue("@sRFirstName", respondent.rFirstName);
                    //cmd.Parameters.AddWithValue("@sRLastName", respondent.rLastName);
                    //cmd.Parameters.AddWithValue("@sRDateOfBirth", respondent.rDateOfBirth);
                    //cmd.Parameters.AddWithValue("@sRPhoneNumber", respondent.rPhoneNumber);
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

        /// <summary>
        /// Method for Updating a Respondent in the DB
        /// </summary>
        /// <param name="respondent"></param>
        public static void UpdateRespondent(SRespondent respondent)
        {
            try
            {                
                string cn = ConfigurationManager.ConnectionStrings["SurveyDatabase"].ToString();
                using (SqlConnection con = new SqlConnection(cn))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE SRespondent SET sRFirstName=@sRFirstName, " +
                        "sRLastName=@sRLastName, sRDateOfBirth=@sRDateOfBirth, sRPhoneNumber=@sRPhoneNumber WHERE sRespondentID=@sRespondentID)", con);

                    cmd.Parameters.AddWithValue("@sRespondentID", respondent.rID);                   
                    cmd.Parameters.AddWithValue("@sRFirstName", respondent.rFirstName);
                    cmd.Parameters.AddWithValue("@sRLastName", respondent.rLastName);
                    cmd.Parameters.AddWithValue("@sRDateOfBirth", respondent.rDateOfBirth);
                    cmd.Parameters.AddWithValue("@sRPhoneNumber", respondent.rPhoneNumber);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Method for Inserting a Respondent session in the DB
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="rID"></param>
        /// <returns></returns>
        //public static int InsertSession(string sessionID, int rID)
        public static int InsertSession(string sessionID)
        {
            try
            {
                string cn = ConfigurationManager.ConnectionStrings["SurveyDatabase"].ToString();
                using (SqlConnection con = new SqlConnection(cn))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO SSession (sSessionID) OUTPUT INSERTED.sID VALUES (@sSessionID)", con);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO SSession (sSessionID, sRespondentID) OUTPUT INSERTED.sID VALUES (@sSessionID, @sRespondentID)", con);

                    cmd.Parameters.AddWithValue("@sSessionID", sessionID);
                    //cmd.Parameters.AddWithValue("@sRespondentID", rID);

                    con.Open();

                    return (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Method for Inserting a Respondent survey in the DB
        /// </summary>
        /// <param name="answeredQuestions"></param>
        public static void InsertSurvey(SAnswer answeredQuestions)
        {
            try
            {
                string cn = ConfigurationManager.ConnectionStrings["SurveyDatabase"].ToString();
                using (SqlConnection con = new SqlConnection(cn))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO SAnswer VALUES(@sQuestionID, @sRespondentID, @sAnswerText)", con);
                    
                    cmd.Parameters.AddWithValue("@sQuestionID", answeredQuestions.qID);
                    cmd.Parameters.AddWithValue("@sRespondentID", answeredQuestions.rID);
                    cmd.Parameters.AddWithValue("@sAnswerText", answeredQuestions.aText);
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