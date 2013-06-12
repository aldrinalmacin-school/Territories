<%@ Page Title="Supplier Information" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="supplier.aspx.cs" Inherits="northwind_l5.supplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Supplier Information</h2>

<div>
    <label for="txtCompanyName">Company Name *</label>
    <asp:textbox id="txtCompanyName" runat="server"></asp:textbox>
    <asp:requiredfieldvalidator id="val1" runat="server" errormessage="Required"
     controltovalidate="txtCompanyName"></asp:requiredfieldvalidator>
</div>

<asp:button id="btnSave" runat="server" text="Save" onclick="btnSave_Click" />

</asp:Content>
