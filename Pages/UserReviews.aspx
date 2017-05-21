<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserReviews.aspx.cs" Inherits="Pages_UserReviews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Reviews
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class=" jumbotron">
            <h3>Here you can edit User Details
            </h3>
        </div>
        
        <asp:GridView CssClass="table-striped table table-hover" ID="GridViewReviews" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridViewReviews_RowCancelingEdit" OnRowEditing="GridViewReviews_RowEditing" OnRowUpdating="GridViewReviews_RowUpdating">
            <Columns>
                <asp:BoundField DataField="MovieName" HeaderText="Movie Name" ReadOnly="True" />
                <asp:BoundField DataField="RatingDate" HeaderText="Date" ReadOnly="True" />
                <asp:BoundField DataField="Rating" HeaderText="Rating" />
                <asp:BoundField DataField="Review" HeaderText="Review" />
                <asp:CommandField ShowEditButton="True" />
            </Columns>
        </asp:GridView>
    
</asp:Content>

