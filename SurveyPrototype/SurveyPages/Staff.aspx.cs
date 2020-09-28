/*  
 *  Project: AITResearch
 *  
 *  Developed by: Goran Ilievski
 *  ID: #7108
 *  Date: 30/08/2020
 *  
 *  Subject: Data-Driven Apps
 */

using SurveyPrototype.SurveyUtilities;
using System;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace SurveyPrototype.SurveyPages
{
    public partial class Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WarningLabel.Visible = false;
        }

        protected void logOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SearchBox.Text.Equals(""))
                {
                    WarningLabel.Visible = true;
                    WarningLabel.Text = "Please insert search phrase";
                }
                else
                {
                    if (RadioButtonList1.SelectedValue == "ID")
                    {
                        int parsedValue;

                        if (int.TryParse(SearchBox.Text, out parsedValue))
                        {
                            SearchByID();
                            WarningLabel.Visible = false;
                        }
                        else
                        {
                            WarningLabel.Text = "Please insert a valid ID";
                            WarningLabel.Visible = true;
                        }

                    }
                    else if (RadioButtonList1.SelectedValue == "First Name")
                    {
                        if (SurveyUtil.IsNameOrLastName(SearchBox.Text))
                        {
                            SearchByFirst();
                            WarningLabel.Visible = false;
                        }
                        else
                        {
                            WarningLabel.Visible = true;
                            WarningLabel.Text = "Please insert valid Name";
                        }
                    }
                    else if (RadioButtonList1.SelectedValue == "Last Name")
                    {
                        if (SurveyUtil.IsNameOrLastName(SearchBox.Text))
                        {
                            SearchByLast();
                            WarningLabel.Visible = false;
                        }
                        else
                        {
                            WarningLabel.Visible = true;
                            WarningLabel.Text = "Please insert valid Last Name";
                        }
                    }
                    else if (RadioButtonList1.SelectedValue == "Phone Number")
                    {
                        if (SurveyUtil.IsPhoneNumber(SearchBox.Text))
                        {
                            SearchByPhone();
                            WarningLabel.Visible = false;
                        }
                        else
                        {
                            WarningLabel.Visible = true;
                            WarningLabel.Text = "Please insert valid Phone Number";
                        }
                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/ErrorPages/ErrorPage.aspx");
                throw;
            }

        }

        protected void SearchByID()
        {
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (row.Cells[0].Text.ToString().Equals(SearchBox.Text))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void SearchByFirst()
        {
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (row.Cells[1].Text.ToString().Equals(SearchBox.Text))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void SearchByLast()
        {
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (row.Cells[2].Text.ToString().Equals(SearchBox.Text))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void SearchByPhone()
        {
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (row.Cells[4].Text.ToString().Equals(SearchBox.Text))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}