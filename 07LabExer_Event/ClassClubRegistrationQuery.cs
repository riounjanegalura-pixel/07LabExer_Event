using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


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
    }
}

