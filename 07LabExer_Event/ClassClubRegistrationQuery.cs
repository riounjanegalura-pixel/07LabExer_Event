using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;


namespace _07LabExer_Event
{
    public class ClubRegistrationQuery
    {
        private SqlConnection sqlConnect;
        private SqlCommand sqlCommand;
        private SqlDataAdapter sqlAdapter;
        private SqlDataReader sqlReader;
        private string connectionString;

        public DataTable dataTable;
        public BindingSource bindingSource;

        public string _FirstName;
        public string _MiddleName;
        private string _LastName;
        public string _Gender;
        public string _Program;

        public int _Age;

        public ClubRegistrationQuery()
        {

            this.connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\YourPath\\ClubDB.mdf\";Integrated Security=True;Connect Timeout=30";

            this.sqlConnect = new SqlConnection(this.connectionString);

            this.dataTable = new DataTable();
            this.bindingSource = new BindingSource();
        }

        public bool DisplayList()
        {
            string ViewClubMembers = "SELECT StudentId, FirstName, MiddleName, LastName, Age, Gender, Program FROM ClubMembers";

            this.sqlAdapter = new SqlDataAdapter(ViewClubMembers, this.sqlConnect);

            this.dataTable.Clear();
            this.sqlAdapter.Fill(this.dataTable);
            this.bindingSource.DataSource = this.dataTable;

            return true;
        }

    }
}

