<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Controlpanel.aspx.cs" Inherits="Pages_Controlpanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    ControlPanel
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class=" jumbotron">
            <h3>Here you can edit User Details
            </h3>
        </div>
        <asp:GridView CssClass="table-striped table table-hover" ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Username" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="Username" HeaderText="Username" ReadOnly="True" SortExpression="Username" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                    <asp:BoundField DataField="Birthdate" HeaderText="Birthdate" SortExpression="Birthdate" />
                    <asp:CheckBoxField DataField="Admin" HeaderText="Admin" SortExpression="Admin" />
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Users]" DeleteCommand="DELETE FROM [Users] WHERE [Username] = ?" InsertCommand="INSERT INTO [Users] ([Username], [Name], [Email], [Password], [Birthdate], [Admin]) VALUES (?, ?, ?, ?, ?, ?)" UpdateCommand="UPDATE [Users] SET [Name] = ?, [Email] = ?, [Password] = ?, [Birthdate] = ?, [Admin] = ? WHERE [Username] = ?">
                <DeleteParameters>
                    <asp:Parameter Name="Username" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Username" Type="String" />
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Password" Type="String" />
                    <asp:Parameter Name="Birthdate" Type="DateTime" />
                    <asp:Parameter Name="Admin" Type="Boolean" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Password" Type="String" />
                    <asp:Parameter Name="Birthdate" Type="DateTime" />
                    <asp:Parameter Name="Admin" Type="Boolean" />
                    <asp:Parameter Name="Username" Type="String" />
                </UpdateParameters>
        </asp:SqlDataSource>

</asp:Content>

