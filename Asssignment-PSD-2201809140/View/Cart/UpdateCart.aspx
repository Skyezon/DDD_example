<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/master.Master" AutoEventWireup="true" CodeBehind="UpdateCart.aspx.cs" Inherits="Asssignment_PSD_2201809140.View.Cart.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Update Cart 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView runat="server" CssClass="alert-danger" ID="errorGrid"></asp:GridView>

        <div>
            <span>Product Name : </span>
            <asp:Label runat="server" ID="cartProductName"></asp:Label>
        </div>    
        <div>
            <span>Cart quantity : </span>
            <asp:TextBox runat="server" ID="cartProductQuantityInput"></asp:TextBox>
        </div>
    
    <asp:Button runat="server" CssClass="btn btn-success" Text="Update Cart!" ID="cartProductUpdateButton" OnClick="cartProductUpdateButton_Click"/>
</asp:Content>
