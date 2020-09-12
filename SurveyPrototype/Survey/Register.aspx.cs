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
            //try
            //{
            //    List<SAnsweredQuestions> userAnswers = (List<SAnsweredQuestions>)Session["Answers"];

            //    // Check if all survey answers are there and if the survey is complete
            //    if (userAnswers.Count > 12)
            //    {
            //        foreach (SAnsweredQuestions answer in userAnswers)
            //        {
            //            SRespondentDAO.InsertSurvey(answer);
            //        }
            //    }
            //    else
            //    {
            //        // TODO: You need to complete the questions in order to save the responses to DB
            //    }
            //}
            //catch (Exception)
            //{
            //    Response.Redirect("~/ErrorPages/ErrorPage.aspx");
            //    throw;
            //}
                        
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {

        }
    }
}