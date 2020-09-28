/*  
 *  Project: AITResearch
 *  
 *  Developed by: Goran Ilievski
 *  ID: #7108
 *  Date: 30/08/2020
 *  
 *  Subject: Data-Driven Apps
 */

using SurveyPrototype.SurveyDBUtilities;
using SurveyPrototype.SurveyEntities;
using SurveyPrototype.SurveyUtilities;
using System;
using System.Web.UI;

namespace SurveyPrototype.Survey
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Disable box for entry so that the entry is valid from the Calendar picker
            DOBBox.Enabled = false;

            // Disable the warning labels
            wrongFirstNameLabel.Visible = false;
            wrongLastNameLabel.Visible = false;
            wrongNumberLabel.Visible = false;
        }

        /// <summary>
        /// Button to register the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void registerSurveyBtn_Click(object sender, EventArgs e)
        {
            // Check the 3 fields for wrong input
            if (SurveyUtil.IsPhoneNumber(PhoneNumberBox.Text) && SurveyUtil.IsNameOrLastName(FirstNameBox.Text) && SurveyUtil.IsNameOrLastName(LastNameBox.Text))
            {
                try
                {
                    int respondentID = (int)Session["UserID"];

                    SRespondent respondent = new SRespondent();

                    respondent.rID = respondentID;
                    respondent.rFirstName = FirstNameBox.Text;
                    respondent.rLastName = LastNameBox.Text;
                    respondent.rDateOfBirth = DateTime.Parse(DOBBox.Text); // TODO: Convert to date time
                    respondent.rPhoneNumber = PhoneNumberBox.Text;
                    
                    // Change respondent to complete
                    respondent.rComplete = 1;

                    SRespondentDAO.UpdateRespondent(respondent);

                    Session["UserRespondent"] = respondent;

                    Response.Redirect("~/Survey/SurveyEnd.aspx");
                }
                catch (Exception)
                {
                    //Response.Redirect("~/ErrorPages/ErrorPage.aspx");
                    throw;
                }
            }
            else
            {
                if (!SurveyUtil.IsNameOrLastName(FirstNameBox.Text))
                {
                    wrongFirstNameLabel.Text = "Please insert a valid First name";
                    wrongFirstNameLabel.Visible = true;
                }
                else if (!SurveyUtil.IsNameOrLastName(LastNameBox.Text))
                {
                    wrongLastNameLabel.Text = "Please insert a valid Last name";
                    wrongLastNameLabel.Visible = true;
                }
                else if (!SurveyUtil.IsPhoneNumber(PhoneNumberBox.Text))
                {
                    wrongNumberLabel.Text = "Please insert a valid number";
                    wrongNumberLabel.Visible = true;
                    //Response.Write("<script>alert('Wrong phone number');</script>");
                }
            }           
            
        }

        /// <summary>
        /// Button to toggle the Calendar visibility
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void calendarButton_Click(object sender, ImageClickEventArgs e)
        {
            DOBCalendar.Visible = !DOBCalendar.Visible;
            FirstNameBox.CausesValidation = false;
            LastNameBox.CausesValidation = false;
            DOBBox.CausesValidation = false;
            PhoneNumberBox.CausesValidation = false;
        }

        /// <summary>
        /// Function to select from the Calendar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DOBCalendar_SelectionChanged(object sender, EventArgs e)
        {
            DOBBox.Text = DOBCalendar.SelectedDate.ToShortDateString();
            DOBCalendar.Visible = false;
        }
        
    }
}