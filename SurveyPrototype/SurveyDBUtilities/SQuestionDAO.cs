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

namespace SurveyPrototype.SurveyDBUtilities
{
    /// <summary>
    /// Class for accessing the SQuestion table in DB
    /// </summary>
    public class SQuestionDAO
    {
        /// <summary>
        /// Method for a DB query and get a Question by its ID
        /// </summary>
        /// <param name="questionID"></param>
        /// <returns>Question</returns>
        public static SQuestion GetQuestionById(int questionID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SurveyDatabase"].ConnectionString;
            SQuestion question = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Execute the SQL Command
                SqlCommand cmd = new SqlCommand("SELECT * " +
                                                "FROM SQuestion " +
                                                "WHERE sQuestionID = @sQuestionID", con);
                cmd.Parameters.AddWithValue("@sQuestionID", questionID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    question = new SQuestion();
                    //Fill the Question object with the correspondent values 
                    question.qID = (int)reader["sQuestionID"];
                    question.qText = reader["sQuestionText"].ToString();
                    question.qType = reader["sQuestionType"].ToString();
                    question.nQuestion = (int?)reader["sNextQuestionID"];
                }          
            }

            return question;
        }

        public static List<SQuestionOptions> GetQuestionOptionsById(int questionID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SurveyDatabase"].ConnectionString;
            List<SQuestionOptions> questionOptions = new List<SQuestionOptions>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Execute the SQL Command
                SqlCommand cmd = new SqlCommand("SELECT * " +
                                                "FROM SQuestionOptions " +
                                                "WHERE sQuestionID = @sQuestionID", con);
                cmd.Parameters.AddWithValue("@sQuestionID", questionID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SQuestionOptions sQuestionOptions = new SQuestionOptions();
                    //Fill the Question options object with the correspondent values 
                    sQuestionOptions.qID = (int)reader["sQuestionID"];
                    sQuestionOptions.qOptionText = reader["sQuestionOptionText"].ToString();
                    sQuestionOptions.qOptionID = (int)reader["sQuestionOptionID"];
                    if ((int?)reader["sNextQuestionID"] != null)
                    {
                        sQuestionOptions.nQuestion = (int?)reader["sNextQuestionID"];
                    }

                    questionOptions.Add(sQuestionOptions);
                }
            }

            return questionOptions;
        }
    }
}