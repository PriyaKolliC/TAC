<%@ Page Language="C#"  MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="course_details.aspx.cs" Inherits="TAC.course_details" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="MasterHead">
    <link id="Link1" href="cd.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<div class="submenu"> <a href="homepage.aspx" style="margin-left:150px;" >HOME</a><a href="Login.aspx" style="margin-left: 780px;">LOGOUT</a></div>
<br /><br /><br /><br />
<div class="cd_body">
<table align="center">
<tr><td><asp:Label ID="course_idx" runat="server" Text="Course Id:*"></asp:Label></td>
<td><asp:TextBox ID="cidx" runat="server"></asp:TextBox></td>
</tr>
<tr><td><asp:Label ID="course_namex" runat="server" Text="Course Name:*"></asp:Label></td>
<td><asp:TextBox ID="cnamex" runat="server" ontextchanged="cnamex_TextChanged"></asp:TextBox></td></tr>
<tr><td><asp:Label ID="durationx" runat="server" Text="Duration:*"></asp:Label></td>
<td><asp:TextBox ID="drtnx" runat="server"></asp:TextBox>
</td></tr>
<tr><td><asp:Label ID="feesx" runat="server" Text="Fees:*"></asp:Label></td>
<td><asp:TextBox ID="fsx" runat="server"></asp:TextBox></td></tr>
<tr><td colspan="2">&nbsp</td></tr>
<tr><td colspan="2"><asp:Button ID="add" runat="server" Text="Add New Course" 
        style="margin-left:90px;" onclick="add_Click"/></td></tr>
</table>
<br /><br />
 <asp:GridView align="center" ID="GridView1" runat="server" 
        AutoGenerateColumns="false" DataKeyNames="cid" 
        OnPageIndexChanging="GridView1_PageIndexChanging" 
        OnRowCancelingEdit="GridView1_RowCancelingEdit" 
        OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" 
        OnRowUpdating="GridView1_RowUpdating" Width="800px">
    <Columns>
        <asp:BoundField DataField="cid" HeaderText="cid" ReadOnly="true"/>
        <asp:BoundField DataField="cname" HeaderText="cname" />
        <asp:BoundField DataField="duration" HeaderText="duration" />
        <asp:BoundField DataField="fees" HeaderText="fees" />
        <asp:CommandField ShowEditButton="true" />
        <asp:CommandField ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
</div>
</asp:Content>


