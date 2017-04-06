<%@ Page Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="view_reports.aspx.cs" Inherits="TAC.view_student_details" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="MasterHead">
    <link id="Link1" href="" rel="stylesheet" type="text/css" media="screen" runat="server" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<div class="submenu"> <a href="homepage.aspx" style="margin-left:150px;" >HOME</a><a href="Login.aspx" style="margin-left: 780px;">LOGOUT</a></div>
<div class="opt_menu">
<asp:Label ID="optns" runat="server" Text="Select Criteria from dropdown below" style="margin-left:150px;"></asp:Label>
<asp:Label ID="cmmn_lbl" runat="server" Text="Enter data below" style="margin-left:190px;"></asp:Label>
<br /><br />
<asp:DropDownList ID="ddl" runat="server" AppendDataBoundItems="true" 
        style="margin-left:150px;" Height="16px" Width="159px" OnSelectedIndexChanged="indx_change" AutoPostBack="true">
        <asp:ListItem>--Select</asp:ListItem>
        <asp:ListItem>Batch Id</asp:ListItem>
        <asp:ListItem>Course</asp:ListItem>
        <asp:ListItem>Weekly Report</asp:ListItem>
        <asp:ListItem>Monthly Report</asp:ListItem>
        <asp:ListItem>Yearly Report</asp:ListItem></asp:DropDownList>
        <asp:TextBox ID="cmmn_txt" runat="server" style="margin-left:256px;"></asp:TextBox>
<br />
<br />
    <asp:Button ID="Button1" runat="server" style="margin-left: 150px" 
        Text="Report" Height="23px" Width="101px" OnClick="bttn_clk" />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="401px" 
        style="margin-left: 147px; margin-right: 0px; margin-top: 104px" Width="846px">
    </rsweb:ReportViewer>
<br />
</div>
<div class="report_body" align="center">
    <br />
</div>
</asp:Content>