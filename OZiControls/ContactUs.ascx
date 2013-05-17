<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactUs.ascx.cs" Inherits="OZiControls_ContactUs" %>
<style type="text/css">
    .style2
    {
        text-align: center;
    }
</style>
<script type="text/javascript">
    function ValidatePhoneNumbers(source, args) 
    {

        var homePhone = document.getElementById('<%=textHomePhone.ClientID %>');
        var businessPhone = document.getElementById('<%=textBusinessPhone.ClientID %>');

        if (homePhone.value != "" || businessPhone.value != "")
         {

            args.IsValid = true;
        }
        else {
            args.IsValid = false;
        }
    }
</script>

<table ="style1">
    <tr>
        <td colspan="3" class="style2">
            <h1 class="style2">
                Contact Us</h1>
        </td>
    </tr>
    <tr>
        <td colspan="3" class="style2">
            Use this form to send queries, feedback or complaints.</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="textName" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="ErrorMessage"
                ErrorMessage="Please enter name." Text="*" ControlToValidate="textName" ></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="textEmail" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="*" ControlToValidate="textEmail"
                ErrorMessage="Please enter email." CssClass="ErrorMessage"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ErrorMessage="Please enter valid email." CssClass="ErrorMessage" ControlToValidate="textEmail"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Re-enter email"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="textReEmail" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="*" ControlToValidate="textReEmail"
                ErrorMessage="Please re-enter email." CssClass="ErrorMessage"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="textEmail" ControlToValidate="textReEmail" Operator="Equal" CssClass="ErrorMessage"
                ErrorMessage="Please enter same email as above."></asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label4" runat="server" Text="Home Phone"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="textHomePhone"  runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:CustomValidator ID="CustomValidator1" runat="server" 
                CssClass="ErrorMessage" Display="Dynamic" Text="*"
                ErrorMessage="Please enter home number or business number" 
                ClientValidationFunction="ValidatePhoneNumbers" 
                onservervalidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label5" runat="server" Text="Business Phone"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="textBusinessPhone" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label6" runat="server" Text="Message"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="textMessage" TextMode="MultiLine"  runat="server" 
                Height="70px" Width="294px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Text="*" ControlToValidate="textMessage"
                ErrorMessage="Please enter message." CssClass="ErrorMessage"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
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
            <asp:Button ID="Button1" runat="server" Text="Send" Width="73px" 
                onclick="Button1_Click" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:ValidationSummary ID="ValidationSummary1" CssClass="ErrorMessage" ShowMessageBox="true" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>

