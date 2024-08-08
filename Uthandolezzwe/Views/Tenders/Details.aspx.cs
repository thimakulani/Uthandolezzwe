using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Uthandolezzwe.Views.Tenders
{
    public partial class Details : System.Web.UI.Page
    {
        private MySqlConnection connection = new MySqlConnection();
        string tenderId;
        protected void Page_Load(object sender, EventArgs e)
        {
            var conn = ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ConnectionString;
            connection.ConnectionString = conn;
            if (Request.QueryString["tenderId"] != null)
            {
                tenderId = Request.QueryString["tenderId"];
                GetDetails(tenderId);

            }
        }

        private void GetDetails(string tenderId)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM Tenders Where tenderid = @tenderId", connection);
            command.Parameters.AddWithValue("@tenderId", tenderId);
            try
            {
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    
                    if (reader.Read())
                    {
                        // Access data from the reader
                        tender_name.Text = reader["tender_name"].ToString();
                        bit_number.Text = reader["bid_number"].ToString();
                        tendering_institution.Text = reader["tendering_institution"].ToString();
                        tendering_department.Text = reader["tendering_department"].ToString();
                        attending_person.Text = reader["attending_person"].ToString();
                        office_due_date.Text = reader["office_due_date"].ToString();
                        tender_due_date.Text = reader["tender_due_date"].ToString();
                        project_type.Text = reader["project_type"].ToString();

                    }
                    else
                    {
                        // Handle case when no data is found for the given tenderId
                    }
                };
                connection.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Update()
        {
            string query = @"UPDATE Tenders SET tender_name = @TenderName, bid_number = @BidNumber, tendering_institution = @TenderingInstitution,
                               tendering_department = @TenderingDepartment, attending_person = @AttendingPerson, office_due_date = @OfficeDueDate,
                                tender_due_date = @TenderDueDate, project_type = @ProjectType
                                WHERE tenderid = @tenderId";

            DateTime odd = DateTime.Parse(office_due_date.Text);
            DateTime tdd = DateTime.Parse(tender_due_date.Text);
            DateTime offiec_due = odd.Date;
            DateTime tender_due = tdd.Date;

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@tenderId", tenderId);
                command.Parameters.AddWithValue("@TenderName", tender_name.Text);
                command.Parameters.AddWithValue("@BidNumber", bit_number.Text);
                command.Parameters.AddWithValue("@TenderingInstitution", tendering_institution.Text);
                command.Parameters.AddWithValue("@TenderingDepartment", tendering_department.Text);
                command.Parameters.AddWithValue("@AttendingPerson", attending_person.Text);
                command.Parameters.AddWithValue("@OfficeDueDate", offiec_due); // Assuming the date is entered in the correct format
                command.Parameters.AddWithValue("@TenderDueDate", tender_due); // Assuming the date is entered in the correct format
                command.Parameters.AddWithValue("@ProjectType", project_type.SelectedValue);

                // Add other parameters for updating other fields

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Update successful, you might want to display a success message
                    }
                    else
                    {
                        // Handle case when no rows were updated
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., log or display an error message)
                }
            }
        }

        protected void BtnUpdateTender_Click(object sender, EventArgs e)
        {
            Update();
        }
    }
}