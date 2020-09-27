<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SurveyEnd.aspx.cs" Inherits="SurveyPrototype.Survey.SurveyEnd" %>

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
        <div>
            <h1>SURVEY COMPLETED!</h1>
        </div>
        <div>
            <h2>Thank you for your participation!</h2>
        </div>
        <div>
            <h3>Feel free to close the tab...</h3>
        </div>
        <div>
            <asp:Table ID="UserAnswerTable" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableCell Font-Bold="true"></asp:TableCell>
                    <asp:TableCell Font-Bold="true">Answers</asp:TableCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell Font-Bold="true" ForeColor="#5dbcd2">__________________________________</asp:TableCell>
                    <asp:TableCell Font-Bold="true" ForeColor="#5dbcd2">________________________</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
