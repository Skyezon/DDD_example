<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/master.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Asssignment_PSD_2201809140.View.Account.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Change password
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView runat="server" ID="errorGrid" CssClass="alert-danger"></asp:GridView>

    <div class="form-group row">
        <label for="staticEmail" class="col-sm-2 col-form-label">Old password</label>
        <div class="col-sm-10">
            <asp:TextBox runat="server" CssClass="form-control" ID="oldPasswordInput"></asp:TextBox>
        </div>
    </div>
       
    <div class="form-group row">
        <label for="inputPassword" class="col-sm-2 col-form-label">New password</label>
        <div class="col-sm-10">
            <asp:TextBox runat="server" CssClass="form-control" ID="newPasswordInput"></asp:TextBox>
        </div>
    </div>
        
    <div class="form-group row">
        <label for="staticEmail" class="col-sm-2 col-form-label">Confirm password</label>
        <div class="col-sm-10">
            <asp:TextBox runat="server" CssClass="form-control" ID="confirmPasswordInput"></asp:TextBox>
        </div>
    </div>

    <div class="d-flex flex-column justify-content-sm-between">
        <asp:Button runat="server" ID="changePasswordButton" CssClass="btn btn-primary" Text="Change password" OnClick="changePasswordButton_Click" />
    </div>

</asp:Content>
