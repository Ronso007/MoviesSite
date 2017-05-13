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
            <p>
                <asp:DataList ID="GridViewMovies" runat="server" BorderColor="Black" BorderWidth="2px" GridLines="Both" RepeatColumns="5" CellPadding="2" CellSpacing="2" OnItemCommand="GridViewMovies_ItemCommand">
                    <ItemTemplate>
                        <asp:Label ID="movieName" CssClass="text-center"  runat="server" Font-Bold="true" Text='<%# Bind("MovieName") %>'></asp:Label>
                        <br />
                        <asp:Image ID="Image1" runat="server" Height="220" Width="200" ImageUrl='<%# Bind("image") %>'  ImageAlign="Middle"/>
                        <br />
                        Director:<asp:Label ID="director" runat="server" CssClass="text-center" Font-Bold="true" Text='<%# Bind("Director") %>'></asp:Label>
                        <br />
                        Genre:<asp:Label ID="Genre" runat="server" Font-Bold="true" Text='<%# Bind("MovieGenre") %>'></asp:Label>
                        &nbsp;<br />Duration:<asp:Label ID="Duration" Font-Bold="true" runat="server" Text='<%# Bind("Duration") %>'></asp:Label>
                        &nbsp;min<br />
                        <asp:Button ID="MovieButton" runat="server" Text="More Details" CommandName="Details" />
                    </ItemTemplate>
                </asp:DataList>
            </p>
        </div>
    </form>
</asp:Content>

