<%@ Page Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="student_details.aspx.cs" Inherits="TAC.student_details" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="MasterHead">
    <link id="Link1" href="sd.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<div class="submenu"> <a href="homepage.aspx" style="margin-left:150px;" >HOME</a><a href="Login.aspx" style="margin-left: 780px;">LOGOUT</a></div>
<br /><div><asp:Label ID="euser" runat="server" Text="Existing Student??:    " style="margin-left:800px;"></asp:Label><asp:LinkButton ID="poplink" runat="server" onclick="magic" Text="ClickHere!"></asp:LinkButton></div>
<br /><br />
<div id="popup" runat="server">
<table align="center" width="200px">
<tr><td><asp:Label ID="psname" runat="server" Text="Student Name:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><asp:TextBox ID="psname_txt" runat="server" Width="220px"></asp:TextBox></td></tr>
<tr><td><asp:Label ID="pdob" runat="server" Text="Date Of Birth:*" Width="180px"></asp:Label></td>
<td style="padding-left: 20px"><asp:TextBox ID="pdob_txt" runat="server" Width="220px" type="date"></asp:TextBox></td></tr>
<tr><td>
    <asp:Button ID="pbtn" runat="server" Text="New Entry" 
        OnClick="check_details" Width="100px" style="margin-left: 62px"/></td><td>
        <asp:Button ID="pbtn2" runat="server" Text="Update Details" 
        OnClick="update_details" Width="100px" style="margin-left: 61px"/></td></tr></table>
</div>
<div class="sd_body" id="normal" runat="server">
<table align="center" width="350p">
<tr>
<td><asp:Label ID="sname" runat="server" Text="Student Name:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><asp:TextBox ID="sname_txt" runat="server" Width="220px"></asp:TextBox></td>
</tr>
<tr>
<td><asp:Label ID="fname" runat="server" Text="Father Name:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><asp:TextBox ID="fname_txt" runat="server" Width="220px"></asp:TextBox></td>
</tr>
<tr>
<td><asp:Label ID="mname" runat="server" Text="Mother Name:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><asp:TextBox ID="mname_txt" runat="server" Width="220px"></asp:TextBox></td>
</tr>
<tr>
<td><asp:Label ID="mob" runat="server" Text="Mobile Number(s):*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><asp:TextBox ID="mob_txt" runat="server" Width="220px"></asp:TextBox>
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
      ControlToValidate="mob_txt" ErrorMessage="Enter 10 digit mobile number" 
    ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator></td>
</tr>
<tr>
<td><asp:Label ID="dob" runat="server" Text="Date Of Birth:*" Width="180px"></asp:Label></td>
<td style="padding-left: 20px"><asp:TextBox ID="dob_txt" runat="server" Width="220px" type="date"></asp:TextBox></td></tr>
<tr>
<td><asp:Label ID="email" runat="server" Text="Email Id:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><asp:TextBox ID="email_txt" runat="server" Width="220px"></asp:TextBox>
<asp:RegularExpressionValidator ID="RegularExpressionValidator2"
              runat="server" ErrorMessage="Please Enter Valid Email ID"
                  ValidationGroup="vgSubmit" ControlToValidate="email_txt"
                  CssClass="requiredFieldValidateStyle"
                  ForeColor="Red"
                  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                  </asp:RegularExpressionValidator></td>
</tr>
<tr>
<td><asp:Label ID="cad" runat="server" Text="College Address:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><center><asp:TextBox ID="cad_txt" runat="server" Height="60px" Width="220px"></asp:TextBox></center>
</td>
</tr>
<tr>
<td><asp:Label ID="Pad" runat="server" Text="Permanent Address:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><asp:TextBox ID="pad_txt" runat="server" Height="60px" Width="220px"></asp:TextBox></td>
</tr>
<tr>
<td><asp:Label ID="coname" runat="server" Text="College Name:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><asp:DropDownList ID="colname_ddl" runat="server" 
        Width="223px" DataSourceID="StudentInformation1" DataTextField="clg_name" 
        DataValueField="clg_name"></asp:DropDownList>
    <asp:AccessDataSource ID="StudentInformation1" runat="server" 
        DataFile="~/App_Data/TAC.accdb" 
        SelectCommand="SELECT [clg_name] FROM [college_details]">
    </asp:AccessDataSource>
    </td>
</tr>
<tr>
<td><asp:Label ID="bname" runat="server" Text="Branch Name:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><asp:DropDownList ID="bname_ddl" runat="server" T="Select Branch"
        Width="223px" DataSourceID="studentInformation" DataTextField="bname" 
        DataValueField="bname"></asp:DropDownList>
    <asp:AccessDataSource ID="studentInformation" runat="server" 
        DataFile="~/App_Data/TAC.accdb" 
        SelectCommand="SELECT [bname] FROM [branch_details]"></asp:AccessDataSource>
    </td>
</tr>
<tr>
<td><asp:Label ID="sem" runat="server" Text="Semester:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><asp:DropDownList ID="sem_ddl" runat="server" Width="223px">
<asp:ListItem Value="I">I</asp:ListItem>
<asp:ListItem Value="II">II</asp:ListItem>
<asp:ListItem Value="III">III</asp:ListItem>
<asp:ListItem Value="IV">IV</asp:ListItem>
<asp:ListItem Value="V">V</asp:ListItem>
<asp:ListItem Value="VI">VI</asp:ListItem>
<asp:ListItem Value="VII">VII</asp:ListItem>
<asp:ListItem Value="VIII">VIII</asp:ListItem>
</asp:DropDownList></td>
</tr>
<tr>
<td><asp:Label ID="stat" runat="server" Text="Status:*" Width="180px"></asp:Label></td>
<td style="padding-left: 20px"><asp:DropDownList ID="stat_ddl" runat="server" Width="223px">
<asp:ListItem Value="completed">Completed</asp:ListItem>
<asp:ListItem Value="running">Running</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td colspan="2">
    <asp:Button ID="register" runat="server" Text="Register" 
        Style="margin-left:165px;" onclick="register_Click" ></asp:Button></td>
