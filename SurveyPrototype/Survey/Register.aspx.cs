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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SurveyPrototype.Survey
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DOBBox.Enabled = false;
            //DOBCalendar.Visible = false;

            Console.WriteLine(Session["UserRespondent"]);
            if (!IsPostBack)
            {
                
            }

        }

        protected void registerSurveyBtn_Click(object sender, EventArgs e)
        {
           // if (!IsPostBack)
          //  {
                
                try
                {
                    // Get the respondent from the Session
                    SRespondent respondent = new SRespondent();
                    
                    respondent.rID = (int)Session["UserID"];
                    respondent.rFirstName = FirstNameBox.Text;
                    respondent.rLastName = LastNameBox.Text;
                    respondent.rDateOfBirth = DateTime.Parse(DOBBox.Text); // TODO: Convert to date time
                    respondent.rPhoneNumber = PhoneNumberBox.Text;
                    //respondent.rIpAddress = respondent.rIpAddress;

                    SRespondentDAO.UpdateRespondent(respondent);
                }
                catch (Exception)
                {
                    //Response.Redirect("~/ErrorPages/ErrorPage.aspx");
                    throw;
                }
          //  }
            
        }

        protected void calendarButton_Click(object sender, ImageClickEventArgs e)
        {
            DOBCalendar.Visible = !DOBCalendar.Visible;
            FirstNameBox.CausesValidation = false;
            LastNameBox.CausesValidation = false;
            DOBBox.CausesValidation = false;
            PhoneNumberBox.CausesValidation = false;
        }

        protected void DOBCalendar_SelectionChanged(object sender, EventArgs e)
        {
            DOBBox.Text = DOBCalendar.SelectedDate.ToShortDateString();
            DOBCalendar.Visible = false;
        }
    }
}