using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SurveyPrototype.SurveyPages
{
    public partial class SurveyHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void surveyStartButton_Click(object sender, ImageClickEventArgs e)
        {
            // TODO: Check why I cannot move without validation of login buttons
            Response.Redirect("~/Survey/Survey.aspx", true);         
        }

    }
}