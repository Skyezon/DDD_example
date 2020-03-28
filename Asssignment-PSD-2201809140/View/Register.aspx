<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/master.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Asssignment_PSD_2201809140.View.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Register
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:GridView runat="server" ID="listOfError" CssClass="alert-danger"></asp:GridView>

    <form>
        <div class="form-group row">
            <label for="staticEmail" class="col-sm-2 col-form-label">Email</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" TextMode="Email" CssClass="form-control" ID="emailRegis" MaxLength="50"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label for="staticEmail" class="col-sm-2 col-form-label">Name</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" CssClass="form-control" ID="nameRegis" MaxLength="50"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label for="inputPassword" class="col-sm-2 col-form-label">Password</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="passwordRegis"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label for="inputPassword" class="col-sm-2 col-form-label">Confirm Password</label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="confirmPasswordRegis"></asp:TextBox>
            </div>
        </div>
        
        <div class="form-group row">
            <label for="inputPassword" class="col-sm-2 col-form-label">Gender</label>
            <asp:RadioButtonList ID="genderRegis" runat="server" Width="198px">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="d-flex flex-column justify-content-sm-between">
            <asp:Button runat="server" ID="regisButton" CssClass="btn btn-primary" Text="Submit" OnClick="regisButton_Click" />
        </div>
        
    </form>
</asp:Content>
