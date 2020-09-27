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
using System;
using System.Text.RegularExpressions;
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
            if (IsPhoneNumber(PhoneNumberBox.Text) && IsNameOrLastName(FirstNameBox.Text) && IsNameOrLastName(LastNameBox.Text))
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
                if (!IsNameOrLastName(FirstNameBox.Text))
                {
                    wrongFirstNameLabel.Text = "Please insert a valid First name";
                    wrongFirstNameLabel.Visible = true;
                }
                else if (!IsNameOrLastName(LastNameBox.Text))
                {
                    wrongLastNameLabel.Text = "Please insert a valid Last name";
                    wrongLastNameLabel.Visible = true;
                }
                else if (!IsPhoneNumber(PhoneNumberBox.Text))
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

        /// <summary>
        /// Validation for First and Last name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Boolean</returns>
        public static bool IsNameOrLastName(string name)
        {
            return Regex.Match(name, @"^[\p{L} \.\-]+$").Success;
        }

        /// <summary>
        /// Validation for Australian numbers only
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>Boolean</returns>
        public static bool IsPhoneNumber(string phoneNumber)
        {
            return Regex.Match(phoneNumber, @"^([\+]?61[-]?|[0])?[1-9][0-9]{8}$").Success;
        }
        
    }
}