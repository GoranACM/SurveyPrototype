<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="SurveyPrototype.SurveyPages.Staff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet" />
    <link rel="SHORTCUT ICON" href="~/SurveyImages/favicon.ico"/>
    <link href="~/SurveyStyles/StaffCSS.css" rel="stylesheet" />
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
        <div class="containerForm">
           <div><asp:Button ID="logOut" runat="server" Text="Logout" OnClick="logOut_Click" CssClass="button" /></div>
           <br />

            <br />
            <div class="grid">
                <asp:Label ID="Answer" runat="server" Text="Search respondent by:" Font-Size="25px" CssClass="labels"></asp:Label>
            </div>
            <br />
                <div class="filters">
                    
                    <div class="filterItem">               
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" CssClass="radio-toolbar">
                            <asp:ListItem>ID</asp:ListItem>
                            <asp:ListItem>First Name</asp:ListItem>
                            <asp:ListItem>Last Name</asp:ListItem>
                            <asp:ListItem>Phone Number</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <br />
                    <div class="filterItem">
                     
                    </div>

                </div>
            
            <div class="filters">            
                <div class="filterItem">
                    <asp:TextBox ID="SearchBox" runat="server" Placeholder="Search here..." Height="30px" Width="270px" Font-Names="Roboto" BorderColor="#5dbcd2" BorderWidth="2px"></asp:TextBox> 
                    <br />
                    <asp:Label ID="WarningLabel" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                </div>
            <br />
               <div class="filterItem">
                    <asp:Button ID="searchBtn" runat="server" Text="Search" style="background-color: #5dbcd2; color: white; margin-left: 90px;" CssClass="button" OnClick="searchBtn_Click"/>
                </div>         
            </div>
            <br />
            <div class="container">
                <div class="grid">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataKeyNames="sRespondentID" DataSourceID="SqlDataSource3" GridLines="None" AllowPaging="True" PageSize="10">
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
        </div>
        

    </form>
</body>
</html>
