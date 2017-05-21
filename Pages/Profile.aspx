<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Pages_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Profile
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Scripts/css/Register.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.6.1/css/font-awesome.min.css" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row main">
        <div class="main-login main-center">
                <div class="form-group">
                    <label for="username" class="cols-sm-2 control-label">Username</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-users fa" aria-hidden="true"></i></span>
                            <asp:TextBox CssClass="form-control" ID="username" runat="server" MaxLength="16" placeholder="Enter your Username" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="name" class="cols-sm-2 control-label">Your Name</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
                            <asp:TextBox CssClass="form-control" ID="name" runat="server" MaxLength="16" placeholder="Enter your Name"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <label for="email" class="cols-sm-2 control-label">Your Email</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-envelope fa" aria-hidden="true"></i></span>
                            <asp:TextBox CssClass="form-control" ID="email" runat="server" MaxLength="25" placeholder="Enter your Email"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <label for="username" class="cols-sm-2 control-label">Birthdate</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-birthday-cake fa" aria-hidden="true"></i></span>
                            <asp:TextBox CssClass="form-control" ID="birthday" runat="server" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <label for="password" class="cols-sm-2 control-label">Password</label>
                    <div class="cols-sm-10">
                        <div class="input-group" id="passwordError" runat="server">
                            <span class="input-group-addon"><i class="fa fa-lock fa-lg" aria-hidden="true"></i></span>
                            <asp:TextBox CssClass="form-control" ID="password" runat="server" MaxLength="16" placeholder="Enter your Password" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <label for="confirm" class="cols-sm-2 control-label">Confirm New Password</label>
                    <div class="cols-sm-10">
                        <div class="input-group" id="confirmError" runat="server">
                            <span class="input-group-addon"><i class="fa fa-lock fa-lg" aria-hidden="true"></i></span>
                            <asp:TextBox CssClass="form-control" ID="confirm" runat="server" MaxLength="16" placeholder="Enter your Password" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="text-center">
                    <div id="userMsg" runat="server">
                        <%=msg %>
                    </div>
                </div>
                <div class="form-group ">
                    <asp:Button OnClick="submit_Click" CssClass="btn btn-primary btn-lg btn-block login-button" ID="submit" runat="server" Text="Register" />
                </div>
        </div>
    </div>

</asp:Content>

