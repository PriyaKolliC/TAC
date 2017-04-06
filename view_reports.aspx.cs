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
    public partial class view_student_details : System.Web.UI.Page
    {
        OleDbConnection con;
        OleDbCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cmmn_lbl.Visible = false;
                cmmn_txt.Visible = false;
                ReportViewer1.Visible = false;
            }
        }

        protected void bttn_clk(object sender, EventArgs e)
        {
            if (cmmn_txt.Visible == true)
            {
                if (ddl.Text.Equals("Batch Id"))
                {
                    OleDbDataReader cmdr = null;
                    string temp = cmmn_txt.Text; string temp2="",temp3="";
                    using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=D:\.net files\project\TAC\TAC\App_data\TAC.accdb"))
                    {
                        cmd = new OleDbCommand();
                        cmd.CommandText = "select course_name from batch_details where batch_id='"+temp+"'";
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        cmdr = cmd.ExecuteReader();
                        while (cmdr.Read())
                        {
                            temp2 = cmdr["course_name"].ToString();
                        }
                        con.Close();
                        cmd.CommandText = "select t1.student_name,t1.fee_paid_till_date,t1.fee_remaining from fee_details as t1 where t1.dop=(select MAX(t2.dop) from fee_details as t2 where t2.student_name=t1.student_name and t2.dob=t1.dob )";
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        cmdr = cmd.ExecuteReader();
                        while (cmdr.Read())
                        {
                           
                        }
                        Response.Write("<script>alert('"+temp3+"')</script>");
                    }
                }
                else
                {

                }
            }
            else
            {

            }
        }

        protected void indx_change(object sender, EventArgs e)
        {
            if (ddl.Text.Equals("--Select"))
            {
                Response.Write("<script>alert('Choose any option from dropdown')</script>");
            }
            else
            {
                if (ddl.Text.Equals("Batch Id"))
                {
                    cmmn_lbl.Visible = true;
                    cmmn_txt.Visible = true;
                }
                else if (ddl.Text.Equals("Course"))
                {
                    cmmn_lbl.Visible = true;
                    cmmn_txt.Visible = true;
                }
                else
                {
                    cmmn_lbl.Visible = false;
                    cmmn_txt.Visible = false;
                }
            }
        
        }   
    }
}