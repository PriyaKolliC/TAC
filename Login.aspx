<%@ Page Title="Login Page" Language="C#" MasterPageFile="~/masterPage.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="TAC._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="Masterhead">
    <link href="default.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <br /><br /><br /><br />
    <div class="body">
<table align="center" border="1">
<tr class="frow"><th align="center" colspan="2">Login Form</th></tr>
<tr><td colspan="2" class="srow">&nbsp</td></tr>
<tr><td colspan="2" class="trow">&nbsp</td></tr>
<tr><td style="padding-left: 15px">Username:</td>
<td><asp:TextBox ID="unametb" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td style="padding-left: 15px">Password:</td>
<td><asp:TextBox ID="passtb" runat="server" TextMode="Password"></asp:TextBox></td></tr>
<tr><td colspan="2">&nbsp</td></tr>
<tr><td align="center"><asp:Button Text="Login" ID="btn1" runat="server" 
        Width="100px" onclick="btn1_Click" /></td>
<td align="center"><asp:Button Text="Cancel" ID="btn2" runat="server" Width="100px" /></td></tr>
</table>
<p align="center">&copy Paul sir</p>
<p align="center">(ISO 9001:2008 Certified Institute)</p>
</div>
</asp:Content>
