using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace UsingDoubleDropdownAndGrid
{
    

    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con= null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        String SqlCmd = String.Empty;
      //  String con = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString);
            if (!IsPostBack)
            {
                getCountry();
            }
        }

        protected void DdlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString);
       
                getCity();
            
        }
        protected void getCity()
        {
            int CountryId = Convert.ToInt32(DdlCountry.SelectedValue);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            cmd = new SqlCommand("exec dbo.select_seher @id = " + CountryId, con);
            cmd.CommandType = CommandType.Text;
            DdlCity.DataSource = cmd.ExecuteReader();
            DdlCity.DataTextField = "name";
            DdlCity.DataValueField = "id";
            DdlCity.DataBind();
            DdlCity.Items.Insert(0, new ListItem("-select-", "0"));

        }
        protected void getCountry()
        {
            SqlCmd = "exec dbo.select_olkeler ";
            SqlCommand cmd = new SqlCommand(SqlCmd, con);

            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            dr = cmd.ExecuteReader();

            DdlCountry.DataSource = dr;
            DdlCountry.DataTextField = "name";
            DdlCountry.DataValueField = "id";
            DdlCountry.DataBind();
            DdlCountry.Items.Insert(0, new ListItem("-Select-", "0"));

            if (con.State != ConnectionState.Closed)
                con.Close();
        }
        protected void showData()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("exec dbo.select_restaurant @seher_id = " + Convert.ToInt32(DdlCity.SelectedValue), con);
            con.Open();
            adapt.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            //this.GridView1.Columns[0].Visible = false;
            //this.GridView1.Columns[1].Visible = false;

        }
        protected void DdlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            showData();
        }
    }
}