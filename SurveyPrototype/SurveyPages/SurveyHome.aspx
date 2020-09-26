<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SurveyHome.aspx.cs" Inherits="SurveyPrototype.SurveyPages.SurveyHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet" />
    <link rel="SHORTCUT ICON" href="~/SurveyImages/favicon.ico"/>
    <link href="~/SurveyStyles/SurveyMainCSS.css" rel="stylesheet" />
    <title>AITR Survey</title>
</head>

<body>
    <header>
        <div class="container">
            <div>
                <h1 style="margin-left: 20px">AITResearch Survey</h1>
            </div>            
        </div>
    </header>
    <form id="form1" runat="server">
        <div class="container">
            <div class="center">    
                <asp:Table ID="Table1" runat="server" style="border-right: 3px solid #5dbcd2; display: flex" Width="300px">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label1" runat="server" Text="Click here to start the survey!"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Image ID="Image1" runat="server" 
                            style="margin-left: 40px"
                            AlternateText="Arrow"
                            Width="100px"
                            Height="100px"
                            ImageUrl="~/SurveyImages/arrow.png"
                        />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:ImageButton ID="surveyStartButton" runat="server"
                            Style="margin-left: 100px; margin-right: -50px"
                            AlternateText="AITResearch"
                            Width="150px"
                            Height="150px"
                            ImageUrl="~/SurveyImages/aitr.png" OnClick="surveyStartButton_Click" causesvalidation="false"/>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            </div>
            <div class="center">
                <h1>AITResearch <br /> staff login</h1>                
                <asp:Table ID="Table2" runat="server" Width="350px">
                    <asp:TableRow>
                        <asp:TableCell>                            
                            <asp:Label ID="UserName" runat="server" Text="Username:"></asp:Label>
                            <br />
                            <asp:TextBox ID="UserNameBox" runat="server" Placeholder="Enter username here..." Height="30px" Width="170px" Font-Names="Roboto" BorderColor="#5dbcd2" BorderWidth="2px"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="userNameValidator" runat="server" ErrorMessage="Username Required" ControlToValidate="UserNameBox" CssClass="validator"></asp:RequiredFieldValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="Password" runat="server" Text="Password:"></asp:Label>
                            <br />
                            <asp:TextBox ID="PasswordBox" runat="server" Placeholder="Enter password here..." TextMode="Password" Height="30px" Width="170px" Font-Names="Roboto" BorderColor="#5dbcd2" BorderWidth="2px"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="passwordValidator" runat="server" ErrorMessage="Password required" ControlToValidate="PasswordBox" CssClass="validator"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="invalidLoginLabel" runat="server" Text="Invalid Username or Password" CssClass="validator"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="3">
                            <asp:Button ID="loginBtn" runat="server" Text="Login" style="background-color: #5dbcd2; color: white" CssClass="button" OnClick="loginBtn_Click"/>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>        
        </div>
    </form>
</body>
</html>
