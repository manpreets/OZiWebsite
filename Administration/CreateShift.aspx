<%@ Page Title="Create Shift" Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="CreateShift.aspx.cs" Inherits="Administration_CreateShift" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: left;
        }
        .style3
        {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Panel ID="PanelComplete" Visible="false" runat="server">
<h1 class="style3">Shift created.</h1><br />
</asp:Panel>
<asp:Panel ID="PanelCreate" runat="server">
    <table class="style1">
        <tr>
            <td colspan="4">
            <h1 class="style3">Create shift</h1>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label1" runat="server" Text="Shift Type"></asp:Label>
            </td>
            <td class="style2">
                <asp:DropDownList ID="DropDownListShiftType" runat="server" 
                    DataSourceID="SqlDataSource1" DataTextField="ShiftType" DataValueField="Id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:OZiNursingConnection %>" 
                    SelectCommand="SELECT * FROM [ShiftType]"></asp:SqlDataSource>
            </td>
            <td class="style2">
                <asp:Label ID="Label2" runat="server" Text="Client"></asp:Label>
            </td>
            <td class="style2">
                <asp:DropDownList ID="DropDownListClient" runat="server" 
                    DataSourceID="SqlDataSource2" DataTextField="NameAddress" DataValueField="Id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:OZiNursingConnection %>" 
                    SelectCommand="SELECT Id, Name + ' ' + Suburb AS NameAddress FROM Client">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label3" runat="server" Text="Start Date"></asp:Label>
            </td>
            <td class="style2">
                <asp:DropDownList ID="DropDownListStartDay" runat="server" Width="58px" 
               >
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownListStartMonth" runat="server" Width="71px">
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownListStartYear" runat="server" Width="64px" 
                    onselectedindexchanged="DropDownListStartYear_SelectedIndexChanged" AutoPostBack="True" 
                >
                </asp:DropDownList>
            </td>
            <td class="style2">
                <asp:Label ID="Label4" runat="server" Text="End Date"></asp:Label>
            </td>
            <td class="style2">
                <asp:DropDownList ID="DropDownListEndDay" runat="server" Width="59px" 
                 >
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownListEndMonth" runat="server" Width="68px" 
                  >
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownListEndYear" runat="server" Width="60px" 
                  >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label5" runat="server" Text="Start Time"></asp:Label>
            </td>
            <td class="style2">
                <asp:DropDownList ID="DropDownListStartHour" runat="server" Width="57px" 
                 >
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownListStartMinutes" runat="server" Width="68px" >
                </asp:DropDownList>
                </td>
            <td class="style2">
                <asp:Label ID="Label6" runat="server" Text="End Time"></asp:Label>
            </td>
            <td class="style2">
                <asp:DropDownList ID="DropDownListEndHour" runat="server" Width="59px" 
                   >
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownListEndMinutes" runat="server" Width="68px" 
                    >
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label7" runat="server" Text="Assign to Nurse"></asp:Label>
            </td>
            <td class="style2">
                <asp:DropDownList ID="DropDownListNurse" runat="server" 
                    Width="330px" DataSourceID="SqlDataSource3"  DataTextField="NurseDetail" 
                    DataValueField="Id">
                    
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:OZiNursingConnection %>" 
                    SelectCommand="SELECT Nurse.Id, Nurse.FirstName + ' ' + Nurse.LastName + ', ' + Nurse.Address + ', ' + Nurse.Suburb + ', ' + NurseType.NurseType AS NurseDetail FROM Nurse LEFT OUTER JOIN NurseType ON NurseType.Id = Nurse.NurseTypeId">
                </asp:SqlDataSource>
            </td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                <asp:Button ID="Button1" runat="server" Text="Create" onclick="Button1_Click" />
            </td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                <asp:Button ID="Button2" runat="server" Text="Cancel" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
        </tr>
    </table>
    </asp:Panel>
</asp:Content>

