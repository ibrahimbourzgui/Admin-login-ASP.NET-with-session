using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace sitewebPFF
{
    public partial class adminlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSeconnecterAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from admin_ where email='" + txtUserAdmin.Text.Trim() + "'and pass ='" + txtMdpAdmin.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Session["role"] = "admin";
                        Response.Write("<script>alert('Hi Admin')</script>");
                        Session["idadmin"] = dr.GetValue(0).ToString();
                        Session["email"] = dr.GetValue(1).ToString();
                        
                    }
                    Response.Redirect("AdminPage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Admin introuvable')</script>");
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}