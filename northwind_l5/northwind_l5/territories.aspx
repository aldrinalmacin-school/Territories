<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="territories.aspx.cs" Inherits="northwind_l5.territories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Territories</h2>

    <a href="Territory.aspx"> Add Territory</a>

    <asp:gridview id="gvTerritories" runat="server" autogeneratecolumns="false"
        OnRowDeleting="gvTerritories_RowDeleting" DataKeyNames="TerritoryID" 
            onrowdatabound="gvTerritories_RowDataBound">
        <columns>
            <asp:boundfield headertext="Territory ID" datafield="TerritoryID" />
            <asp:boundfield headertext="Region Description" datafield="RegionDescription" />
            <asp:hyperlinkfield headertext="Edit" text="Edit" navigateurl="territory.aspx"
                 datanavigateurlfields="TerritoryID"
                 datanavigateurlformatstring="territory.aspx?TerritoryID={0}" />
            <asp:CommandField headertext="Delete" DeleteText="Delete" ShowDeleteButton="true" />
        </columns>
    </asp:gridview>

</asp:Content>
