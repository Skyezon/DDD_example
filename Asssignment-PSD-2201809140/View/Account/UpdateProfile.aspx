<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/master.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="Asssignment_PSD_2201809140.View.Account.UpdateProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Update Profile
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:GridView runat="server" ID="errorGrid"></asp:GridView>

    <div class="form-group row">
        <label for="staticEmail" class="col-sm-2 col-form-label">Email</label>
        <div class="col-sm-10">
            <asp:TextBox runat="server" CssClass="form-control" ID="emailInput"></asp:TextBox>
        </div>
    </div>
       
    <div class="form-group row">
        <label for="inputPassword" class="col-sm-2 col-form-label">Name</label>
        <div class="col-sm-10">
            <asp:TextBox runat="server" CssClass="form-control" ID="nameInput"></asp:TextBox>
        </div>
    </div>
        
    <div class="form-group row">
        <label for="staticEmail" class="col-sm-2 col-form-label">Gender</label>
        <div class="col-sm-10">
            <asp:RadioButtonList ID="genderInput" runat="server" Width="198px">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div>

    <div class="d-flex flex-column justify-content-sm-between">
        <asp:Button runat="server" ID="profileUpdateButton" CssClass="btn btn-primary" Text="Update Profile" OnClick="profileUpdateButton_Click" />
    </div>
</asp:Content>
