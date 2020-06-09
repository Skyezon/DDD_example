<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/master.Master" AutoEventWireup="true" CodeBehind="InsertCart.aspx.cs" Inherits="Asssignment_PSD_2201809140.View.Cart.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Add to Cart
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView runat="server" CssClass="alert-danger" ID="errorGrid"></asp:GridView>

    <div>
        <span>Name : </span>
        <asp:Label runat="server" ID="cartProductName"></asp:Label>
    </div>
    <div>
        <span>Price : </span>
        <asp:Label runat="server" ID="cartProductPrice"></asp:Label>
    </div>
    <div>
        <span>Stock : </span>
        <asp:Label runat="server" ID="cartProductStock"></asp:Label>
    </div>
    <div>
        <span>Product type : </span>
        <asp:Label runat="server" ID="cartProductType"></asp:Label>
    </div>
    <div>
        <span>Quantity : </span>
        <asp:TextBox runat="server" ID="cartProductQuantityInput"></asp:TextBox>
    </div>
    
    <div class="d-flex flex-column justify-content-sm-between">
    <asp:Button runat="server" ID="cartInsertButton" CssClass="btn btn-primary" Text="Insert Product" OnClick="cartInsertButton_Click"/>
    </div>
</asp:Content>
