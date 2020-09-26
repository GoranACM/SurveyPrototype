<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SurveyPrototype.Survey.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet" />
    <link rel="SHORTCUT ICON" href="~/SurveyImages/favicon.ico"/>    
    <link href="~/SurveyStyles/SurveyQuestionCSS.css" rel="stylesheet" />
    <title>AITR Survey Register</title>
</head>
<body>
    <header>
        <div class="container">
            <div>
                <asp:Image ID="image1" runat="server"                    
                    AlternateText="AITResearch"                         
                    Width="150px"
                    Height="150px"
                    ImageUrl="~/SurveyImages/aitr.png"
                />
            </div>
            <div>
                <h1>AITResearch Survey</h1>
            </div>            
        </div>
    </header>
    <form id="form1" runat="server">
        <div class="center">
            <div>
                <asp:Table ID="Table" runat="server" Width="450px">
                    <asp:TableRow>
                        <asp:TableCell>                            
                            <asp:Label ID="FirstName" runat="server" Text="What is your name?" Font-Size="25px"></asp:Label>
                            <br />
                            <asp:TextBox ID="FirstNameBox" runat="server" Placeholder="Enter your name here..." Height="30px" Width="257px" Font-Names="Roboto" BorderColor="#5dbcd2" BorderWidth="2px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="firstNameValidator" runat="server" ErrorMessage="First name Required" ControlToValidate="FirstNameBox" CssClass="validator"></asp:RequiredFieldValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>                                                        
                            <br />                           
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>                            
                            <asp:Label ID="LastName" runat="server" Text="What is your last name?" Font-Size="25px"></asp:Label>
                            <br />
                            <asp:TextBox ID="LastNameBox" runat="server" Placeholder="Enter your last name here..." Height="30px" Width="257px" Font-Names="Roboto" BorderColor="#5dbcd2" BorderWidth="2px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="lastNameValidator" runat="server" ErrorMessage="Last name Required" ControlToValidate="LastNameBox" CssClass="validator"></asp:RequiredFieldValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>                                                        
                            <br />                           
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>                            
                            <asp:Label ID="DOB" runat="server" Text="What is your Date of birth?" Font-Size="25px"></asp:Label>
                            <br />
                            <asp:TextBox ID="DOBBox" runat="server" Placeholder="Select your DOB below..." Height="30px" Width="257px" Font-Names="Roboto" BorderColor="#5dbcd2" BorderWidth="2px"></asp:TextBox>    
                            <asp:RequiredFieldValidator ID="dobValidator1" runat="server" ErrorMessage="Date of birth Required" ControlToValidate="DOBBox" CssClass="validator"></asp:RequiredFieldValidator>
                            <asp:ImageButton ID="calendarButton" runat="server" ImageUrl="~/SurveyImages/icons-calendar.png" OnClick="calendarButton_Click" />
                            <asp:Calendar ID="DOBCalendar" runat="server" OnSelectionChanged="DOBCalendar_SelectionChanged"></asp:Calendar>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>                                                        
                            <br />                           
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>                            
                            <asp:Label ID="PhoneNumber" runat="server" Text="What is your contact number?" Font-Size="25px"></asp:Label>
                            <br />
                            <asp:TextBox ID="PhoneNumberBox" runat="server" Placeholder="Enter your number here..." Height="30px" Width="257px" Font-Names="Roboto" BorderColor="#5dbcd2" BorderWidth="2px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="phoneNumberValidator" runat="server" ErrorMessage="Phone number Required" ControlToValidate="PhoneNumberBox" CssClass="validator"></asp:RequiredFieldValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <div style="margin-top: 30px; margin-left: 80px;">
                                <asp:Label ID="fieldWarningLabel" runat="server" Text="Label" CssClass="validator"></asp:Label>
                            </div>                            
                        </asp:TableCell>
                    </asp:TableRow>      
                    <asp:TableRow>
                        <asp:TableCell>
                            <div style="margin-top: 30px; margin-left: 80px;">
                                <asp:Button ID="registerSurveyBtn" runat="server" Text="Register" CssClass="button" OnClick="registerSurveyBtn_Click"  />
                            </div>                            
                        </asp:TableCell>
                    </asp:TableRow>                        
                </asp:Table>
            </div>
            <div>
                
            </div>
        </div>       
    </form>
</body>
</html>
