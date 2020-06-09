<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Asssignment_PSD_2201809140.View.WebForm1" %>

<asp:Content ID="title" ContentPlaceHolderID="title" runat="server">
    Home
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    
    <asp:GridView runat="server" ID="productList">
        <Columns>
            <asp:TemplateField HeaderText="Add to Cart Button">
                <ItemTemplate>
                    <asp:Button runat="server" ID="updateProductButton" OnClick="addToCartButton_Click" Text="Add to Cart"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Button runat="server" ID="viewUserButton" OnClick="viewUserButton_Click" Text="View User"/>
    <asp:Button runat="server" ID="insertProductButton" OnClick="insertProductButton_Click" Text="Insert Product"/>
    <asp:Button runat="server" ID="updateProductButton" OnClick="updateProductButton_Click" Text="Update Product"/>
    <asp:Button runat="server" ID="viewProductTypeButton" OnClick="viewProductTypeButton_Click" Text="View Product Type"/>
    <asp:Button runat="server" ID="insertProductTypeButton" OnClick="insertProductTypeButton_Click" Text="Insert Product Type"/>
    <asp:Button runat="server" ID="updateProductTypeButton" OnClick="updateProductTypeButton_Click" Text="Update Product Type"/>
    
    <asp:Button runat="server" ID="viewCartButton" Text="View Cart" OnClick="viewCartButton_Click"/>
    <asp:Button runat="server" ID="viewTransactionHistoryButton" Text="Transaction History" OnClick="viewTransactionHistoryButton_Click"/>
    
    <asp:Button runat="server" ID="viewPaymentTypeButton" Text="View Payment Type" OnClick="viewPaymentTypeButton_Click"/>
    <asp:Button runat="server" ID="insertPaymentTypeButton" Text="Insert Payment Type" OnClick="insertPaymentTypeButton_Click"/>
    <asp:Button runat="server" ID="updatePaymentTypeButton" Text="Update Payment Type" OnClick="updatePaymentTypeButton_Click"/>
    <asp:Button runat="server" ID="viewTransactionReportButton" Text="View Transaction Report" OnClick="viewTransactionReportButton_Click"/>


</asp:Content>
