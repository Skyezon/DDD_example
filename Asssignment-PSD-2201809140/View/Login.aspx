<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Asssignment_PSD_2201809140.View.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Login
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" ID="errorMessage" Text="Inccorect Email or password Combination" CssClass="alert-danger"></asp:Label>
    <form>
        <div class="form-group row">
            <label for="staticEmail" class="col-sm-2 col-form-label">Email</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" TextMode="Email" CssClass="form-control" ID="emailLogin"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label for="inputPassword" class="col-sm-2 col-form-label">Password</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="passwordLogin"></asp:TextBox>
            </div>
        </div>
        <div class="d-flex flex-column justify-content-sm-between">
            <asp:CheckBox runat="server" ID="rememberMeCheckBox" Text="Remember me"/>
            <asp:Button runat="server" ID="loginButton" CssClass="btn btn-primary" Text="Login" OnClick="loginButton_Click"/>
        </div>
        
    </form>
</asp:Content>
