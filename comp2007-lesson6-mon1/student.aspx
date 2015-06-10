<%@ Page Title="Student Details" Language="C#" MasterPageFile="~/monday.Master" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="comp2007_lesson6_mon1.student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Student Details</h1>
    <h5>All fields are required</h5>

    <div class="form-group">
        <label for="txtFName" class="col-sm-3">First Name:</label>
        <asp:TextBox ID="txtFName" runat="server" required="true" MaxLength="25"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtLName" class="col-sm-3">Last Name:</label>
        <asp:TextBox ID="txtLName" runat="server" required="true" MaxLength="25" />
    </div>
    <asp:Button ID="btnSaveStu" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSaveStu_Click" />
</asp:Content>
