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
            

        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    // Get the respondent from the Session
            //    SRespondent respondent = (SRespondent)Session["UserRespondent"];
                
            //    respondent.rFirstName = FirstNameBox.Text;
            //    respondent.rLastName = LastNameBox.Text;
            //    respondent.rDateOfBirth = DOBBox.Text; // TODO: Convert to date time
            //    respondent.rPhoneNumber = PhoneNumberBox.Text;
            //    respondent.rIpAddress = respondent.rIpAddress;
            //}
            //catch (Exception)
            //{
            //    Response.Redirect("~/ErrorPages/ErrorPage.aspx");
            //    throw;
            //}
        }
    }
}