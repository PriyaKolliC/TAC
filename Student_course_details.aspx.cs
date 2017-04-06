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
    public partial class Student_course_Details : System.Web.UI.Page
    {
        OleDbConnection con;
        OleDbCommand cmd, cmdn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ssname_txt.Text = Session["snm"].ToString();
                ddob_txt.Text = Session["db"].ToString();
                dd_course_ddl.Items.Add(new ListItem("--Select Course",""));
            }
        }
        protected void fill_dropdown2()
        {
            using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=D:\.net files\project\TAC\TAC\App_data\TAC.accdb"))
            {
                con.Open();
                using (OleDbCommand cmd = new OleDbCommand("SELECT batch_id from batch_details where course_name='"+dd_course_ddl.Text+"'"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    using (OleDbDataAdapter sda = new OleDbDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        bbid_ddl.DataSource=ds.Tables[0];
                        bbid_ddl.DataTextField = "batch_id";
                        bbid_ddl.DataValueField = "batch_id";
                        bbid_ddl.DataBind();
                    }
                }
                con.Close();
            }
            
        }
        protected void submit_Click(object sender, EventArgs e)
        {

            if (doj_txt.Text == "" || dis_txt.Text == "")
            {
                Response.Write("<script>alert('Marked fields are mandatory')</script>");
            }

            else
            {
                int result = 0;
                using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=D:\.net files\project\TAC\TAC\App_data\TAC.accdb"))
                {
                    cmd = new OleDbCommand();
                    cmd.CommandText = "select count(*) from student_course_info where sname=? and dob=? and batchid=?";
                    cmd.Parameters.AddWithValue("", ssname_txt.Text);
                    cmd.Parameters.AddWithValue("", ddob_txt.Text);
                    cmd.Parameters.AddWithValue("", bbid_ddl.Text);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    result = (int)cmd.ExecuteScalar();
                    con.Close();
                }
                if (result > 0)
                {
                    Response.Write("<script>alert('Student is already registered for this batch')</script>");
                }
                else
                {
                    int r = 0;
                    using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=D:\.net files\project\TAC\TAC\App_data\TAC.accdb"))
                    {
                        cmd = new OleDbCommand();
                        cmd.CommandText = "select c.fees from course_details as c,batch_details as b where b.batch_id='" + bbid_ddl.Text + "' and c.cname=b.course_name";
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        r = (int)cmd.ExecuteScalar();
                        r = r - Convert.ToInt16(dis_txt.Text);
                        con.Close();
                    }
                    using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=D:\.net files\project\TAC\TAC\App_data\TAC.accdb"))
                    {
                        cmd = new OleDbCommand();
                        cmd.CommandText = "insert into student_course_info (sname,dob,course_name,batchid,discount,doj,fees) values(?,?,?,?,?,?,?)";
                        cmd.Parameters.AddWithValue("", ssname_txt.Text);
                        cmd.Parameters.AddWithValue("", ddob_txt.Text);
                        cmd.Parameters.AddWithValue("", dd_course_ddl.Text);
                        cmd.Parameters.AddWithValue("", bbid_ddl.Text);
                        cmd.Parameters.AddWithValue("", Convert.ToInt32(dis_txt.Text));
                        cmd.Parameters.AddWithValue("", doj_txt.Text);
                        cmd.Parameters.AddWithValue("", r);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('Inserted Successfully')</script>");
                        ssname_txt.Text = "";
                        ddob_txt.Text = "";
                        dis_txt.Text = "";
                        doj_txt.Text = "";
                    }
                }
            }
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("student_details.aspx");
        }

        protected void dd_course_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_dropdown2();
        }
    }
}