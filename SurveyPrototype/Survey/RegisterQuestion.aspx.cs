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
using SurveyPrototype.SurveyDBUtilities;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SurveyPrototype.Survey
{
    public partial class RegisterQuestion : System.Web.UI.Page
    {

        //int rID; // Get the session ID for the current User

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    int rID = SRespondentDAO.InsertSession(Session.SessionID); // Get the session ID for the current User

                    List<SAnswer> userAnswers = (List<SAnswer>)Session["Answers"]; // Get the answers from the session

                    // Loop through the answers
                    foreach (SAnswer ans in userAnswers)
                    {
                        SQuestion question = SQuestionDAO.GetQuestionById(ans.qID); // Get the question

                        // Create and populate table with the questions and answers of the user
                        TableRow ansRow = new TableRow();
                        ans.rID = rID;

                        TableCell questionTextCell = new TableCell();
                        questionTextCell.Text = question.qText.ToString();

                        TableCell answerCell = new TableCell();
                        answerCell.Text = ans.aText.ToString();

                        ansRow.Cells.Add(questionTextCell);
                        ansRow.Cells.Add(answerCell);

                        // Add each answer and question to the table
                        UserAnswerTable.Rows.Add(ansRow);

                        SRespondentDAO.InsertSurvey(ans);
                    }

                }
                catch (Exception)
                {
                    //Response.Redirect("~/ErrorPages/ErrorPage.aspx");
                    throw;
                }
            }
            
        }


        protected void registerBtn_Click(object sender, EventArgs e)
        {

            // SaveAnonimous();
            // InsertSurvey();
            // Redirect user to the register page
            // Session.Abandon();
            Response.Redirect("~/Survey/Register.aspx");
        }

        protected void closeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Survey/SurveyEnd.aspx");
        }

        //private void SaveAnonimous()
        //{
        //    try
        //    {
        //        // Get the respondent from the session
        //        SRespondent respondent = (SRespondent)Session["UserRespondent"];
        //        // Insert the respondent in the DB as Anonymous
        //        SRespondentDAO.InsertRespondent(respondent);
        //    }
        //    catch (Exception)
        //    {
        //        //Response.Redirect("~/ErrorPages/ErrorPage.aspx");
        //        throw;
        //    }
        //}

        //private void InsertSurvey()
        //{
        //    try
        //    {
        //        List<SAnswer> userAnswers = (List<SAnswer>)Session["Answers"]; // Get the answers from the session
        //        //int rID = SRespondentDAO.InsertSession(Session.SessionID); // Get the session ID for the current User

        //        // Loop through the answers
        //        foreach (SAnswer ans in userAnswers)
        //        {
        //            ans.aID = rID;
        //            // Insert each answer to the DB
        //            SRespondentDAO.InsertSurvey(ans);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        //Response.Redirect("~/ErrorPages/ErrorPage.aspx");
        //        throw;
        //    }
        //}
    }
}