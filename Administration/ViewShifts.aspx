<%@ Page Title="View Shifts Grid" Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="ViewShifts.aspx.cs" Inherits="Administration_ViewShifts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="ViewShiftsGrid" style="overflow:auto">
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
        DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
        AutoGenerateColumns="False" DataKeyNames="Id">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" 
                SortExpression="Id" />
            <asp:BoundField DataField="ShiftType" HeaderText="Shift Type" 
                SortExpression="ShiftType" />
            <asp:BoundField DataField="ClientName" HeaderText="Client Name" 
                SortExpression="ClientName" />
            <asp:BoundField DataField="ClientAddress" HeaderText="Client Address" 
                SortExpression="ClientAddress" />
            <asp:BoundField DataField="ClientSuburb" HeaderText="Client Suburb" 
                SortExpression="ClientSuburb" />
            <asp:BoundField DataField="StartDateTime" HeaderText="Start DateTime" 
                SortExpression="StartDateTime" />
            <asp:BoundField DataField="EndDateTime" HeaderText="End DateTime" 
                SortExpression="EndDateTime" />
            <asp:CheckBoxField DataField="IsAssigned" HeaderText="IsAssigned" 
                SortExpression="IsAssigned" />
            <asp:BoundField DataField="NurseName" HeaderText="Nurse Name" ReadOnly="True" 
                SortExpression="NurseName" />
            <asp:BoundField DataField="NurseAddress" HeaderText="Nurse Address" 
                ReadOnly="True" SortExpression="NurseAddress" />
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
        SelectCommand="SELECT * FROM [ShiftNurseClientVIEW]"></asp:SqlDataSource>
</div>
</asp:Content>

