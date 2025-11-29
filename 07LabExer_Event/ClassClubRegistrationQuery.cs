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

        public bool RegisterStudent(int ID, long StudentID, string FirstName, string MiddleName, string LastName, int Age, string Gender, string Program)
        {
            sqlCommand = new SqlCommand("INSERT INTO ClubMembers VALUES(@ID, @StudentID, @FirstName, @MiddleName, @LastName, @Age, @Gender, @Program)", sqlConnect);
            sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            sqlCommand.Parameters.Add("@RegistrationID", SqlDbType.BigInt).Value = StudentID;
            sqlCommand.Parameters.Add("@StudentID", SqlDbType.VarChar).Value = StudentID;
            sqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FirstName;
            sqlCommand.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value = MiddleName;
            sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LastName;
            sqlCommand.Parameters.Add("@Age", SqlDbType.Int).Value = Age;
            sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = Gender;
            sqlCommand.Parameters.Add("@Program", SqlDbType.VarChar).Value = Program;

            sqlConnect.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();
            return true;
        }
    }
}

