/*  
 *  Project: AITResearch
 *  
 *  Developed by: Goran Ilievski
 *  ID: #7108
 *  Date: 30/08/2020
 *  
 *  Subject: Data-Driven Apps
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SurveyPrototype.SurveyUserControl
{
    public partial class TextQuestionControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AnswerBox = null;
        }

        public TextBox AnswerBox
        {
            get { return AnswerBox; }
            set { AnswerBox = value; }
        }
    }
}