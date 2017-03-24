<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Movies.aspx.cs" Inherits="Pages_Movies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Movies
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        <div class=" jumbotron">
            <h3>Here you can see all the movies</h3>
        </div>
    <asp:GridView CssClass="table-striped table table-hover" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="MovieName" HeaderText="MovieName" SortExpression="MovieName" />
            <asp:BoundField DataField="Director" HeaderText="Director" SortExpression="Director" />
            <asp:BoundField DataField="MovieGenre" HeaderText="MovieGenre" SortExpression="MovieGenre" />
            <asp:BoundField DataField="ReleaseDate" HeaderText="ReleaseDate" SortExpression="ReleaseDate" />
        </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\MoviesSiteDB.mdb;Persist Security Info=True" ProviderName="System.Data.OleDb" SelectCommand="SELECT [MovieName], [Director], [MovieGenre], [ReleaseDate] FROM [Movies]"></asp:SqlDataSource>

        <br />
    </form>
</asp:Content>

