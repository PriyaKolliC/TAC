<%@ Page Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="fee_details.aspx.cs" Inherits="TAC.fee_details" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="MasterHead">
    <link id="Link1" href="page1.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<div class="submenu"> <a href="homepage.aspx" style="margin-left:150px;" >HOME</a><a href="Login.aspx" style="margin-left: 780px;">LOGOUT</a></div>
<div id="popup" runat="server">
<table align="center" width="200px">
<tr><td><asp:Label ID="psname" runat="server" Text="Student Name:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><asp:TextBox ID="psname_txt" runat="server" 
        Width="156px" Height="24px"></asp:TextBox></td></tr>
<tr><td><asp:Label ID="pdob" runat="server" Text="Date Of Birth:*" Width="180px"></asp:Label></td>
<td style="padding-left: 20px"><asp:TextBox ID="pdob_txt" runat="server" 
        Width="159px" type="date" Height="25px"></asp:TextBox></td></tr></table>
</div>
<div id="popup_btns" runat="server">
<table align="center" width="200px">
<tr><td>
    <asp:Button ID="pbtn" runat="server" Text="Proceed" 
        OnClick="fee_dtls" Width="100px" style="margin-left: 0px"/></td><td>
        <asp:Button ID="pbtn2" runat="server" Text="Cancel" 
        OnClick="Cancel_btn" Width="100px" style="margin-left: 110px" Height="23px"/></td></tr></table>
        </div>
<div class="fd_body" id="normal" runat="server">
<table align="center">
<tr><td colspan="2"><asp:Label ID="cname" runat="server" Text="Select Course: *"></asp:Label></td>
<td colspan="2"><asp:DropDownList ID="crse_name_ddl" runat="server" Height="16px" 
        style="margin-left: 36px" Width="156px" AutoPostBack="true" EnableViewState="true"
        onselectedindexchanged="crse_name_ddl_SelectedIndexChanged" ></asp:DropDownList>
    </td></tr>
<tr><td>
    <asp:Label ID="fees_paid" runat="server" Text="Fee Paid: " Width="73px" 
        Height="16px" style="margin-left: 0px"></asp:Label></td>
<td style="padding-left:10px;">
    <asp:Label ID="fees_paid_amount" runat="server" 
        Text="0" Width="82px" Height="22px"></asp:Label></td>
<td><asp:Label ID="rem_fees" runat="server" Text="Remaining Fee: " Width="98px" 
        Height="16px"></asp:Label></td>
<td style="padding-left:10px;">
    <asp:Label ID="rem_fees_amount" runat="server" 
        Text="0" Width="96px" Height="20px"></asp:Label></td>
</tr>
<tr>
<td colspan="2">
    <asp:Label ID="fee_entry" runat="server" Text="Enter Fees: *" 
        Width="90px" style="margin-left: 1px"></asp:Label></td><td colspan="2" style="padding-left:10px;">
        <asp:TextBox ID="fee_entry_txt" runat="server" Width="154px" Height="22px" 
            style="margin-left: 15px"></asp:TextBox>
</td>
</tr>
<tr>
<td colspan="2">
    <asp:Label ID="dop_lbl" runat="server" Text="Date of Payment: *" 
        Width="90px" style="margin-left: 1px"></asp:Label></td><td colspan="2" style="padding-left:10px;">
        <asp:TextBox ID="dop_txt" runat="server" Width="154px" Height="22px" 
            style="margin-left: 15px" type="date"></asp:TextBox>
</td>
</tr>
<tr>
<td colspan="2">
    <asp:Button ID="save" runat="server" Text="Save" 
        Style="margin-left:28px;" onclick="save_click" Height="22px" Width="90px" ></asp:Button></td>
<td colspan="2">
    <asp:Button ID="canc" runat="server" Text="Cancel" 
        Style="margin-left:75px;" onclick="cancel_click" Height="22px" 
        Width="90px" ></asp:Button></td>
</tr>
</table>
<asp:DropDownList ID="temp_ddl" runat="server" Height="16px" 
        style="margin-left: 36px" Width="156px" AppendDataBoundItems="true" 
        AutoPostBack="true" 
        onselectedindexchanged="crse_name_ddl_SelectedIndexChanged" ></asp:DropDownList>
</div>
</asp:Content>