using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace OnlineGrocery.View.Admin
{
    public partial class Categories : System.Web.UI.Page
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
            fnbindgrib();
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
                    //Response.Write("<script>alert('connected')</script>");
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
                String qry = "INSERT INTO tblCategory(catName,catDescription) VALUES('" + txtCatdname.Text + "','" + txtCatremarks.Text + "')";
                cmd = new SqlCommand(qry, conn);
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    lblMsg.InnerText = "inserted..";
                }
                else
                {
                    lblMsg.InnerText = "sorry..";
                }
                conn.Close();
                fnbindgrib();
            }
            catch (Exception ex)
            {
                lblMsg.InnerText= ex.Message;
            }
        }

        protected void fnbindgrib()
        {
            DataSet ds = new DataSet();
            try
            {
                fnConnectDB();
                String qry = "SELECT * FROM tblCategory";
                cmd = new SqlCommand (qry, conn);
                sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                dtgCategory.DataSource = ds;
                dtgCategory.DataBind();
                conn.Close();
            }
            catch(Exception ex)
            {
                lblMsg.InnerText = ex.Message;
            }
        }

        protected void dtgCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow rw = dtgCategory.SelectedRow;
            txtCatdname.Text = rw.Cells[2].Text;
            txtCatremarks.Text = rw.Cells[3].Text;
            up_id = Convert.ToInt32(rw.Cells[1].Text);
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                fnConnectDB();
                String qry = "UPDATE tblCategory SET catName= '"+txtCatdname.Text+"', catDescription='"+txtCatremarks.Text+"' WHERE Cat_id=@up_id";
                cmd = new SqlCommand (qry, conn);
                cmd.Parameters.AddWithValue("up_id",up_id);
                int res = cmd.ExecuteNonQuery();
                if(res>0)
                {
                    lblMsg.InnerText = "yess updated..";
                }
                else
                {
                    lblMsg.InnerText = "ohh noo..";
                }
                conn.Close();
                fnbindgrib();
            }
            catch( Exception ex )
            {
                lblMsg.InnerText= ex.Message;
            }
        }
        protected void dtgCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow rw = dtgCategory.Rows[e.RowIndex];
            int c_id = Convert.ToInt32(rw.Cells[1].Text);
            try
            {
                fnConnectDB();
                String qry = "DELETE FROM tblCategory WHERE Cat_id=@c_id";
                cmd = new SqlCommand (qry, conn);
                cmd.Parameters.AddWithValue("c_id",c_id);
                int res = cmd.ExecuteNonQuery();
                if(res>0)
                {
                    lblMsg.InnerText = "Deleted..";
                }
                else
                {
                    lblMsg.InnerText = "Error..";
                }
                conn.Close();
                fnbindgrib();
            }
            catch( Exception ex )
            {
                lblMsg.InnerText= ex.Message;
            }
        }

        
    }
}