<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Asssignment_PSD_2201809140.View.WebForm1" %>
<asp:Content ID="title" ContentPlaceHolderID="title" runat="server">
    Home
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
  <a class="navbar-brand" href="#">Hello, <asp:Label runat="server" ID="username"></asp:Label> </a>
        
    <div class="navbar-nav">
        <a class="nav-item nav-link" href="#"><asp:Button runat="server" Text="View Product" ID="viewProductButton" OnClick="viewProductButton_Click"/> </a>
        <a class="nav-item nav-link" href="#"> <asp:Button runat="server" ID="viewProfileButton" OnClick="viewProfileButton_Click" Text="View Profile"/> </a>
        <a class="nav-item nav-link" href="#"> <asp:Button runat="server" ID="logoutButton" OnClick="logoutButton_Click" Text="Log out"/> </a>
        <asp:Button runat="server" ID="loginButton" CssClass="nav-item btn btn-default" OnClick="loginButton_Click" Text="Log in"/>
    </div>
    </nav>
    
    <asp:GridView runat="server" ID="productList"></asp:GridView>

    <asp:Button runat="server" ID="viewUserButton" OnClick="viewUserButton_Click" Text="View User"/>
    <asp:Button runat="server" ID="insertProductButton" OnClick="insertProductButton_Click" Text="Insert Product"/>
    <asp:Button runat="server" ID="updateProductButton" OnClick="updateProductButton_Click" Text="Update Product"/>
    <asp:Button runat="server" ID="viewProductTypeButton" OnClick="viewProductTypeButton_Click" Text="View Product Type"/>
    <asp:Button runat="server" ID="insertProductTypeButton" OnClick="insertProductTypeButton_Click" Text="Insert Product Type"/>
    <asp:Button runat="server" ID="updateProductTypeButton" OnClick="updateProductTypeButton_Click" Text="Update Product Type"/>
</asp:Content>
