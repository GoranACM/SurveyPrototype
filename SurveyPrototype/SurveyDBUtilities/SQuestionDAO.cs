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
    /// <summary>
    /// Class for accessing the SQuestion table in DB
    /// </summary>
    public class SQuestionDAO
    {
        SurveyDBConnector surveyDB;

        /// <summary>
        /// Class constructor to establish connection and open Database
        /// </summary>
        public SQuestionDAO()
        {
            try
            {
                surveyDB = new SurveyDBConnector();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Method for a DB query and get a Question by its ID
        /// </summary>
        /// <param name="questionID"></param>
        /// <returns>Question</returns>
        public SQuestion GetQuestionById(int questionID)
        {
            SQuestion question = new SQuestion();

            SqlCommand cmd = new SqlCommand("SELECT sQuestionID, sQuestionText, sQuestionType, sNextQuestionID " +
                                                "FROM SQuestion " +
                                                "WHERE sQuestionID = @sQuestionID", surveyDB.connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                //Fill the Question object with the correspondent values 
                question.qID = Convert.ToInt32(reader["sQuestionID"].ToString());
                question.qText = reader["sQuestionText"].ToString();
                question.qType = reader["sQuestionType"].ToString();
                question.nQuestion = Convert.ToInt32(reader["sNextQuestionID"].ToString());
            }

            return question;

        /* Use this if the one above does not work
             
            string connectionString = ConfigurationManager.ConnectionStrings["SurveyDatabase"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Execute the SQL Command
                SqlCommand cmd = new SqlCommand("SELECT sQuestionID, sQuestionText, sQuestionType, sNextQuestionID " +
                                                "FROM SQuestion " +
                                                "WHERE sQuestionID = @sQuestionID", con);
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    //Fill the Question object with the correspondent values 
                    question.qID = Convert.ToInt32(reader["sQuestionID"].ToString());
                    question.qText = reader["sQuestionText"].ToString();
                    question.qType = reader["sQuestionType"].ToString();
                    question.nQuestion = Convert.ToInt32(reader["sNextQuestionID"].ToString());
                }

                return question;
            }
        */
        }
    }
}