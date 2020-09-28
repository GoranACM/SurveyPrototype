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
using System;
using System.Web.Security;
using System.Web.UI;

namespace SurveyPrototype.SurveyPages
{
    public partial class SurveyHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            invalidLoginLabel.Visible = false;
        }

        /// <summary>
        /// Button click to start the survey
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void surveyStartButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Survey/Survey.aspx", true);         
        }

        /// <summary>
        /// Button click to log in as a Staff member
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void loginBtn_Click(object sender, EventArgs e)
        {
            if (SStaffDAO.ValidateUser(UserNameBox.Text, PasswordBox.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(UserNameBox.Text, false);                
            }
            else
            {
                invalidLoginLabel.Visible = true;
            }
        }
    }
}