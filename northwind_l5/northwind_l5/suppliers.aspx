<%@ Page Title="Northwind Suppliers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="suppliers.aspx.cs" Inherits="northwind_l5.suppliers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Suppliers</h2>

<a href="supplier.aspx"> Add Supplier</a>

<asp:gridview id="gvSuppliers" runat="server" autogeneratecolumns="false"
    OnRowDeleting="gvSuppliers_RowDeleting" DataKeyNames="SupplierID" 
        onrowdatabound="gvSuppliers_RowDataBound">
    <columns>
        <asp:boundfield headertext="Supplier ID" datafield="SupplierID" />
        <asp:hyperlinkfield headertext="Edit" text="Edit" navigateurl="supplier.aspx"
             datanavigateurlfields="SupplierID"
             datanavigateurlformatstring="supplier.aspx?SupplierID={0}" />
        <asp:CommandField headertext="Delete" DeleteText="Delete" ShowDeleteButton="true" />
    </columns>
</asp:gridview>


</asp:Content>
