<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CheckboxQuestionControl.ascx.cs" Inherits="SurveyPrototype.SurveyUserControl.CheckboxQuestionControl" %>
<link href="~/SurveyStyles/SurveyQuestionCSS.css" rel="stylesheet" visible="false" runat="server" type="text/css"/>

<asp:CheckBoxList ID="CheckBoxList1" runat="server" CssClass="check-box">
    <asp:CheckBox runat="server" text=""></asp:CheckBox>
</asp:CheckBoxList>