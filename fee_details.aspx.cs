using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
namespace TAC
{
    public partial class fee_details : System.Web.UI.Page
    {
        OleDbConnection con;
        OleDbCommand cmd;
        int total_fee;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                popup.Visible = true;
                popup_btns.Visible = true;
                normal.Visible = false;
                temp_ddl.Visible = false;
                
            }
        }

        protected void fee_dtls(object sender, EventArgs e)
        {
            if (psname_txt.Text == "" || pdob_txt.Text == "")
                Response.Write("<script>alert('All fields are mandatory')</script>");
            else
            {
                int result = 0;
                using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=D:\.net files\project\TAC\TAC\App_data\TAC.accdb"))
                {
                    cmd = new OleDbCommand();
                    cmd.CommandText = "select count(*) from student_course_info where sname=? and dob=?";
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
                    int i=1;
                    popup_btns.Visible = false;
                    normal.Visible = true;
                    temp_ddl.Visible = false;
                    temp_ddl.Items.Insert(0, "--select");
                    crse_name_ddl.Items.Insert(0, "--select");
                    //temp_ddl.Items.Add("--");
                    Response.Write("<script>alert(i)</script>");
                    using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=D:\.net files\project\TAC\TAC\App_data\TAC.accdb"))
                    {
                        
                        OleDbDataReader cmdr = null;
                        cmd = new OleDbCommand();
                        cmd.CommandText = "select course_name,fees from student_course_info where sname='"+psname_txt.Text+"' and dob='"+pdob_txt.Text+"'";
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        cmdr = cmd.ExecuteReader();
                      //  Response.Write("<script>alert(i)</script>");
                        while (cmdr.Read())
                        {
                            crse_name_ddl.Items.Insert(i,cmdr["course_name"].ToString());
                            temp_ddl.Items.Insert(i,cmdr["fees"].ToString());
                            i++;
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('No such record exists')</script>");
                }
            }

        }

        protected void Cancel_btn(object sender, EventArgs e)
        {
            Response.Redirect("homepage.aspx");
        }

        protected void save_click(object sender, EventArgs e)
        {
            if (fee_entry_txt.Text == "" || dop_txt.Text == "")
                Response.Write("<script>alert('All fields are mandatory')</script>");
            else
            {
                using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=D:\.net files\project\TAC\TAC\App_data\TAC.accdb"))
                {
                    string bid="";
                    OleDbDataReader cmdr = null;
                    cmd = new OleDbCommand();
                    cmd.CommandText = "select batchid from student_course_info where sname='" + psname_txt.Text + "' and dob='" + pdob_txt.Text + "' and course_name='" + crse_name_ddl.Text + "'";
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    cmdr = cmd.ExecuteReader();
                    while (cmdr.Read())
                    {
                        bid = cmdr["batchid"].ToString();
                    }
                    con.Close();
                    int xy = crse_name_ddl.SelectedIndex;
                    cmd.CommandText = "insert into fee_details (student_name,dob,batch_id,course,fee_paid_till_date,fee_remaining,dop) values(?,?,?,?,?,?,?)";
                    cmd.Parameters.AddWithValue("", psname_txt.Text);
                    cmd.Parameters.AddWithValue("", pdob_txt.Text.ToString());
                    cmd.Parameters.AddWithValue("", bid);
                    cmd.Parameters.AddWithValue("", crse_name_ddl.Text);
                    cmd.Parameters.AddWithValue("", Convert.ToInt16(fees_paid_amount.Text)+Convert.ToInt16(fee_entry_txt.Text));
                    cmd.Parameters.AddWithValue("", Convert.ToInt32(temp_ddl.Items[xy].Text.ToString()) - (Convert.ToInt16(fees_paid_amount.Text) + Convert.ToInt16(fee_entry_txt.Text)));
                    cmd.Parameters.AddWithValue("", dop_txt.Text);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Inserted Successfully')</script>");
                }
                crse_name_ddl.Items.Clear();
                temp_ddl.Items.Clear();
                psname_txt.Text = "";
                pdob_txt.Text = "";
                fees_paid_amount.Text = "0";
                rem_fees_amount.Text = "0";
                fee_entry_txt.Text = "";
                dop_txt.Text = "";
                popup.Visible = true;
                popup_btns.Visible = true;
                normal.Visible = false;
            }
        }
        protected void fill_labels(int indx)
        {
            int fee_paid=0;
            OleDbDataReader cmdr = null;
            using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=D:\.net files\project\TAC\TAC\App_data\TAC.accdb"))
            {
                cmd = new OleDbCommand();
                cmd.CommandText = "select fee_paid_till_date from fee_details where student_name=? and dob=? and course=?";
                cmd.Parameters.AddWithValue("", psname_txt.Text);
                cmd.Parameters.AddWithValue("", pdob_txt.Text.ToString());
                cmd.Parameters.AddWithValue("", crse_name_ddl.Text);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                cmdr = cmd.ExecuteReader();
                while (cmdr.Read())
                {
                    fee_paid = fee_paid+Convert.ToInt32(cmdr["fee_paid_till_date"].ToString());
                }
                con.Close();
                fees_paid_amount.Text=fee_paid.ToString();
                total_fee = Convert.ToInt32(temp_ddl.Items[indx].Text.ToString());
                if (total_fee > fee_paid)
                    rem_fees_amount.Text = (total_fee - fee_paid).ToString();
                else
                {
                    rem_fees_amount.Text = "Fee is paid";
                    fee_entry_txt.ReadOnly = true;
                    dop_txt.ReadOnly = true;
                }
            }
           
        }
        protected void cancel_click(object sender, EventArgs e)
        {
            normal.Visible = false;
            popup.Visible = true;
            popup_btns.Visible = true;
            psname_txt.Text = "";
            pdob_txt.Text = "";
            crse_name_ddl.Items.Clear();
            temp_ddl.Items.Clear();
        }

        protected void crse_name_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indx;
            indx = crse_name_ddl.SelectedIndex;
            fill_labels(indx);
        }
    }
}