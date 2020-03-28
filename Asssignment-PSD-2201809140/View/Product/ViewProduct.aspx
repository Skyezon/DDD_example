<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/master.Master" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="Asssignment_PSD_2201809140.View.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView runat="server" ID="productList">
        

    </asp:GridView>
    <asp:Button runat="server" ID="insertProductButton" OnClick="insertProductButton_Click" Text="Insert Product"/>
</asp:Content>
