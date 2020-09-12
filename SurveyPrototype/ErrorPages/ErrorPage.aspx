<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="SurveyPrototype.ErrorPages.ErrorPage" %>

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
                <h1>OOPS..... There has been an error!</h1>
            </div>            
        </div>
    </header>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
