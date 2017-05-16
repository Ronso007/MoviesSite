<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserReviews.aspx.cs" Inherits="Pages_UserReviews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Reviews
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
        <div class=" jumbotron">
            <h3>Here you can edit User Details
            </h3>
        </div>
        asd
        <asp:GridView ID="GridViewReviews" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Bind(&quot;MovieName&quot;)" HeaderText="Movie Name" />
                <asp:BoundField  DataField="RatingDate" HeaderText="Date" />
                <asp:BoundField DataField="Rating" HeaderText="Rate" />
                <asp:BoundField DataField="Review" HeaderText="Review" />
            </Columns>
        </asp:GridView>
    asd
        </form>
</asp:Content>

