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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int rID = SRespondentDAO.InsertSession(sessionID: Session.SessionID); // Get the session ID for the current User

                List<SAnswer> userAnswers = (List<SAnswer>)Session["Answers"]; // Get the answers from the session

                // Loop through the answers
                foreach (SAnswer ans in userAnswers)
                {
                    SQuestion question1 = SQuestionDAO.GetQuestionById(ans.qID); // Get the question

                    // Create and populate table with the questions and answers of the user
                    TableRow ansRow = new TableRow();
                    ans.rID = rID;

                    TableCell questionTextCell = new TableCell();
                    questionTextCell.Text = question1.qText.ToString();

                    TableCell answerCell = new TableCell();
                    answerCell.Text = ans.aText.ToString();

                    ansRow.Cells.Add(questionTextCell);
                    ansRow.Cells.Add(answerCell);

                    // Add each answer and question to the table
                    UserAnswerTable.Rows.Add(ansRow);

                    // Insert each answer to the DB
                    SRespondentDAO.InsertSurvey(ans);
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/ErrorPages/ErrorPage.aspx");
                throw;
            }
        }

        protected void exitBtn_Click(object sender, EventArgs e)
        {
            
            SaveAnonimous();
            // Close the application
            Environment.Exit(1);
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {

            SaveAnonimous();
            // Redirect user to the register page
            Response.Redirect("~/Survey/Register.aspx");
        }

        private void SaveAnonimous()
        {
            try
            {
                // Get the respondent from the session
                SRespondent respondent = (SRespondent)Session["UserRespondent"];
                // Insert the respondent in the DB as Anonymous
                SRespondentDAO.InsertRespondent(respondent);
            }
            catch (Exception)
            {
                Response.Redirect("~/ErrorPages/ErrorPage.aspx");
                throw;
            }
        }
    }
}