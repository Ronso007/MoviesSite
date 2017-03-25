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
    <asp:GridView CssClass="table-striped table table-hover" ID="GridViewMovies" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Movie Name">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("MovieName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Genre">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("MovieGenre") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Director">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Director") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date Of Release">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("ReleaseDate","{0:d MMM yyyy}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>




    </asp:GridView>
    </form>
</asp:Content>

