<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/master.Master" AutoEventWireup="true" CodeBehind="ViewProductType.aspx.cs" Inherits="Asssignment_PSD_2201809140.View.ProductType.ViewProductType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    View Product Type
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:GridView runat="server" ID="viewProductGrid">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button runat="server" ID="updateProductTypeButton" OnClick="updateProductTypeButton_Click"  Text="Update Product Type"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button runat="server" ID="deleteProductTypeButton" OnClick="deleteProductTypeButton_Click" Text="Delete Product Type"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button runat="server" ID="insertProductTypeButton" Text="Insert Product Type" OnClick="insertProductTypeButton_Click"/>

</asp:Content>