</tr>
</table>
</div>





<div class="update_sd_body" id="update_sd_id" runat="server">
<table align="center" width="350p">
<tr>
<td><asp:Label ID="up_sname" runat="server" Text="Student Name:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><asp:TextBox ID="up_sname_txt" runat="server" Width="220px"></asp:TextBox></td>
</tr>
<tr>
<td><asp:Label ID="up_fname" runat="server" Text="Father Name:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><asp:TextBox ID="up_fname_txt" runat="server" Width="220px"></asp:TextBox></td>
</tr>
<tr>
<td><asp:Label ID="up_mname" runat="server" Text="Mother Name:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><asp:TextBox ID="up_mname_txt" runat="server" Width="220px"></asp:TextBox></td>
</tr>
<tr>
<td><asp:Label ID="up_mob" runat="server" Text="Mobile Number(s):*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><asp:TextBox ID="up_mob_txt" runat="server" Width="220px"></asp:TextBox>
<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
      ControlToValidate="mob_txt" ErrorMessage="Enter 10 digit mobile number" 
    ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator></td>
</tr>
<tr>
<td><asp:Label ID="up_dob" runat="server" Text="Date Of Birth:*" Width="180px"></asp:Label></td>
<td style="padding-left: 20px"><asp:TextBox ID="up_dob_txt" runat="server" Width="220px" type="date"></asp:TextBox></td></tr>
<tr>
<td><asp:Label ID="up_email" runat="server" Text="Email Id:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><asp:TextBox ID="up_email_txt" runat="server" Width="220px"></asp:TextBox>
<asp:RegularExpressionValidator ID="RegularExpressionValidator4"
              runat="server" ErrorMessage="Please Enter Valid Email ID"
                  ValidationGroup="vgSubmit" ControlToValidate="email_txt"
                  CssClass="requiredFieldValidateStyle"
                  ForeColor="Red"
                  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                  </asp:RegularExpressionValidator></td>
</tr>
<tr>
<td><asp:Label ID="up_cad" runat="server" Text="College Address:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><center><asp:TextBox ID="up_cad_txt" runat="server" Height="60px" Width="220px"></asp:TextBox></center>
</td>
</tr>
<tr>
<td><asp:Label ID="up_pad" runat="server" Text="Permanent Address:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><asp:TextBox ID="up_pad_txt" runat="server" Height="60px" Width="220px"></asp:TextBox></td>
</tr>
<tr>
<td><asp:Label ID="up_cname" runat="server" Text="College Name:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><asp:DropDownList ID="up_cname_ddl" runat="server" 
        Width="223px" DataSourceID="StudentInformation1" DataTextField="clg_name" 
        DataValueField="clg_name"></asp:DropDownList>
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
        DataFile="~/App_Data/TAC.accdb" 
        SelectCommand="SELECT [clg_name] FROM [college_details]">
    </asp:AccessDataSource>
    </td>
</tr>
<tr>
<td><asp:Label ID="up_bname" runat="server" Text="Branch Name:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><asp:DropDownList ID="up_bname_ddl" runat="server" T="Select Branch"
        Width="223px" DataSourceID="studentInformation" DataTextField="bname" 
        DataValueField="bname"></asp:DropDownList>
    <asp:AccessDataSource ID="AccessDataSource2" runat="server" 
        DataFile="~/App_Data/TAC.accdb" 
        SelectCommand="SELECT [bname] FROM [branch_details]"></asp:AccessDataSource>
    </td>
</tr>
<tr>
<td><asp:Label ID="up_sem" runat="server" Text="Semester:*" Width="180px"> </asp:Label></td>
<td style="padding-left: 20px"><asp:DropDownList ID="up_sem_ddl" runat="server" Width="223px">
<asp:ListItem Value="I">I</asp:ListItem>
<asp:ListItem Value="II">II</asp:ListItem>
<asp:ListItem Value="III">III</asp:ListItem>
<asp:ListItem Value="IV">IV</asp:ListItem>
<asp:ListItem Value="V">V</asp:ListItem>
<asp:ListItem Value="VI">VI</asp:ListItem>
<asp:ListItem Value="VII">VII</asp:ListItem>
<asp:ListItem Value="VIII">VIII</asp:ListItem>
</asp:DropDownList></td>
</tr>
<tr>
<td><asp:Label ID="up_stat" runat="server" Text="Status:*" Width="180px"></asp:Label></td>
<td style="padding-left: 20px"><asp:DropDownList ID="up_stat_ddl" runat="server" Width="223px">
<asp:ListItem Value="completed">Completed</asp:ListItem>
<asp:ListItem Value="running">Running</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td>
    <asp:Button ID="up_savec" runat="server" Text="Save Changes" 
        Style="margin-left:165px;" onclick="save_details" ></asp:Button></td>
        <td><asp:Button ID="up_cancl" runat="server" Text="Cancel" 
        Style="margin-left:165px;" onclick="Cancel_up" ></asp:Button></td>
</tr>
</table>
</div>
</asp:Content>

