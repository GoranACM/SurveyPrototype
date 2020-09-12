<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterQuestion.aspx.cs" Inherits="SurveyPrototype.Survey.RegisterQuestion" %>

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
        <h2 style="text-align:center">Thanks for your participation</h2>
        <div class="container">            
            <div class="center">
                <h3>Here are your answers:</h3>
            </div>
            <div class="center">
                <asp:Table ID="UserAnswerTable" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableCell Font-Bold="true">Question ID</asp:TableCell>
                    <asp:TableCell Font-Bold="true">Answer</asp:TableCell>
                </asp:TableHeaderRow>
            </asp:Table>
            </div>            
        </div>
        <div>    
            <asp:Label ID="QuestionLabel" runat="server" Text="Label"></asp:Label>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" CssClass="radio-toolbar">
                <asp:ListItem Text=""></asp:ListItem>
                <asp:ListItem Text=""></asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </form>
</body>
</html>
