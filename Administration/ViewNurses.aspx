<%@ Page Title="View Nurses" Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="ViewNurses.aspx.cs" Inherits="Administration_ViewNurses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="ListViewNurse" style="max-width:800px; overflow:auto" >

<asp:GridView ID="GridViewNurses" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
        DataKeyNames="Id" DataSourceID="SqlDataSource1" ForeColor="#333333" 
        GridLines="None">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:HyperLinkField DataNavigateUrlFields="Id" 
            DataNavigateUrlFormatString="~/Administration/ViewNurseDetail.aspx?Id={0}" 
            HeaderText="Update" Text="Update" />
        <asp:BoundField DataField="Id" HeaderText="Id" 
            SortExpression="Id" ReadOnly="True" />
        <asp:BoundField DataField="UserName" HeaderText="UserName" 
            SortExpression="UserName" />
        <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
            SortExpression="FirstName" />
        <asp:BoundField DataField="LastName" HeaderText="LastName" 
            SortExpression="LastName" />
        <asp:BoundField DataField="DateofBirth" DataFormatString="{0:d}" HeaderText="DateofBirth" 
            SortExpression="DateofBirth" />
        <asp:BoundField DataField="Address" HeaderText="_______Address_______" 
            SortExpression="Address" />
        <asp:BoundField DataField="PostCode" HeaderText="PostCode" 
            SortExpression="PostCode" />
        <asp:BoundField DataField="Suburb" HeaderText="______Suburb_______" 
            SortExpression="Suburb" />
        <asp:BoundField DataField="State" HeaderText="State" 
            SortExpression="State" />
        <asp:BoundField DataField="HomePhone" HeaderText="HomePhone" 
            SortExpression="HomePhone" />
        <asp:BoundField DataField="Mobile" HeaderText="Mobile" 
            SortExpression="Mobile" />
        <asp:BoundField DataField="Email" HeaderText="Email" 
            SortExpression="Email" />
        <asp:BoundField DataField="RegistrationNumber" HeaderText="RegistrationNumber" 
            SortExpression="RegistrationNumber" />
        <asp:BoundField DataField="NurseType" HeaderText="NurseType" 
            SortExpression="NurseType" />
        <asp:BoundField DataField="DateofJoining" DataFormatString="{0:d}" HeaderText="DateofJoining" 
            SortExpression="DateofJoining" />
    </Columns>
    <EditRowStyle BackColor="#2461BF" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#012987" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#BACDCC" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F5F7FB" />
    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
    <SortedDescendingCellStyle BackColor="#E9EBEF" />
    <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OZiNursingConnection %>" 
        SelectCommand="SELECT * FROM [NurseJoinGridView]"></asp:SqlDataSource>

    

</div>
</asp:Content>

