<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserReviews.aspx.cs" Inherits="Pages_UserReviews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Reviews
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        <div class=" jumbotron">
            <h3>Here you can edit User Details
            </h3>
        </div>
        <asp:GridView ID="GridViewReviews" runat="server" DataSourceID="SqlDataSource1"></asp:GridView>
    </form>

</asp:Content>

