<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/master.Master" AutoEventWireup="true" CodeBehind="UpdateProduct.aspx.cs" Inherits="Asssignment_PSD_2201809140.View.Product.UpdateProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Update Product
    </asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView runat="server" ID="errorGrid" CssClass="alert-danger"></asp:GridView>
   
        <div class="form-group row">
            <label for="staticEmail" class="col-sm-2 col-form-label">Product Name</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" CssClass="form-control" ID="productNameInput"></asp:TextBox>
            </div>
        </div>
       
        <div class="form-group row">
            <label for="inputPassword" class="col-sm-2 col-form-label">Product Stock</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" CssClass="form-control" ID="productStockInput"></asp:TextBox>
            </div>
        </div>
        
        <div class="form-group row">
            <label for="staticEmail" class="col-sm-2 col-form-label">Product Price</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" CssClass="form-control" ID="productPriceInput"></asp:TextBox>
            </div>
        </div>

        <div class="d-flex flex-column justify-content-sm-between">
            <asp:Button runat="server" ID="productUpdateButton" CssClass="btn btn-primary" Text="Update Product" OnClick="productUpdateButton_Click" />
        </div>
   
</asp:Content>
