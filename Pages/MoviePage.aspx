<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MoviePage.aspx.cs" Inherits="Pages_MoviePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
    Movie
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <link href="../Scripts/css/star-rating.css" rel="stylesheet" />
    <script src="../Scripts/js/star-rating.js"></script>
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

        <br />
        <br />
        <br />
        <%=RatingMsg %>
        <form runat="server" class="text-center" id="rating">
            <label class="active text-center">Write A Review:</label>
            <asp:TextBox ID="review" TextMode="MultiLine" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="review" ErrorMessage="Can't Be Empty!" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            <br />
            <label class="active">And Rate This Movie:</label>
            <asp:Button  ID="rating1" CssClass="btn btn-info" runat="server" Text="1" OnClick="rating1_Click" />
            <asp:Button ID="rating2" CssClass="btn btn-info" runat="server" Text="2" OnClick="rating2_Click" />
            <asp:Button ID="rating3" CssClass="btn btn-info" runat="server" Text="3" OnClick="rating3_Click" />
            <asp:Button ID="rating4" CssClass="btn btn-info" runat="server" Text="4" OnClick="rating4_Click" />
            <asp:Button ID="rating5" CssClass="btn btn-info" runat="server" Text="5" OnClick="rating5_Click" />
            <br />
        </form>
    </div>

</asp:Content>

