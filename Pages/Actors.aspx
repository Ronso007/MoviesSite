<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Actors.aspx.cs" Inherits="Pages_Actors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Actors
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class=" jumbotron">
            <h3>Here you can see all the movies</h3>
        </div>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>

