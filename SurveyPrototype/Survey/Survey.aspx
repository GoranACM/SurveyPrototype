<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Survey.aspx.cs" Inherits="SurveyPrototype.SurveyPages.Survey" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet" />
    <link rel="SHORTCUT ICON" href="~/SurveyImages/favicon.ico"/>
    <link href="~/SurveyStyles/SurveyMainCSS.css" rel="stylesheet" />
    <link href="~/SurveyStyles/SurveyQuestionCSS.css" rel="stylesheet" />
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
       <div class="container">
            <div class="center">                  
                <asp:Table ID="Table2" runat="server" Width="350px">
                    <asp:TableRow>
                        <asp:TableCell>                            
                            <asp:Label ID="QuestionLabel" runat="server" Text="" Font-Size="20px"></asp:Label>
                            <br /> <br />
                            <asp:PlaceHolder ID="QuestionPlaceholder" runat="server"></asp:PlaceHolder>
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Button ID="nextBtn" runat="server" Text="Next" style="background-color: #5dbcd2; color: white" CssClass="button" OnClick="nextBtn_Click"/>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>        
        </div>
    </form>
</body>
</html>
