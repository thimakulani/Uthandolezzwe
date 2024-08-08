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
    public partial class Create : System.Web.UI.Page
    {
        private MySqlConnection connection = new MySqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            var conn = ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ConnectionString;
            connection.ConnectionString = conn;
          

        }
        private void Insert()
        {
            DateTime odd = DateTime.Parse(office_due_date.Text);
            DateTime tdd = DateTime.Parse(tender_due_date.Text);
            DateTime offiec_due = odd.Date;
            DateTime tender_due = tdd.Date;
            string query = "INSERT INTO Tenders (tender_name, bid_number, tendering_institution, tendering_department, attending_person, office_due_date, tender_due_date, project_type) " +
                               "VALUES (@TenderName, @BidNumber, @TenderingInstitution, @TenderingDepartment, @AttendingPerson, @OfficeDueDate, @TenderDueDate, @ProjectType)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@TenderName", tender_name.Text);
            command.Parameters.AddWithValue("@BidNumber", bit_number.Text);
            command.Parameters.AddWithValue("@TenderingInstitution", tendering_institution.Text);
            command.Parameters.AddWithValue("@TenderingDepartment", tendering_department.Text);
            command.Parameters.AddWithValue("@AttendingPerson", attending_person.Text);
            command.Parameters.AddWithValue("@OfficeDueDate", offiec_due); 
            command.Parameters.AddWithValue("@TenderDueDate", tender_due); 
            command.Parameters.AddWithValue("@ProjectType", project_type.SelectedValue);

            connection.Open();
            
            int x = command.ExecuteNonQuery();
            if (x > 0)
            {
                Response.Redirect("tenderhome");
            }
            connection.Close();
        }
        protected void BtnCreateTender_Click(object sender, EventArgs e)
        {
            Insert();
        }
        
    }
}