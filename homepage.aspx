<%@ Page Language="C#" MasterPageFile="~/masterPage.master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="TAC.page1" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="MasterHead">
    <link id="Link1" href="page1.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="submenu"> <a href="homepage.aspx" style="margin-left:150px;" >HOME</a><a href="Login.aspx" style="margin-left: 780px;">LOGOUT</a></div>
    <div class="links" style="margin-top: 80px;margin-left:150px;">
    <br /><br /><br />
    <table align="center">
    <tr><td align="center"><a href="batch_details.aspx" 
            style="color: #FFFFFF;font-size: large; text-decoration: none; font-weight: bold;">Batch Details</a></td></tr>
            <tr><td align="center"><a href="course_details.aspx"  
            style="color: #FFFFFF; font-size: large; text-decoration: none; font-weight: bold;" >Course Details</a></td></tr>
    <tr><td align="center"><a href="student_details.aspx" 
            style="color: #FFFFFF;font-size: large; text-decoration: none; font-weight: bold;">Student Registration</a></td></tr>
            <tr><td align="center"><a href="view_reports.aspx" 
            style="color: #FFFFFF;font-size: large; text-decoration: none; font-weight: bold;">Reports</a></td></tr>
             <tr><td align="center"><a href="fee_details.aspx" 
            style="color: #FFFFFF;font-size: large; text-decoration: none; font-weight: bold;" >Student Fee Payment</a></td></tr>
    </table>
</div>
</asp:Content>