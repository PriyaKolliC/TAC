using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.OleDb;
namespace TAC
{
    public partial class batch_details : System.Web.UI.Page
    {
        OleDbCommand cmd;
        OleDbConnection con;
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
                OleDbCommand cmd = new OleDbCommand("select * from batch_details order by batch_id", con);
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
                cmd.CommandText = "delete from batch_details where batch_id=?";
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
            TextBox coursename = (TextBox)row.Cells[1].Controls[0];
            TextBox batchtime = (TextBox)row.Cells[2].Controls[0];
            TextBox  startdate= (TextBox)row.Cells[3].Controls[0];
           // TextBox enddate = (TextBox)row.Cells[4].Controls[0];
            var ddll = GridView1.Rows[e.RowIndex].FindControl("ddl_stat") as DropDownList;
            string text = ddll.SelectedItem.Text;
            string value = ddll.SelectedItem.Value;
            GridView1.EditIndex = -1;
            using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=D:\.net files\project\TAC\TAC\App_data\TAC.accdb"))
            {
                con.Open();
                cmd = new OleDbCommand("update batch_details set course_name='" + coursename.Text + "',batch_time='" +batchtime.Text + "',start_date='" +startdate.Text + "',status='"+text+"' where batch_id='" + GridView1.Rows[e.RowIndex].Cells[0].Text + "'");
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
                gvbind();
            }
        }
        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddList = (DropDownList)e.Row.FindControl("ddl_stat");
                    ddList.Items.Add(new ListItem("running","0",true));
                    ddList.Items.Add(new ListItem("completed", "1", true));
                    ddList.DataBind();
                    DataRowView dr = e.Row.DataItem as DataRowView;
                    ddList.SelectedValue = dr["status"].ToString();
                }
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
        protected void bdd_add(object sender, EventArgs e)
        {
            if(batch_txt.Text==""||cid_ddl.Text==""||sdate.Text==""||btime.Text==""||stat_ddl.Text=="")
            {
                Response.Write("<script>alert('Marked fields are mandatory')</script>");
            }
            else
            {
            int result = 0;
            using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=D:\.net files\project\TAC\TAC\App_data\TAC.accdb"))
            {
                cmd = new OleDbCommand();
                cmd.CommandText = "select count(*) from batch_details where batch_id=?";
                cmd.Parameters.AddWithValue("",batch_txt.Text);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                result = (int)cmd.ExecuteScalar();
                con.Close();
            }
            if (result > 0)
            {
                Response.Write("<script>alert('Batch Id already exists')</script>");
                batch_txt.Text = "";
            }
            else
            {
                using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=D:\.net files\project\TAC\TAC\App_data\TAC.accdb"))
                {
                    cmd = new OleDbCommand();
                    cmd.CommandText = "insert into batch_details (batch_id,course_name,batch_time,start_date,status) values(?,?,?,?,?)";
                    cmd.Parameters.AddWithValue("", batch_txt.Text);
                    cmd.Parameters.AddWithValue("", cid_ddl.Text);
                    cmd.Parameters.AddWithValue("", btime.Text);
                    cmd.Parameters.AddWithValue("", sdate.Text);
                    cmd.Parameters.AddWithValue("", stat_ddl.Text);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Inserted Successfully')</script>");
                    batch_txt.Text="";
                    btime.Text="";
                    sdate.Text="";
                }
                gvbind();
            }
            }
        }        
    }
}