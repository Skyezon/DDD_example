<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Asssignment_PSD_2201809140.View.WebForm1" %>

<asp:Content ID="title" ContentPlaceHolderID="title" runat="server">
    Home
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    
    <asp:GridView runat="server" ID="productList"></asp:GridView>

    <asp:Button runat="server" ID="viewUserButton" OnClick="viewUserButton_Click" Text="View User"/>
    <asp:Button runat="server" ID="insertProductButton" OnClick="insertProductButton_Click" Text="Insert Product"/>
    <asp:Button runat="server" ID="updateProductButton" OnClick="updateProductButton_Click" Text="Update Product"/>
    <asp:Button runat="server" ID="viewProductTypeButton" OnClick="viewProductTypeButton_Click" Text="View Product Type"/>
    <asp:Button runat="server" ID="insertProductTypeButton" OnClick="insertProductTypeButton_Click" Text="Insert Product Type"/>
    <asp:Button runat="server" ID="updateProductTypeButton" OnClick="updateProductTypeButton_Click" Text="Update Product Type"/>

</asp:Content>
