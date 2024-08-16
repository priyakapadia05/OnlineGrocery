using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq.Expressions;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace OnlineGrocery.View
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        public static int Skey;
        public static int Sname;
        protected void Page_Load(object sender, EventArgs e)
        {
                fnConnectDB();    
        }

        protected void fnConnectDB()
        {
            try 
            {
                String strcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                conn = new SqlConnection(strcon);
                if (conn.State!=ConnectionState.Open)
                {
                    conn.Open();
                    //Response.Write("<script>alert('Connection successfull')</script>");
                }
            }
            catch(Exception e)
            {
                Response.Write(e.ToString());
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(rblUser.SelectedValue == "Admin")
            {
                if(txtUsername.Text == "Admin" &&  txtPassword.Text == "123")
                {
                    Session["s_admin"] = txtUsername.Text.Trim();
                    Response.Redirect("../View/Admin/Sellers.aspx");
                }
                else
                {
                    lblMsg.InnerText = "invalid Admin";
                }
            }
            if(rblUser.SelectedValue == "Seller")
            {
                String qry = "SELECT Sel_id ,Sname ,Spassword from tblSeller WHERE Sname='"+txtUsername.Text.Trim()+"' and Spassword='"+txtPassword.Text.Trim()+"'";
                cmd = new SqlCommand(qry,conn);
                DataTable dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    Session["s_seller"] = txtUsername.Text.Trim();
                    Skey = Convert.ToInt32(dt.Rows[0][0].ToString());
                    Response.Redirect("../View/Seller/Billing.aspx");
                }
                else
                {
                    lblMsg.InnerText = "Invalid User";
                }
            }
        }
    }
}