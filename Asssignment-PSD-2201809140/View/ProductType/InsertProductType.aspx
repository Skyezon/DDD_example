<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/master.Master" AutoEventWireup="true" CodeBehind="InsertProductType.aspx.cs" Inherits="Asssignment_PSD_2201809140.View.ProductType.InsertProductType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Insert Product Type
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView runat="server" CssClass="alert-danger" ID="errorGrid"></asp:GridView>
    <div class="form-group row">    
        <label for="staticEmail" class="col-sm-2 col-form-label">Product Type Name</label>
        <div class="col-sm-10">
            <asp:TextBox runat="server" CssClass="form-control" ID="productTypeName"></asp:TextBox>
        </div>
    </div>
       
    <div class="form-group row">
        <label for="inputPassword" class="col-sm-2 col-form-label">Product Type Description</label>
        <div class="col-sm-10">
            <asp:TextBox runat="server" CssClass="form-control" ID="productTypeDescription"></asp:TextBox>
        </div>
    </div>


    <div class="d-flex flex-column justify-content-sm-between">
        <asp:Button runat="server" ID="productInsertButton" CssClass="btn btn-primary" Text="Insert Product" OnClick="productInsertButton_Click" />
    </div>
</asp:Content>
