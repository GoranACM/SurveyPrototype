﻿using SurveyPrototype.SurveyDBUtilities;
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

            // Load the first question and the options
            SQuestion question = SQuestionDAO.GetQuestionById(nextQID);
            List<SQuestionOptions> questionOptions = SQuestionDAO.GetQuestionOptionsById(nextQID);

            try
            {
                if (null != question && null != questionOptions)
                {
                    // Passing the text from the question entity to the label
                    // outside of the question Options
                    QuestionLabel.Text = question.qText; 

                    // Four IF statements for 4 types of questions
                    if ("text".Equals(question.qType))
                    {
                        TextBox txtBox = new TextBox(); // User controled box goes here
                        txtBox.Attributes["questionID"] = question.qID.ToString(); // Convert to string and pass to Next button
                        txtBox.ID = "TextQuestion"; // Give it an ID
                        QuestionPlaceholder.Controls.Add(txtBox); // Add to placeholder
                        Session["CurrentQuestionID"] = question.nQuestion + 1; // Save to a session to use on Next button
                    }
                    else if ("radio".Equals(question.qType))
                    {                       
                        RadioButtonList radioButtonList = new RadioButtonList(); // User controled box goes here
                        radioButtonList.Attributes["questionID"] = question.qID.ToString(); // Convert to string and pass to Next button
                        radioButtonList.ID = "RadioQuestion"; // Give it an ID

                        foreach (SQuestionOptions option in questionOptions) // Iterate through options
                        {
                            radioButtonList.Items.Add(new ListItem(option.qOptionText)); // Add each option to list
                        }

                        QuestionPlaceholder.Controls.Add(radioButtonList); // Add to placeholder

                        Session["CurrentQuestionID"] = question.nQuestion + 1; // Save to a session to use on Next button

                    }
                    else if ("checkbox".Equals(question.qType))
                    {
                        CheckBoxList checkBoxList = new CheckBoxList(); // User controled box goes here
                        checkBoxList.Attributes["questionID"] = question.qID.ToString(); // Convert to string and pass to Next button
                        checkBoxList.ID = "CheckboxQuestion"; // Give it an ID

                        foreach (SQuestionOptions option in questionOptions) // Iterate through options
                        {
                            checkBoxList.Items.Add(new ListItem(option.qOptionText)); // Add each option to list
                        }

                        QuestionPlaceholder.Controls.Add(checkBoxList); // Add to placeholder

                        Session["CurrentQuestionID"] = question.nQuestion + 1; // Save to a session to use on Next button
                    }
                    else if ("dropdown".Equals(question.qType))
                    {
                        DropDownList dropDownList = new DropDownList(); // User controled box goes here
                        dropDownList.Attributes["questionID"] = question.qID.ToString(); // Convert to string and pass to Next button
                        dropDownList.ID = "DropDownQuestion"; // Give it an ID

                        foreach (SQuestionOptions option in questionOptions) // Iterate through options
                        {
                            dropDownList.Items.Add(new ListItem(option.qOptionText)); // Add each option to list
                        }

                        QuestionPlaceholder.Controls.Add(dropDownList); // Add to placeholder

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

            // Method to call each different type of question
            if ("text".Equals(question.qType))
            {
                TextBox textBox = (TextBox)QuestionPlaceholder.FindControl("RadioQuestion"); // Get the question from the placeholder

                if (textBox != null)
                {
                    SAnswer userAnswer = new SAnswer();

                    userAnswer.aText = textBox.Text;
                    userAnswer.aID = (int)Session["CurrentQuestionID"];
                    userAnswer.qID = Int16.Parse(textBox.Attributes["questionId"]);

                    // Storing answers in a Session
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

                }
               
            }
            else if ("radio".Equals(question.qType))
            {
                RadioButtonList radioButton = (RadioButtonList)QuestionPlaceholder.FindControl("RadioQuestion"); // Get the question from the placeholder                

                if (radioButton.SelectedValue != null)
                {
                    SAnswer userAnswer = new SAnswer();

                    userAnswer.aText = radioButton.SelectedItem.Text;
                    userAnswer.aID = (int)Session["CurrentQuestionID"];
                    userAnswer.qID = Int16.Parse(radioButton.Attributes["questionId"]);

                    // Storing answers in a Session
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

                }
                
            }
            else if ("checkbox".Equals(question.qType))
            {
                CheckBoxList checkButton = (CheckBoxList)QuestionPlaceholder.FindControl("CheckboxQuestion"); // Get the question from the placeholder

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

                }

            }
            else if ("dropdown".Equals(question.qType))
            {
                DropDownList dropButton = (DropDownList)QuestionPlaceholder.FindControl("DropdownQuestion"); // Get the question from the placeholder

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

                }

            }

            if ((int)Session["NextQID"] == 12)
            {                
                // Simulate end of survey
                Response.Redirect("~/RegisterQuestion.aspx");
            }
            else
            {
                Response.Redirect("~/Survey/Survey.aspx");
            }
        }
    }
}