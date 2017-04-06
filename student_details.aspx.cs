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
    public partial class student_details : System.Web.UI.Page
    {
        OleDbConnection con;
        OleDbCommand cmd,cmdn,cmdx;
        protected void Page_Load(object sender, EventArgs e)
        {
            popup.Visible = false;
            update_sd_id.Visible = false;
        }
        protected void magic(object sender, EventArgs e)
        {
            if (popup.Visible == false)
            {
                popup.Visible = true;
                normal.Visible = false;
                update_sd_id.Visible = false;
            }
        }
        protected void update_details(object sender, EventArgs e)
        {
            if (psname_txt.Text == "" || pdob_txt.Text == "")
            {
                Response.Write("<script>alert('* fields are mandatory')</script>");
            }
            else
            {
                int result = 0;
                using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=D:\.net files\project\TAC\TAC\App_data\TAC.accdb"))
                {
                    cmd = new OleDbCommand();
                    cmd.CommandText = "select count(*) from student_info where sname=? and dob=?";
                    cmd.Parameters.AddWithValue("", psname_txt.Text);
                    cmd.Parameters.AddWithValue("", pdob_txt.Text.ToString());
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    result = (int)cmd.ExecuteScalar();
                    con.Close();
                }
                if (result > 0)
                {
                    Session["snm"] = psname_txt.Text;
                    Session["db"] = pdob_txt.Text;
                    psname_txt.Text = "";
                    pdob_txt.Text = "";
                    popup.Visible = false;
                    normal.Visible = false;
                    update_sd_id.Visible = true;
                    using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=D:\.net files\project\TAC\TAC\App_data\TAC.accdb"))
                    {
                        cmdn = new OleDbCommand();
                        cmdn.CommandText = "select * from student_info where sname=? and dob=?";
                        cmdn.Parameters.AddWithValue("", Session["snm"].ToString());
                        cmdn.Parameters.AddWithValue("", Session["db"].ToString());
                        OleDbDataReader cmdnr = null;
                        cmdn.Connection = con;
                        con.Open();
                        cmdn.ExecuteNonQuery();
                        cmdnr = cmdn.ExecuteReader();
                        up_sname_txt.Text = Session["snm"].ToString();
                        up_dob_txt.Text = Session["db"].ToString();
                        up_sname_txt.ReadOnly = true;
                        up_dob_txt.ReadOnly = true;
                        while (cmdnr.Read())
                        {
                            up_fname_txt.Text = cmdnr["fname"].ToString();
                            up_mname_txt.Text = cmdnr["mname"].ToString();
                            up_mob_txt.Text = cmdnr["mob"].ToString();
                            up_email_txt.Text = cmdnr["email"].ToString();
                            up_cad_txt.Text = cmdnr["caddress"].ToString();
                            up_pad_txt.Text = cmdnr["paddress"].ToString();
                            up_cname_ddl.Text = cmdnr["clgname"].ToString();
                            up_bname_ddl.Text = cmdnr["bname"].ToString();
                            up_sem_ddl.Text = cmdnr["sem"].ToString();
                            up_stat_ddl.Text = cmdnr["status"].ToString();
                        }
                        con.Close();
                    }
                }
                else
                {
                    Response.Write("<script>alert('No Record Exists')</script>");
                    Response.Redirect("student_details.aspx");
                }
            }
        }
        protected void Cancel_up(object sender, EventArgs e)
        {
            Response.Redirect("student_details.aspx");
        }
        protected void save_details(object sender, EventArgs e)
        {
            if(up_fname_txt.Text==""||up_mname_txt.Text==""||up_mob_txt.Text==""||up_email_txt.Text==""||up_cad_txt.Text==""||up_pad_txt.Text=="")
            {
                Response.Write("<script>alert('Marked fields are mandatory')</script>");
            }
            else
            {
                using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=D:\.net files\project\TAC\TAC\App_data\TAC.accdb"))
                {
                cmdx = new OleDbCommand();
                cmdx.CommandText = "update student_info set fname='"+up_fname_txt.Text+"',mname='"+up_mname_txt.Text+"',mob='"+up_mob_txt.Text+"',email='"+up_email_txt.Text+"',caddress='"+up_cad_txt.Text+"',paddress='"+up_pad_txt.Text+"',clgname='"+up_cname_ddl.Text+"',bname='"+up_bname_ddl.Text+"',sem='"+up_sem_ddl.Text+"',status='"+up_stat_ddl.Text+"' where sname='"+up_sname_txt.Text+"' and dob='"+Session["db"].ToString()+"'";
                cmdx.Connection = con;
                con.Open();
                cmdx.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Updated Successfully')</script>");
                up_sname_txt.ReadOnly = false;
                up_dob_txt.ReadOnly = false;
               up_sname_txt.Text = "";
                up_fname_txt.Text = "";
                up_mname_txt.Text = "";
                up_mob_txt.Text = "";
                up_dob_txt.Text = "";
                up_email_txt.Text = "";
                up_cad_txt.Text = "";
                up_pad_txt.Text = "";
            }
                Response.Redirect("Student_details.aspx");
           }
        }
        protected void check_details(object sender, EventArgs e)
        {
            int result = 0;
            using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=D:\.net files\project\TAC\TAC\App_data\TAC.accdb"))
            {
                cmd = new OleDbCommand();
                cmd.CommandText = "select count(*) from student_info where sname=? and dob=?";
                cmd.Parameters.AddWithValue("",psname_txt.Text);
                cmd.Parameters.AddWithValue("", pdob_txt.Text);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                result = (int)cmd.ExecuteScalar();
                con.Close();
                Session["snm"] = psname_txt.Text;
                Session["db"] = pdob_txt.Text;
                psname_txt.Text = "";
                pdob_txt.Text = "";
            }
            if (result > 0)
            {
                Response.Redirect("student_course_details.aspx");   
            }
            else
            { 
                Response.Write("<script>alert('No record exists.Register here')</script>");
                popup.Visible = false;
                normal.Visible = true;
            }
        }


        protected void register_Click(object sender, EventArgs e)
        {
            if(sname_txt.Text==""||fname_txt.Text==""||mname_txt.Text==""||mob_txt.Text==""||dob_txt.Text==""||email_txt.Text==""||cad_txt.Text==""||pad_txt.Text=="")
            {
                Response.Write("<script>alert('Marked fields are mandatory')</script>");
            }
            else
            {
                int result = 0;
                using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=D:\.net files\project\TAC\TAC\App_data\TAC.accdb"))
                {
                    cmd = new OleDbCommand();
                    cmd.CommandText = "select count(*) from student_info where sname=? and dob=?";
                    cmd.Parameters.AddWithValue("", sname_txt.Text);
                    cmd.Parameters.AddWithValue("", dob_txt.Text);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    result = (int)cmd.ExecuteScalar();
                    con.Close();
                }
                if (result > 0)
                {
                    Response.Write("<script>alert('Student Record already exists')</script>");
                }
                else
                {
            using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=D:\.net files\project\TAC\TAC\App_data\TAC.accdb"))
            {
                cmd = new OleDbCommand();
                cmd.CommandText = "insert into student_info (sname,fname,mname,mob,dob,email,caddress,paddress,clgname,bname,sem,status) values(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.Parameters.AddWithValue("", sname_txt.Text);
                cmd.Parameters.AddWithValue("", fname_txt.Text);
                cmd.Parameters.AddWithValue("", mname_txt.Text);
                cmd.Parameters.AddWithValue("", mob_txt.Text);
                cmd.Parameters.AddWithValue("", dob_txt.Text.ToString());
                cmd.Parameters.AddWithValue("", email_txt.Text);
                cmd.Parameters.AddWithValue("", cad_txt.Text);
                cmd.Parameters.AddWithValue("", pad_txt.Text);
                cmd.Parameters.AddWithValue("", colname_ddl.Text);
                cmd.Parameters.AddWithValue("", bname_ddl.Text);
                cmd.Parameters.AddWithValue("", sem_ddl.Text);
                cmd.Parameters.AddWithValue("", stat_ddl.Text);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Session["snm"] = sname_txt.Text;
                Session["db"] = dob_txt.Text;
                Response.Write("<script>alert('Inserted Successfully')</script>");
                sname_txt.Text="";
                fname_txt.Text="";
                mname_txt.Text="";
                mob_txt.Text="";
                dob_txt.Text="";
                email_txt.Text="";
                cad_txt.Text="";
                pad_txt.Text="";
            }
            }
            }
            Response.Redirect("Student_course_details.aspx?");
        }

        protected void cancel(object sender, EventArgs e)
        {
            popup.Visible = false;
            normal.Visible = true;
        }
    }
}