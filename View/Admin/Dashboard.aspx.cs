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
    public partial class Dashboard : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        public static int cnt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                fnConnectDB();
                fnBindSeller();
                if (Session["s_admin"] == null && Session["s_seller"] == null)
                {
                    Response.Redirect("../Login.aspx");
                }
                Session["Products"] = fnProduct(cnt);
                Session["Category"] = fnCategory(cnt);
                Session["Finance"] = fnFinance(cnt);
                Session["Sellers"] = fnSeller(cnt);
                Session["Total_sells"] = FNtotal_sells(cnt);
            }
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
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error')</script>");
            }
        }
        protected void fnBindSeller()
        {
            DataSet ds = new DataSet();
            try
            {
                fnConnectDB();
                string qry = "SELECT * FROM tblSeller";
                cmd = new SqlCommand(qry, conn);
                sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                ddlSeller.DataSource = ds;
                ddlSeller.DataTextField = "sname";
                ddlSeller.DataValueField = "Sel_id";
                ddlSeller.DataBind();
                conn.Close();
            }
            catch (Exception ex)
            {

                Response.Write(ex.ToString());
            }
        }
        protected int fnProduct(int cnt)
        {
            fnConnectDB();
            {
                cmd = new SqlCommand("select count(*) from tblProduct", conn);
                SqlDataReader sda = cmd.ExecuteReader();
                while(sda.Read())
                {
                    if (sda[0] == DBNull.Value)
                    {
                        cnt = 0;
                    }
                    else
                    {
                        cnt = Convert.ToInt32(sda[0]);
                    }
                }
                return cnt;
            }
        }
        protected int fnCategory(int cnt)
        {
            fnConnectDB();
            {
                cmd = new SqlCommand("select count(*) from tblCategory", conn);
                SqlDataReader sda = cmd.ExecuteReader();
                while (sda.Read())
                {
                    if (sda[0] == DBNull.Value)
                    {
                        cnt = 0;
                    }
                    else
                    {
                        cnt = Convert.ToInt32(sda[0]);
                    }
                }
                return cnt;
            }
        }
        protected int fnSeller(int cnt)
        {
            fnConnectDB();
            {
                cmd = new SqlCommand("select count(*) from tblSeller", conn);
                SqlDataReader sda = cmd.ExecuteReader();
                while (sda.Read())
                {
                    if (sda[0] == DBNull.Value)
                    {
                        cnt = 0;
                    }
                    else
                    {
                        cnt = Convert.ToInt32(sda[0]);
                    }
                }
                return cnt;
            }
        }
        protected int fnFinance(int cnt)
        {
            fnConnectDB();
            {
                String qry = "select sum(Amount) from tblBill";
                cmd = new SqlCommand(qry, conn);
                SqlDataReader sda = cmd.ExecuteReader();
                while (sda.Read())
                {
                    if (sda[0] == DBNull.Value)
                    {
                        cnt = 0;
                    }
                    else
                    {
                        cnt = Convert.ToInt32(sda[0]);
                    }
                }
                return cnt;
            }
        }
        protected int FNtotal_sells(int cnt)
        {
            fnConnectDB();
            {
                string qry = "SELECT Sum(Amount) FROM  tblBill WHERE Sel_id =@s_id";
                cmd = new SqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("s_id", ddlSeller.SelectedValue);
                SqlDataReader sda = cmd.ExecuteReader();
                while (sda.Read())
                {
                    if (sda[0] == DBNull.Value)
                    {
                        cnt = 0;
                    }
                    else
                    {
                        cnt = Convert.ToInt32(sda[0]);
                    }
                }
            }
            return cnt;
        }
        protected void ddlSeller_SelectedIndexChanged(object sender, EventArgs e)
        {
            FNtotal_sells(cnt);
        }
    }
}