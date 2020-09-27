using SurveyPrototype.SurveyDBUtilities;
using SurveyPrototype.SurveyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SurveyPrototype.Survey
{
    public partial class SurveyEnd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SRespondent respondent = (SRespondent)Session["UserRespondent"];

            if (!respondent.rFirstName.Equals("Anonymous"))
            {
                try
                {

                    //int rID = SRespondentDAO.GetRespondent(respondent); // Get the session ID for the current User

                    // Create and populate table with the questions and answers of the registered user
                    // First name
                    TableRow answerRow = new TableRow();
                    TableCell questionCell = new TableCell();
                    TableCell answerCell = new TableCell();
                    questionCell.Text = "Your name is:";
                    answerCell.Text = respondent.rFirstName.ToString();
                    answerRow.Cells.Add(questionCell);
                    answerRow.Cells.Add(answerCell);
                    UserAnswerTable.Rows.Add(answerRow);

                    // Last name
                    TableRow answerRow2 = new TableRow();
                    TableCell questionCell2 = new TableCell();
                    TableCell answerCell2 = new TableCell();
                    questionCell2.Text = "Your last name is:";
                    answerCell2.Text = respondent.rLastName.ToString();
                    answerRow2.Cells.Add(questionCell2);
                    answerRow2.Cells.Add(answerCell2);
                    UserAnswerTable.Rows.Add(answerRow2);

                    // Date of birth
                    TableRow answerRow3 = new TableRow();
                    TableCell questionCell3 = new TableCell();
                    TableCell answerCell3 = new TableCell();
                    questionCell3.Text = "Your Date of birth is:";
                    DateTime DOB = (DateTime)respondent.rDateOfBirth.Value;
                    answerCell3.Text = DOB.ToString();
                    answerRow3.Cells.Add(questionCell3);
                    answerRow3.Cells.Add(answerCell3);
                    UserAnswerTable.Rows.Add(answerRow3);

                    // Phone number
                    TableRow answerRow4 = new TableRow();
                    TableCell questionCell4 = new TableCell();
                    TableCell answerCell4 = new TableCell();
                    questionCell4.Text = "Your phone number is:";
                    answerCell4.Text = respondent.rPhoneNumber.ToString();
                    answerRow4.Cells.Add(questionCell4);
                    answerRow4.Cells.Add(answerCell4);
                    UserAnswerTable.Rows.Add(answerRow4);

                    // Registration time
                    TableRow answerRow5 = new TableRow();
                    TableCell questionCell5 = new TableCell();
                    TableCell answerCell5 = new TableCell();
                    questionCell5.Text = "You registered on:";
                    answerCell5.Text = DateTime.Now.ToString();
                    answerRow5.Cells.Add(questionCell5);
                    answerRow5.Cells.Add(answerCell5);
                    UserAnswerTable.Rows.Add(answerRow5);
                }
                catch (Exception)
                {
                    //Response.Redirect("~/ErrorPages/ErrorPage.aspx");
                    throw;
                }
            }
            else
            {
                UserAnswerTable.Visible = false;
            }
            
        }
    }
}