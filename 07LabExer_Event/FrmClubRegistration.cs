using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07LabExer_Event
{
    public partial class FrmClubRegistration : Form
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;

        private ClubRegistrationQuery clubRegistrationQuery;
        private int ID, Age, count;
        private string FirstName, MiddleName, LastName, Gender, Program;
        private long StudentId;

        private void FrmClubRegistration_Load(object sender, EventArgs e)
        {
            clubRegistrationQuery = new ClubRegistrationQuery();
            RefreshListOfClubMembers();

        }

        public int RegistrationID()
        {
            count++;
            return count;
        }

        public FrmClubRegistration()
        {
            InitializeComponent();
            this.clubRegistrationQuery = new ClubRegistrationQuery();
        }

        public void RefreshListOfClubMembers()
        {
            clubRegistrationQuery.DisplayList();
            dataGridView1.DataSource = clubRegistrationQuery.bindingSource;
        }
    }
}
