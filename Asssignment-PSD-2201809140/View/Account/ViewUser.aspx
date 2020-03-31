<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/master.Master" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="Asssignment_PSD_2201809140.View.Account.ViewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    View User
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
        <asp:GridView runat="server" ID="userGrid">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" ID="toogleStatusButton" OnClick="toogleStatusButton_Click" CssClass="btn-default" Text="Toggle Status"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" ID="toogleRoleButton" Text="Toggle Role" CssClass="btn-default" OnClick="toogleRoleButton_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
                        
    

</asp:Content>
