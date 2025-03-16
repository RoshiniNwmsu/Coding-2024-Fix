<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Coding2024_Fix._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h4>This is the data from your file</h4>
    <asp:GridView ID="gvAllCreatures" runat="server" AutoGenerateColumns="True" BorderStyle="Solid" BorderWidth="1px" GridLines="Both" />

    <h4>This is the creatures broken out by type</h4>

    <asp:Label ID="lblFirstType" runat="server" Font-Bold="true" /><br />
    <asp:GridView ID="gvFirstGrid" runat="server" AutoGenerateColumns="True" BorderStyle="Solid" BorderWidth="1px" GridLines="Both" />

    <br />

    <asp:Label ID="lblSecondType" runat="server" Font-Bold="true" /><br />
    <asp:GridView ID="gvSecondGrid" runat="server" AutoGenerateColumns="True" BorderStyle="Solid" BorderWidth="1px" GridLines="Both" />

</asp:Content>