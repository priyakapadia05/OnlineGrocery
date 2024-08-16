using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


namespace OnlineGrocery.View.Admin
{
    public partial class Sellers : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        GridViewRow rw;
        public static int up_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            fnConnectDB();
            fnBindGrid();
        }

        protected void fnConnectDB()
        {
            try
            {
                String strcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                conn = new SqlConnection(strcon);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    // Response.Write("<script>alert('connection successfull')</script>");
                }
            }
            catch (Exception ex)
            {
                lblMsg.InnerText = ex.Message;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                fnConnectDB();
                String qry = "INSERT INTO tblSeller(Sname,Semail,Spassword,Sphone,Saddress) VALUES('" + txtSelname.Text + "','" + txtSelemail.Text + "','" + txtSelpass.Text + "','" + txtSelphone.Text + "','" + txtSeladd.Text + "')";
                cmd = new SqlCommand(qry, conn);
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    lblMsg.InnerText = "Seller Added";
                }
                else
                {
                    lblMsg.InnerText = "Something is wrong,try Again";
                }
                conn.Close();
                fnBindGrid();
            }
            catch (Exception ex)
            {
                lblMsg.InnerText = ex.Message;
            }
            
        }

        protected void fnBindGrid()
        {
            DataSet ds = new DataSet();
            try
            {
                String qry = "SELECT * FROM tblSeller";
                cmd = new SqlCommand(qry, conn);
                sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                dtgSeller.DataSource = ds;
                dtgSeller.DataBind();
                conn.Close();
            }
            catch (Exception ex)
            {
                lblMsg.InnerText = ex.Message;
            }
        }

       

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                fnConnectDB();
                String qry = "UPDATE tblSeller SET Sname='" + txtSelname.Text + "' , Semail='" + txtSelemail.Text + "' , Spassword='" + txtSelpass.Text + "' , Sphone='" + txtSelphone.Text + "' , Saddress='" + txtSeladd.Text + "' WHERE Sel_id=@up_id";
                cmd = new SqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("up_id", up_id);
                int res = cmd.ExecuteNonQuery();
                if(res>0)
                {
                    lblMsg.InnerText = "updated..";
                }
                else
                {
                    lblMsg.InnerText = "Error";
                }
                conn.Close();
                fnBindGrid();
             }
            catch (Exception ex)
            {
                lblMsg.InnerText = ex.Message;
            }
        }

        protected void dtgSeller_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow rw = dtgSeller.SelectedRow;
            txtSelname.Text = rw.Cells[2].Text;
            txtSelemail.Text = rw.Cells[3].Text;
            txtSelpass.Text = rw.Cells[4].Text;
            txtSelphone.Text = rw.Cells[5].Text;
            txtSeladd.Text = rw.Cells[6].Text;
            up_id = Convert.ToInt32(rw.Cells[1].Text);
        }

        protected void dtgSeller_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow rw = dtgSeller.Rows[e.RowIndex];
            int s_id = Convert.ToInt32(rw.Cells[1].Text);
            try
            {
                fnConnectDB();
                String qry = "DELETE from tblSeller WHERE Sel_id=@s_id";
                cmd = new SqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("s_id", s_id);
                int res = cmd.ExecuteNonQuery();
                if(res>0)
                {
                    lblMsg.InnerText = " deleted...";
                }
                else
                {
                    lblMsg.InnerText = "ohh noo..";
                }
                conn.Close();
                fnBindGrid();
            }
            catch (Exception ex)
            {
                lblMsg.InnerText = ex.Message;
            }
        }
    }
}