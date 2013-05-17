<%@ Page Title="Create Nurse Profile" Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="CreateNurseProfile.aspx.cs" Inherits="Administration_CreateNurseProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Panel ID="PanelResult" Visible="false" runat="server">
    <h1>
        Congratulations new nurse profile has been created.

    </h1>
    Do you want to create another profile. <a href="CreateNurseLogin.aspx" >Click here.</a>
</asp:Panel>
<asp:Panel ID="PanelProfile" runat="server">
    <table class="style1">
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                CssClass="ErrorMessage" ControlToValidate="TextBoxFirstName"
                    ErrorMessage="Please enter first name" Text="*"></asp:RequiredFieldValidator>
            </td>
            <td class="style2">
                <asp:Label ID="Label6" runat="server" Text="Last Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                Text="*" CssClass="ErrorMessage" ControlToValidate="TextBoxLastName"
                    ErrorMessage="Please enter "></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label2" runat="server" Text="Address"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                Text="*" CssClass="ErrorMessage" ControlToValidate="TextBoxAddress"
                    ErrorMessage="Please enter address"></asp:RequiredFieldValidator>
            </td>
            <td class="style2">
                <asp:Label ID="Label7" runat="server" Text="Suburb"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxSuburb" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                Text="*" ControlToValidate="TextBoxSuburb" CssClass="ErrorMessage"
                    ErrorMessage="Please Enter Suburb name"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label3" runat="server" Text="Post Code"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxPostCode" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                Text="*" CssClass="ErrorMessage" ControlToValidate="TextBoxPostCode"
                    ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            </td>
            <td class="style2">
                <asp:Label ID="Label8" runat="server" Text="State"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownListState"  runat="server" 
                    DataSourceID="SqlDataSource1" DataTextField="StateName" DataValueField="Id">
                
                   
                </asp:DropDownList>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:OZiNursingConnection %>" 
                    SelectCommand="SELECT * FROM [AusStates]"></asp:SqlDataSource>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                Text="*" CssClass="ErrorMessage" ControlToValidate="DropDownListState"
                    ErrorMessage="Please select your state."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                Text="*" CssClass="ErrorMessage" ControlToValidate="TextBoxEmail"
                    ErrorMessage="Please enter email."></asp:RequiredFieldValidator>
            </td>
            <td class="style2">
                <asp:Label ID="Label13" runat="server" Text="Date of Birth"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownListDay" runat="server" Width="50px">
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownListMonth" runat="server" Width="60px">
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownListYear" runat="server" Width="60px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label5" runat="server" Text="Home Phone"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxHomePhone" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                Text="*" CssClass="ErrorMessage" ControlToValidate="TextBoxHomePhone"
                    ErrorMessage="Please enter homephone"></asp:RequiredFieldValidator>
            </td>
            <td class="style2">
                <asp:Label ID="Label10" runat="server" Text="Mobile"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxMobile" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                Text="*" CssClass="ErrorMessage" ControlToValidate="TextBoxMobile"
                    ErrorMessage="Please enter mobile numbber"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label11" runat="server" Text="Registration Number"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxRegistrationNumber" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                Text="*" CssClass="ErrorMessage" ControlToValidate="TextBoxRegistrationNumber"
                    ErrorMessage="Please enter registration number."></asp:RequiredFieldValidator>
            </td>
            <td class="style2">
                <asp:Label ID="Label12" runat="server" Text="Nurse Type"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownListNurseType" runat="server" 
                    DataSourceID="SqlDataSource2" DataTextField="NurseType" DataValueField="Id">
                     
                </asp:DropDownList>
                
                
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:OZiNursingConnection %>" 
                    SelectCommand="SELECT [Id], [NurseType] FROM [NurseType]">
                </asp:SqlDataSource>
                
                
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="center" >
                <asp:Button ID="Button1" runat="server" Text="Create Profile" 
                    onclick="Button1_Click" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Cancel" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" CssClass="ErrorMessage" runat="server" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </asp:Panel>
</asp:Content>

