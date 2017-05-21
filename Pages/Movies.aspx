<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Movies.aspx.cs" Inherits="Pages_Movies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
    Movies
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <div class=" jumbotron">
            <h3>Here you can see all the movies</h3>
            <p>
                Rating :
                <asp:DropDownList CssClass="btn btn-xs" ID="RatingExpression" runat="server">
                    <asp:ListItem Value="0">Bigger Then</asp:ListItem>
                    <asp:ListItem Value="1">Equal Or Bigger Then</asp:ListItem>
                </asp:DropDownList>
                -
                            <asp:DropDownList ID="RatingDropDown" CssClass="btn btn-xs" runat="server">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem Selected="True">4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList>
                <asp:Button CssClass="btn btn-primary" ID="submitSort" runat="server" Text="Filter" OnClick="submitSort_Click" />
                - or - <asp:Button CssClass="btn btn-primary" ID="buttonShowAll" runat="server" Text="Show All" OnClick="buttonShowAll_Click" />

            </p>

        </div>
        <div class="jumbotron">
            <asp:DataList ID="GridViewMovies" runat="server" RepeatColumns="5" OnItemCommand="GridViewMovies_ItemCommand" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <asp:Label ID="movieName" CssClass="text-center" runat="server" Font-Bold="true" Text='<%# Bind("MovieName") %>'></asp:Label>
                    <br />
                    <asp:Image ID="Image1" runat="server" Height="220" Width="200" ImageUrl='<%# Bind("image") %>' ImageAlign="Middle" />
                    <br />
                    Director:<asp:Label ID="director" runat="server" CssClass="text-center" Font-Bold="true" Text='<%# Bind("Director") %>'></asp:Label>
                    <br />
                    Genre:<asp:Label ID="Genre" runat="server" Font-Bold="true" Text='<%# Bind("MovieGenre") %>'></asp:Label>
                    &nbsp;<br />
                    Duration:<asp:Label ID="Duration" Font-Bold="true" runat="server" Text='<%# Bind("Duration") %>'></asp:Label>
                    &nbsp;min<br />
                    Rating:<asp:Label ID="LabelRating" runat="server" Font-Bold="true" Font-Underline="true" Text='<%#String.Format("{0}", Convert.ToDouble(Eval("TotalRating")) / Convert.ToDouble(Eval("NumberOfUsers")))%>'></asp:Label>
                    /5<br />
                    <asp:Button ID="MovieButton" runat="server" Text="More Details" CommandName="Details" />
                </ItemTemplate>
            </asp:DataList>
        </div>
</asp:Content>

