using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
namespace TAC
{
    public partial class _Default : System.Web.UI.Page
    {
        OleDbConnection con;
        OleDbCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            int result = 0;
            using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=D:\.net files\project\TAC\TAC\App_data\TAC.accdb"))
            {
                cmd = new OleDbCommand();
                cmd.CommandText = "select count(*) from login where username=? and password=?";
                cmd.Parameters.AddWithValue("", unametb.Text);
                cmd.Parameters.AddWithValue("", passtb.Text);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                result = (int)cmd.ExecuteScalar();
                con.Close();
            }
            if (result > 0)
            {
                //   Response.Redirect("LoggedIn.aspx");
              //  Response.Write("<script>alert('Logged in successfully')</script>");
                Response.Redirect("homepage.aspx");
            }
            else
            {
                Response.Write("<script>alert('Invalid credentials')</script>");
            }
        }
    }
}
