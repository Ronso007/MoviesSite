<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MoviePage.aspx.cs" Inherits="Pages_MoviePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
    Movie
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="jumbotron">

        <div class="text-center h1">
            <asp:Label ID="MovieName" runat="server" Text="asdasdasdasd"></asp:Label>
            <br />
            <asp:Image ID="movieImage" Height="400" Width="240" runat="server" />
            <br />
        </div>

        <div class="h3">
            <b>Director:</b><asp:Label ID="Director" runat="server" Text="Label1"></asp:Label>
                        <br />
            <b>Genre:</b><asp:Label ID="Genre" runat="server" Text="Label"></asp:Label>
            <br />
            <b>Duration:</b><asp:Label ID="Duration" runat="server" Text="Label2"></asp:Label> minutes
                        <br />
            <b>Actors:</b><asp:Label ID="Actors" runat="server" Text="Label3"></asp:Label>
                        <br />
            <b>Description:</b><asp:Label ID="Description" runat="server" Text="Label4"></asp:Label>
            <br />
            <div class="text-center">
            <iframe width="540" height="405" src="<%=VideoSource %>"></iframe>
            </div>
        </div>
    </div>

</asp:Content>

