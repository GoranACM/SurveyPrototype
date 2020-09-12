<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="SurveyPrototype.SurveyPages.Staff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet" />
    <link rel="SHORTCUT ICON" href="~/SurveyImages/favicon.ico"/>
    <link href="~/SurveyStyles/SurveyMainCSS.css" rel="stylesheet" />
    <link href="~/SurveyStyles/SurveyQuestionCSS.css" rel="stylesheet" />
    <title>AITR Survey Staff</title>
</head>
<body>
    <header>
        <div class="container">
            <div>
                <asp:Image ID="image2" runat="server"                    
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
    <form id="form1" runat="server" class="grid">
        <asp:Label ID="Label2" runat="server" Text="Select filters" Font-Size="25px"></asp:Label>
        <div class="filters">
            <asp:Label ID="Label1" runat="server" Text="General" Font-Size="15px" CssClass="labels"></asp:Label>
            <div class="filterItem">               
                <asp:DropDownList ID="GenderDownList" runat="server" Height="25px" Width="150px" Font-Names="Roboto" BorderColor="#5dbcd2" BorderWidth="2px">
                    <asp:ListItem selected="True">Filter by gender...</asp:ListItem>
                    <asp:ListItem Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>                    
                </asp:DropDownList>
            </div>

            <div class="filterItem">               
                <asp:DropDownList ID="AgeDownList" runat="server" Height="25px" Width="150px" Font-Names="Roboto" BorderColor="#5dbcd2" BorderWidth="2px">
                    <asp:ListItem selected="True">Filter by gender...</asp:ListItem>
                    <asp:ListItem Value="1">18 - 25</asp:ListItem>
                    <asp:ListItem Value="2">26 - 30</asp:ListItem>
                    <asp:ListItem Value="3">31 - 40</asp:ListItem>
                    <asp:ListItem Value="4">41 - 55</asp:ListItem>
                    <asp:ListItem Value="5">56 - 70</asp:ListItem>
                    <asp:ListItem Value="6">70+</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="filterItem">                
                <asp:DropDownList ID="StateDropDown" runat="server" Height="25px" Width="150px" Font-Names="Roboto" BorderColor="#5dbcd2" BorderWidth="2px">
                    <asp:ListItem selected="True">Filter by state...</asp:ListItem>
                    <asp:ListItem Value="NSW">New South Wales</asp:ListItem>
                    <asp:ListItem Value="VIC">Victoria</asp:ListItem>
                    <asp:ListItem Value="SA">South Australia</asp:ListItem>
                    <asp:ListItem Value="QLD">Queensland</asp:ListItem>
                    <asp:ListItem Value="TAS">Tasmania</asp:ListItem>
                    <asp:ListItem Value="WA">Western Australia</asp:ListItem>
                    <asp:ListItem Value="NT">Northern Teritory</asp:ListItem>                    
                </asp:DropDownList>
            </div>
        </div>

        <div class="filters">
            <asp:Label ID="Label3" runat="server" Text="Bank" Font-Size="15px" CssClass="labels"></asp:Label>
            <div class="filterItem">               
                <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="150px" Font-Names="Roboto" BorderColor="#5dbcd2" BorderWidth="2px">
                    <asp:ListItem selected="True">Filter by bank...</asp:ListItem>
                    <asp:ListItem Value="CB">Commbank</asp:ListItem>
                    <asp:ListItem Value="ANZ">ANZ</asp:ListItem>
                    <asp:ListItem Value="WP">Westpac</asp:ListItem> 
                    <asp:ListItem Value="NAB">NAB</asp:ListItem> 
                </asp:DropDownList>
            </div>

            <div class="filterItem">               
                <asp:DropDownList ID="DropDownList2" runat="server" Height="25px" Width="150px" Font-Names="Roboto" BorderColor="#5dbcd2" BorderWidth="2px">
                    <asp:ListItem selected="True">Filter by bank service...</asp:ListItem>
                    <asp:ListItem Value="1">Internet Banking</asp:ListItem>
                    <asp:ListItem Value="2">Home Loan</asp:ListItem>
                    <asp:ListItem Value="3">Credit card</asp:ListItem>
                    <asp:ListItem Value="4">Share Investment</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="filterItem">               

            </div>


        </div>
        
        <div class="filters">
            <asp:Label ID="Label4" runat="server" Text="Newspaper" Font-Size="15px" CssClass="labels"></asp:Label>
            <div class="filterItem">               
                <asp:DropDownList ID="DropDownList3" runat="server" Height="25px" Width="150px" Font-Names="Roboto" BorderColor="#5dbcd2" BorderWidth="2px">
                    <asp:ListItem selected="True">Filter by newspaper...</asp:ListItem>
                    <asp:ListItem Value="M">The Daily Telegraph</asp:ListItem>
                    <asp:ListItem Value="F">Sports Illustrated</asp:ListItem>
                    <asp:ListItem Value="F">None</asp:ListItem>
                </asp:DropDownList>
            </div>
            
            <div class="filterItem">               
                <asp:DropDownList ID="DropDownList4" runat="server" Height="25px" Width="150px" Font-Names="Roboto" BorderColor="#5dbcd2" BorderWidth="2px">
                    <asp:ListItem selected="True">Filter by news section...</asp:ListItem>
                    <asp:ListItem Value="1">Property</asp:ListItem>
                    <asp:ListItem Value="2">Sport</asp:ListItem>
                    <asp:ListItem Value="3">Financial</asp:ListItem>
                    <asp:ListItem Value="4">Entertainment</asp:ListItem>
                    <asp:ListItem Value="5">Lifestyle</asp:ListItem>
                    <asp:ListItem Value="6">Travel</asp:ListItem>
                    <asp:ListItem Value="7">Politics</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="filterItem">                

            </div>
        </div>

        <div class="grid">
            <asp:Label ID="Answer" runat="server" Text="Search respondent:" Font-Size="25px" CssClass="labels"></asp:Label>
        </div>
        <div class="filters">            
            <div class="filterItem">
                <asp:TextBox ID="AnswerBox" runat="server" Placeholder="Search here..." Height="30px" Width="270px" Font-Names="Roboto" BorderColor="#5dbcd2" BorderWidth="2px"></asp:TextBox>                
            </div>
            <div class="filterItem">
                <asp:RequiredFieldValidator ID="answerValidator" runat="server" ErrorMessage="Answer Required" ControlToValidate="AnswerBox" CssClass="validator"></asp:RequiredFieldValidator>
            </div>
            
           <div class="filterItem">
                <asp:Button ID="nextBtn" runat="server" Text="Search" style="background-color: #5dbcd2; color: white" CssClass="button"/>
            </div>         
        </div>

        <div class="container">
            <div class="grid">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataKeyNames="sRespondentID" DataSourceID="SqlDataSource3" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="sRespondentID" HeaderText="sRespondentID" InsertVisible="False" ReadOnly="True" SortExpression="sRespondentID" />
                        <asp:BoundField DataField="sRFirstName" HeaderText="sRFirstName" SortExpression="sRFirstName" />
                        <asp:BoundField DataField="sRLastName" HeaderText="sRLastName" SortExpression="sRLastName" />
                        <asp:BoundField DataField="sRDateOfBirth" HeaderText="sRDateOfBirth" SortExpression="sRDateOfBirth" />
                        <asp:BoundField DataField="sRPhoneNumber" HeaderText="sRPhoneNumber" SortExpression="sRPhoneNumber" />
                        <asp:BoundField DataField="sRIpAddress" HeaderText="sRIpAddress" SortExpression="sRIpAddress" />
                        <asp:BoundField DataField="sRDateStamp" HeaderText="sRDateStamp" SortExpression="sRDateStamp" />
                    </Columns>
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#594B9C" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#33276A" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DB_A57250_D20DDA7108ConnectionString %>" SelectCommand="SELECT * FROM [SRespondent]"></asp:SqlDataSource>
            </div>                     
        </div>

        <div class="container">
            <div class="grid">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataSourceID="SqlDataSource2" GridLines="None" >
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#594B9C" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#33276A" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DB_A57250_D20DDA7108ConnectionString %>" SelectCommand="SELECT * FROM [RespondentTest]"></asp:SqlDataSource>
            </div>                     
        </div>

    </form>
</body>
</html>
