using SurveyPrototype.SurveyDBUtilities;
using SurveyPrototype.SurveyEntities;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace SurveyPrototype.SurveyPages
{
    public partial class Survey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int nextQID = 1;

            // Check if the next question ID is not null to show the new question
            if (Session["NextQID"] != null)
            {
                nextQID = (int)Session["NextQID"];
            }
            else
            {
                Session["NextQID"] = nextQID;
            }

            // Load the first question
            SQuestion question = SQuestionDAO.GetQuestionById(nextQID);
            List<SQuestionOptions> questionOptions = SQuestionDAO.GetQuestionOptionsById(nextQID);

            try
            {
                if (null != question && null != questionOptions)
                {
                    QuestionLabel.Text = question.qText; // Pass the text from the question entity to the label

                    if ("text".Equals(question.qType))
                    {

                        TextBox txtBox = new TextBox(); // User controled box and not dinamically like this
                        txtBox.Attributes["questionID"] = question.qID.ToString(); // Has to be a string and pass to Next button
                        txtBox.ID = "TextQuestion";
                        QuestionPlaceholder.Controls.Add(txtBox);
                        Session["CurrentQuestionID"] = question.nQuestion + 1; // Save to a session to use on Next button
                    }
                    else if ("radio".Equals(question.qType))
                    {                       

                        RadioButtonList radioButtonList = new RadioButtonList();
                        radioButtonList.Attributes["questionID"] = question.qID.ToString();
                        radioButtonList.ID = "RadioQuestion";

                        foreach (SQuestionOptions option in questionOptions)
                        {
                            radioButtonList.Items.Add(new ListItem(option.qOptionText));
                        }

                        QuestionPlaceholder.Controls.Add(radioButtonList);

                        Session["CurrentQuestionID"] = question.nQuestion + 1;
                        
                    }
                    else if ("checkbox".Equals(question.qType))
                    {
                        CheckBoxList checkBoxList = new CheckBoxList(); // User controled box and not dinamically like this
                        checkBoxList.Attributes["questionID"] = question.qID.ToString(); // Has to be a string and pass to Next button
                        checkBoxList.ID = "CheckboxQuestion";

                        foreach (SQuestionOptions option in questionOptions)
                        {
                            checkBoxList.Items.Add(new ListItem(option.qOptionText));
                        }

                        QuestionPlaceholder.Controls.Add(checkBoxList);
                        Session["CurrentQuestionID"] = question.nQuestion + 1; // Save to a session to use on Next button
                    }
                    else if ("dropdown".Equals(question.qType))
                    {
                        DropDownList dropDownList = new DropDownList(); // User controled box and not dinamically like this
                        dropDownList.Attributes["questionID"] = question.qID.ToString(); // Has to be a string and pass to Next button
                        dropDownList.ID = "DropDownQuestion";

                        foreach (SQuestionOptions option in questionOptions)
                        {
                            dropDownList.Items.Add(new ListItem(option.qOptionText));
                        }

                        QuestionPlaceholder.Controls.Add(dropDownList);
                        Session["CurrentQuestionID"] = question.nQuestion + 1; // Save to a session to use on Next button
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void nextBtn_Click(object sender, EventArgs e)
        {
            int nextQuestionId = (int)Session["NextQID"];
            Session["NextQID"] = nextQuestionId + 1;

            SQuestion question = SQuestionDAO.GetQuestionById(nextQuestionId);

            if ("text".Equals(question.qType))
            {
                TextBox textBox = (TextBox)QuestionPlaceholder.FindControl("RadioQuestion");

                if (textBox != null)
                {
                    SAnswer userAnswer = new SAnswer();

                    userAnswer.aText = textBox.Text;
                    userAnswer.aID = (int)Session["CurrentQuestionID"];
                    userAnswer.qID = Int16.Parse(textBox.Attributes["questionId"]);


                    // Storing answers in a Session, make a method to call for each different type of question
                    if (Session["Answers"] != null)
                    {
                        // Store each following Answer in the same session
                        List<SAnswer> userAnswers = (List<SAnswer>)Session["Answers"];
                        userAnswers.Add(userAnswer);

                        Session["Answers"] = userAnswers;
                    }
                    else
                    {
                        // Store the first answer in a newly created List
                        List<SAnswer> userAnswers = new List<SAnswer>();
                        userAnswers.Add(userAnswer);

                        Session["Answers"] = userAnswers;
                    }

                    Response.Write("Answer : " + textBox.Text);
                }


                
            }
            else if ("radio".Equals(question.qType))
            {
                RadioButtonList radioButton = (RadioButtonList)QuestionPlaceholder.FindControl("RadioQuestion");                

                if (radioButton.SelectedValue != null)
                {
                    SAnswer userAnswer = new SAnswer();

                    userAnswer.aText = radioButton.SelectedItem.Text;
                    userAnswer.aID = (int)Session["CurrentQuestionID"];
                    userAnswer.qID = Int16.Parse(radioButton.Attributes["questionId"]);


                    // Storing answers in a Session, make a method to call for each different type of question
                    if (Session["Answers"] != null)
                    {
                        // Store each following Answer in the same session
                        List<SAnswer> userAnswers = (List<SAnswer>)Session["Answers"];
                        userAnswers.Add(userAnswer);

                        Session["Answers"] = userAnswers;
                    }
                    else
                    {
                        // Store the first answer in a newly created List
                        List<SAnswer> userAnswers = new List<SAnswer>();
                        userAnswers.Add(userAnswer);

                        Session["Answers"] = userAnswers;
                    }

                    Response.Write("Answer : " + radioButton.SelectedValue.ToString());
                }


                
            }
            else if ("checkbox".Equals(question.qType))
            {
                CheckBoxList checkButton = (CheckBoxList)QuestionPlaceholder.FindControl("CheckboxQuestion");

                if (checkButton.SelectedValue != null)
                {
                    SAnswer userAnswer = new SAnswer();

                    userAnswer.aText = checkButton.SelectedItem.Text;
                    userAnswer.aID = (int)Session["CurrentQuestionID"];
                    userAnswer.qID = Int16.Parse(checkButton.Attributes["questionId"]);


                    // Storing answers in a Session, make a method to call for each different type of question
                    if (Session["Answers"] != null)
                    {
                        // Store each following Answer in the same session
                        List<SAnswer> userAnswers = (List<SAnswer>)Session["Answers"];
                        userAnswers.Add(userAnswer);

                        Session["Answers"] = userAnswers;
                    }
                    else
                    {
                        // Store the first answer in a newly created List
                        List<SAnswer> userAnswers = new List<SAnswer>();
                        userAnswers.Add(userAnswer);

                        Session["Answers"] = userAnswers;
                    }

                    Response.Write("Answer : " + checkButton.SelectedValue.ToString());
                }



            }
            else if ("dropdown".Equals(question.qType))
            {
                DropDownList dropButton = (DropDownList)QuestionPlaceholder.FindControl("DropdownQuestion");

                if (dropButton.SelectedValue != null)
                {
                    SAnswer userAnswer = new SAnswer();

                    userAnswer.aText = dropButton.SelectedItem.Text;
                    userAnswer.aID = (int)Session["CurrentQuestionID"];
                    userAnswer.qID = Int16.Parse(dropButton.Attributes["questionId"]);


                    // Storing answers in a Session, make a method to call for each different type of question
                    if (Session["Answers"] != null)
                    {
                        // Store each following Answer in the same session
                        List<SAnswer> userAnswers = (List<SAnswer>)Session["Answers"];
                        userAnswers.Add(userAnswer);

                        Session["Answers"] = userAnswers;
                    }
                    else
                    {
                        // Store the first answer in a newly created List
                        List<SAnswer> userAnswers = new List<SAnswer>();
                        userAnswers.Add(userAnswer);

                        Session["Answers"] = userAnswers;
                    }

                    Response.Write("Answer : " + dropButton.SelectedValue.ToString());
                }



            }

            if ((int)Session["NextQID"] > 3)
            {
                // Simulate end of survey
                Response.Redirect("~/EndSurvey.aspx");
            }
            else
            {
                Response.Redirect("~/Survey.aspx");
            }
        }
    }
}