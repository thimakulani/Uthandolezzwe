using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Uthandolezzwe.Views.Tenders
{
    public partial class TenderHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTenders();
            }
        }
        protected void LoadTenders()
        {
            //tender_name, bid_number, tendering_institution, tendering_department, attending_person, office_due_date, tender_due_date, project_type
            string connectionString = ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ConnectionString;
            string query = "SELECT * FROM Tenders";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            tenders.DataSource = dataTable;
                            tenders.DataKeyNames = new string[] { "tenderid" };
                            tenders.DataBind();
                        }
                        else
                        {
                            // Handle case when no data is retrieved
                            // For example, display a message
                        }
                    }
                }
            }
        }

        protected void tenders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = tenders.Rows[rowIndex];
                string tenderId = tenders.DataKeys[rowIndex]["tenderid"].ToString();
                Response.Redirect($"details?tenderId={tenderId}");
            }
        }
    }
}