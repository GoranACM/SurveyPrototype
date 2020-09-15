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
using SurveyPrototype.SurveyUtilities;
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

            try
            {
                // Make sure to save Respondent once
                if (string.IsNullOrEmpty((string)Session["User"]))
                {
                    // Grab the User IP and save to variable
                    string userIP = SurveyUtil.getUserIP();

                    // Check if the IP Address has been captured
                    if (userIP != null)
                    {
                        // Create a new respondent
                        SRespondent respondent = new SRespondent();

                        // Give him Anonymous name
                        respondent.rFirstName = "Anonymous";
                        // Save the IP
                        respondent.rIpAddress = userIP;
                        // Save the current date
                        respondent.rDateStamp = DateTime.Now;
                        
                        // Save IP to a Session
                        Session["User"] = userIP;
                        // Save Respondent to a Session

                        SRespondentDAO.InsertRespondent(respondent);
                        //Session["UserRespondent"] = respondent;
                    }
                }
               
            }
            catch (Exception)
            {
                Response.Redirect("~/ErrorPages/ErrorPage.aspx");
                throw;
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
                        Session["CurrentQuestionID"] = question.qID; // Save to a session to use on Next button
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

                        Session["CurrentQuestionID"] = question.qID; // Save to a session to use on Next button

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

                        Session["CurrentQuestionID"] = question.qID; // Save to a session to use on Next button
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

                        Session["CurrentQuestionID"] = question.qID; // Save to a session to use on Next button
                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/ErrorPages/ErrorPage.aspx");
                throw;
            }

        }

        /// <summary>
        /// Button click for moving forward in the Survey questions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void nextBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int nextQuestionId = (int)Session["NextQID"];
                Session["NextQID"] = nextQuestionId + 1;

                SQuestion question = SQuestionDAO.GetQuestionById(nextQuestionId);

                // Method to call each different type of question
                if ("text".Equals(question.qType))
                {
                    TextBox textBox = (TextBox)QuestionPlaceholder.FindControl("TextQuestion"); // Get the question from the placeholder

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
                        //SAnswer userAnswer = new SAnswer();

                        //userAnswer.aText = checkButton.SelectedItem.Text;
                        //userAnswer.aID = (int)Session["CurrentQuestionID"];
                        //userAnswer.qID = Int16.Parse(checkButton.Attributes["questionId"]);

                        SAnswer userAnswer = new SAnswer();
                        string selectedItems = "";

                        foreach (ListItem checkedItem in checkButton.Items)
                        {
                            if (checkedItem.Selected)
                            {
                                selectedItems += checkedItem.Text + ", ";
                            }
                            userAnswer.qID = Int16.Parse(checkButton.Attributes["questionId"]);
                        }

                        selectedItems = selectedItems.TrimEnd(new char[] { ',' });
                        userAnswer.aText = selectedItems;
                        userAnswer.aID = (int)Session["CurrentQuestionID"];

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

                
            }
            catch (Exception)
            {
                Response.Redirect("~/ErrorPages/ErrorPage.aspx");
                throw;
            }

            if ((int)Session["NextQID"] == 12)
            {
                // Move to register question page
                Response.Redirect("~/Survey/RegisterQuestion.aspx");
            }
            else
            {
                Response.Redirect("~/Survey/Survey.aspx");
            }
        }
    }
}