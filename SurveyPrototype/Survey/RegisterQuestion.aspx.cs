﻿using SurveyPrototype.SurveyEntities;
using SurveyPrototype.SurveyDBUtilities;
using System;
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

            int respondentId = SRespondentDAO.InsertSession(Session.SessionID);

            //int respondentId = 1;

            List<SAnswer> userAnswers = (List<SAnswer>)Session["Answers"];

            foreach (SAnswer ans in userAnswers)
            {
                TableRow ansRow = new TableRow();
                ans.rID = respondentId;

                TableCell questionIDCell = new TableCell();
                questionIDCell.Text = ans.aID.ToString();

                TableCell answerCell = new TableCell();
                answerCell.Text = ans.aText.ToString();

                ansRow.Cells.Add(questionIDCell);
                ansRow.Cells.Add(answerCell);

                UserAnswerTable.Rows.Add(ansRow);
            }

            SQuestion question = SQuestionDAO.GetQuestionById(12);
            List<SQuestionOptions> questionOptions = SQuestionDAO.GetQuestionOptionsById(12);

            try
            {
                if (null != question && null != questionOptions)
                {
                    // Passing the text from the question entity to the label
                    // outside of the question Options
                    QuestionLabel.Text = question.qText;

                    RadioButtonList radioButtonList = new RadioButtonList(); // User controled box goes here
                    radioButtonList.Attributes["questionID"] = question.qID.ToString(); // Convert to string and pass to Next button
                    radioButtonList.ID = "RadioQuestion"; // Give it an ID

                    foreach (SQuestionOptions option in questionOptions) // Iterate through options
                    {
                        radioButtonList.Items.Add(new ListItem(option.qOptionText)); // Add each option to list
                    }

                    RadioButtonList1.Controls.Add(radioButtonList); // Add to placeholder
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}