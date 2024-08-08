using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Uthandolezzwe
{
    public partial class Contact : Page
    {
        private MySqlConnection connection = new MySqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            var conn = ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ConnectionString;
            connection.ConnectionString = conn;
            connection.Open();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                
            }
        }
    }
}