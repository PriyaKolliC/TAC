<%@ Page Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="Student_course_details.aspx.cs" Inherits="TAC.Student_course_Details" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="MasterHead">
    <link id="Link1" href="cd.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<br /><br />
<table align="center">
<tr>
<td><asp:Label ID="ssname" runat="server" Text="Student Name:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><asp:TextBox ID="ssname_txt" runat="server" Width="180px" ReadOnly="true"></asp:TextBox></td>
</tr>
<tr>
<td><asp:Label ID="ddob" runat="server" Text="Date Of Birth:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><asp:TextBox ID="ddob_txt" runat="server" Width="180px" type="date" ReadOnly="true"></asp:TextBox></td>
</tr>
<tr>
<td><asp:Label ID="dd_course" runat="server" Text="Course Name:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px">
    <asp:DropDownList ID="dd_course_ddl" runat="server" AutoPostBack="true"
        Width="180px" onselectedindexchanged="dd_course_ddl_SelectedIndexChanged" 
        DataSourceID="AccessDataSource1" DataTextField="cname" DataValueField="cname" AppendDataBoundItems="true">
        </asp:DropDownList>
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
        DataFile="~/App_Data/TAC.accdb" 
        SelectCommand="SELECT [cname] FROM [course_details]"></asp:AccessDataSource>
    </td>
</tr>

<tr>
<td><asp:Label ID="bbid" runat="server" Text="Batch ID:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px">
   <asp:DropDownList ID="bbid_ddl" runat="server" Width="180px"></asp:DropDownList>
    </td>
</tr>
<tr>
<td><asp:Label ID="dis" runat="server" Text="Discount:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><asp:TextBox ID="dis_txt" runat="server" Width="180px"></asp:TextBox></td>
</tr>
<tr>
<td><asp:Label ID="doj" runat="server" Text="Date Of Joining:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><asp:TextBox ID="doj_txt" runat="server" type="date" width="180px"></asp:TextBox>
</td>
</tr>
<tr><td colspan="2">&nbsp;</td></tr>
<tr>
<td><asp:Button ID="submit" runat="server" 
        Text="Submit" onclick="submit_Click" style="margin-left: 86px" 
        Width="75px"> </asp:Button></td>
        <td><asp:Button ID="cancel" runat="server"  
        Text="Cancel" onclick="cancel_Click" style="margin-left: 81px" Width="73px"> </asp:Button>
</td>
</tr>
</table>
</asp:Content>
