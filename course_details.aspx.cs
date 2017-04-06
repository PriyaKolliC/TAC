using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Web.UI.WebControls.WebParts;

namespace TAC
{
    public partial class course_details : System.Web.UI.Page
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\.net files\project\TAC\TAC\App_Data\TAC.accdb");
        OleDbCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvbind();
        
            }
            
        }
        protected void gvbind()
        {
            using (OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\.net files\project\TAC\TAC\App_Data\TAC.accdb"))
            {
                OleDbCommand cmd = new OleDbCommand("select * from course_details order by cid", con);
                OleDbDataAdapter olda = new OleDbDataAdapter(cmd);
                con.Open();
                DataSet ds = new DataSet();
                olda.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    int columncount = GridView1.Rows[0].Cells.Count;
                    GridView1.Rows[0].Cells.Clear();
                    GridView1.Rows[0].Cells.Add(new TableCell());
                    GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                    GridView1.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gvbind();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label lbldeleteid = (Label)row.FindControl("lblID");
            using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=D:\.net files\project\TAC\TAC\App_data\TAC.accdb"))
            {
                cmd = new OleDbCommand();
                cmd.CommandText = "delete from course_details where cid=?";
                cmd.Parameters.AddWithValue("", GridView1.DataKeys[e.RowIndex].Value.ToString());
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                gvbind();
            }
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            TextBox textName = (TextBox)row.Cells[1].Controls[0];
            TextBox textadd = (TextBox)row.Cells[2].Controls[0];
            TextBox textc = (TextBox)row.Cells[3].Controls[0];
            GridView1.EditIndex = -1;
            using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=D:\.net files\project\TAC\TAC\App_data\TAC.accdb"))
            {
                con.Open();
                cmd = new OleDbCommand("update course_details set cname='" + textName.Text + "',duration='" + Convert.ToInt32(textadd.Text) + "',fees='" + Convert.ToInt32(textc.Text) + "'where cid='" + GridView1.Rows[e.RowIndex].Cells[0].Text + "'");
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
                gvbind();
            }
        }
protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
{
    GridView1.EditIndex = -1;
}
protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
{
    GridView1.PageIndex = e.NewPageIndex;
    gvbind();
}
        protected void OnCancel(object sender, EventArgs e)
        {
        }
        protected void add_Click(object sender, EventArgs e)
        {
            int result = 0;
            if (cidx.Text == "" || cnamex.Text == "" || drtnx.Text == "" || fsx.Text == "")
            {
                Response.Write("<script>alert('Marked fields are mandatory')</script>");
            }
            else
            {
                using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=D:\.net files\project\TAC\TAC\App_data\TAC.accdb"))
                {
                    cmd = new OleDbCommand();
                    cmd.CommandText = "select count(*) from course_details where cid=? or cname=?";
                    cmd.Parameters.AddWithValue("", cidx.Text);
                    cmd.Parameters.AddWithValue("", cnamex.Text);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    result = (int)cmd.ExecuteScalar();
                    con.Close();
                }
                if (result > 0)
                {
                    Response.Write("<script>alert('Course Id already exists.If you want to make changes update it from below')</script>");
                    cidx.Text = "";
                }
                else
                {
                    using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=D:\.net files\project\TAC\TAC\App_data\TAC.accdb"))
                    {
                        cmd = new OleDbCommand();
                        cmd.CommandText = "insert into course_details (cid,cname,duration,fees) values(?,?,?,?)";
                        cmd.Parameters.AddWithValue("", cidx.Text);
                        cmd.Parameters.AddWithValue("", cnamex.Text);
                        cmd.Parameters.AddWithValue("", drtnx.Text);
                        cmd.Parameters.AddWithValue("", fsx.Text);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('Inserted Successfully')</script>");
                        cidx.Text = "";
                        cnamex.Text = "";
                        drtnx.Text = "";
                        fsx.Text = "";
                    }
                    gvbind();
                }
            }
        }
        
        protected void cnamex_TextChanged(object sender, EventArgs e)
        {
            
        }

         }
}