<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/master.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Asssignment_PSD_2201809140.View.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Profile
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>Email : <asp:Label runat="server" ID="profileEmail"></asp:Label> </p>
    <p>Name : <asp:Label runat="server" ID="profileName"></asp:Label> </p>
    <p>Gender : <asp:Label runat="server" ID="profileGender"></asp:Label> </p>
    <asp:Button runat="server" ID="updateProfileButton" CssClass="btn btn-default" OnClick="updateProfileButton_Click" Text="Update Profile"/>
    <asp:Button runat="server" ID="changePasswordButton" CssClass="btn-default" OnClick="changePasswordButton_Click" Text="Change password"/>
</asp:Content>
