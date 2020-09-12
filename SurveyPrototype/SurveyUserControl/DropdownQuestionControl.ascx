<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DropdownQuestionControl.ascx.cs" Inherits="SurveyPrototype.SurveyUserControl.DropdownQuestionControl" %>
<link href="~/SurveyStyles/SurveyQuestionCSS.css" rel="stylesheet" visible="false" runat="server" type="text/css"/>

<asp:DropDownList ID="AnswerDropDown" runat="server" CssClass="drop-down">
    <asp:ListItem Text=""></asp:ListItem>                       
</asp:DropDownList>