<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Candidate.ascx.cs" Inherits="OZiControls_Candidate" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
    </style>

<asp:Panel ID="PanelResult" Visible="false" runat="server">
<h1>
    Congratulations your profile has been created. 
</h1>

</asp:Panel>

<asp:Panel ID="Panel1" runat="server">

<table class="style1">
    <tr>
        <td colspan="4">
            <h1>
            <asp:Label ID="Label12" runat="server" Text="Candidate Profile"></asp:Label>
            </h1>
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
            <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextFirstName" runat="server" AutoCompleteType="FirstName"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="ErrorMessage"
            ControlToValidate="TextFirstName" Text="*" 
                ErrorMessage="Please Enter First Name"></asp:RequiredFieldValidator>
        </td>
        <td>
            <asp:Label ID="Label6" runat="server" Text="Last Name"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextLastName" runat="server" AutoCompleteType="LastName"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
            CssClass="ErrorMessage" Text="*" ControlToValidate="TextLastName"
                ErrorMessage="Please enter last name"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Address"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextAddress" runat="server" 
                AutoCompleteType="HomeStreetAddress"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            CssClass="ErrorMessage" Text="*" ControlToValidate="TextAddress"
                ErrorMessage="Please enter address"></asp:RequiredFieldValidator>
        </td>
        <td>
            <asp:Label ID="Label7" runat="server" Text="Suburb"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBoxSuburb" runat="server" AutoCompleteType="HomeCity"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
            CssClass="ErrorMessage" Text="*" ControlToValidate="TextBoxSuburb"
                ErrorMessage="Please enter suburb."></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Post Code"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBoxPostCode" runat="server" AutoCompleteType="HomeZipCode" 
                MaxLength="4"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            CssClass="ErrorMessage" Text="*" ControlToValidate="TextBoxPostCode"
                ErrorMessage="Please Enter Postcode"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Text="*"  
                ControlToValidate="TextBoxPostCode" CssClass="ErrorMessage" ValidationExpression="^[1-9]{1}[0-9]{3}$"
                ErrorMessage="Please enter valid Post Code"></asp:RegularExpressionValidator>
        </td>
        <td>
            <asp:Label ID="Label11" runat="server" Text="State"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server" 
                DataSourceID="SqlDataSource1" DataTextField="StateName" DataValueField="Id">
            
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:OZiNursingConnection %>" 
                SelectCommand="SELECT * FROM [AusStates]"></asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td>
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
        <td>
            <asp:Label ID="Label8" runat="server" Text="Email"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
            CssClass="ErrorMessage" Text="*" ControlToValidate="TextEmail" 
            ErrorMessage="Please enter your email"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            CssClass="ErrorMessage" Text="*" ControlToValidate="TextEmail"
                ErrorMessage="Please enter valid email" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label4" runat="server" Text="Home Phone"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBoxHomePhone" runat="server" AutoCompleteType="HomePhone"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
            CssClass="ErrorMessage" Text="*" ControlToValidate="TextBoxHomePhone"
                ErrorMessage="Please enter homephone"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" text="*"
            ControlToValidate="TextBoxHomePhone" CssClass="ErrorMessage" 
            ValidationExpression="(^1300\d{6}$)|(^1800|1900|1902\d{6}$)|(^0[2|3|7|8]{1}[0-9]{8}$)|(^13\d{4}$)|(^04\d{2,3}\d{6}$)"
                ErrorMessage="Please enter valid phone number"></asp:RegularExpressionValidator>
        </td>
        <td>
            <asp:Label ID="Label9" runat="server" Text="Mobile"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBoxMobile" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
            CssClass="ErrorMessage" Text="*" ControlToValidate="TextBoxMobile" 
                ErrorMessage="Please enter mobile number"></asp:RequiredFieldValidator>

                 <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" text="*"
            ControlToValidate="TextBoxMobile" CssClass="ErrorMessage" 
            ValidationExpression="(^1300\d{6}$)|(^1800|1900|1902\d{6}$)|(^0[2|3|7|8]{1}[0-9]{8}$)|(^13\d{4}$)|(^04\d{2,3}\d{6}$)"
                ErrorMessage="Please enter valid phone number"></asp:RegularExpressionValidator>
                
        </td>
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
        <td>
            <asp:Button ID="Button1" runat="server" Text="Create" onclick="Button1_Click" />
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
