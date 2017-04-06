<%@ Page Language="C#" MasterPageFile="~/masterPage.Master"AutoEventWireup="true" CodeBehind="batch_details.aspx.cs" Inherits="TAC.batch_details" %>

<%@ Register Assembly="obout_EasyMenu_Pro" Namespace="OboutInc.EasyMenu_Pro" TagPrefix="oem" %>

<%@ Register Assembly="obout_Calendar2_Net" Namespace="OboutInc.Calendar2" TagPrefix="obout" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="MasterHead">
    <link id="Link1" href="bd.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<div class="submenu"> <a href="homepage.aspx" style="margin-left:150px;" >HOME</a><a href="Login.aspx" style="margin-left: 780px;">LOGOUT</a></div>
<div class="bd_body">
<table align="center">
<tr><td><asp:Label ID="batch_id" runat="server" Text="Batch ID:*"></asp:Label></td>
<td><asp:TextBox ID="batch_txt" runat="server"></asp:TextBox></td></tr>
<tr><td><asp:Label ID="course_id" runat="server" Text="Course Name:*"></asp:Label></td>
<td><asp:DropDownList ID="cid_ddl" runat="server" Width="127px" 
        DataSourceID="course_details_fill" DataTextField="cname" DataValueField="cname">
        <asp:ListItem Value="">Select</asp:ListItem>
    </asp:DropDownList>
    <asp:AccessDataSource ID="course_details_fill" runat="server" 
        DataFile="~/App_Data/TAC.accdb" 
        SelectCommand="SELECT [cname] FROM [course_details]"></asp:AccessDataSource>
    </td></tr>
<tr><td><asp:Label ID="batch_time" runat="server" Text="Batch Time:*"></asp:Label></td>
<td><asp:TextBox ID="btime" runat="server" style="width:120px;" type="time"></asp:TextBox>
</td>
</tr>
<tr><td><asp:Label ID="start_date" runat="server" Text="Start Date:*"></asp:Label></td>
<td><asp:TextBox ID="sdate" runat="server" type="date"></asp:TextBox></td></tr>
<tr><td><asp:Label ID="stat" runat="server" Text="Status:*"></asp:Label></td>
<td><asp:DropDownList ID="stat_ddl" runat="server">
<asp:ListItem>running</asp:ListItem>
<asp:ListItem>completed</asp:ListItem></asp:DropDownList>
</td></tr>
<tr><td colspan="2"><asp:Button Text="Add" runat="server" 
        style="margin-left:70px;width:70px;" onclick="bdd_add"/>
</td>
</tr>

</table>
<br /><br />
<br /><br />
 <asp:GridView align="center" ID="GridView1" runat="server" 
        AutoGenerateColumns="false" DataKeyNames="batch_id" 
        OnPageIndexChanging="GridView1_PageIndexChanging" 
        OnRowCancelingEdit="GridView1_RowCancelingEdit" 
        OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" 
        OnRowUpdating="GridView1_RowUpdating" Width="800px"
        onrowdatabound="gv_RowDataBound">
    <Columns>
        <asp:BoundField DataField="batch_id" HeaderText="Batch Id" ReadOnly="true"/>
        <asp:BoundField DataField="course_name" HeaderText="Course Name" />
        <asp:BoundField DataField="batch_time" HeaderText="Batch Time" />
        <asp:BoundField DataField="start_date" HeaderText="Start Date" />
        <asp:TemplateField HeaderText="Status">
		<EditItemTemplate>
			<asp:DropDownList ID="ddl_stat" runat="server">
			</asp:DropDownList>
		</EditItemTemplate>
		<ItemTemplate>
			<asp:Label ID="Label4" runat="server" Text='<%# Eval("status") %>'></asp:Label>
		</ItemTemplate>
	</asp:TemplateField>
        <asp:CommandField ShowEditButton="true" />
        <asp:CommandField ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
</div>
</asp:Content>