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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.ID = RegistrationID();

            if (long.TryParse(txtStudentID.Text, out StudentId))
            {

            }
            else
            {
                MessageBox.Show("Invalid Student ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.TryParse(txtAge.Text, out Age))
            {

            }
            else
            {
                MessageBox.Show("Invalid Age format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            this.FirstName = txtFirstName.Text;
            this.MiddleName = txtMiddleName.Text;
            this.LastName = txtLastName.Text;
            this.Gender = cbGender.Text; 
            this.Program = cbProgram.Text; 

            try
            {
                bool isRegistered = clubRegistrationQuery.RegisterStudent(
                    this.ID,
                    this.StudentId,
                    this.FirstName,
                    this.MiddleName,
                    this.LastName,
                    this.Age,
                    this.Gender,
                    this.Program
                );

                if (isRegistered)
                {
                    MessageBox.Show("Successfully registered a member.", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RefreshListOfClubMembers();
                }
                else
                {
                    MessageBox.Show("Registration failed due to database error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during registration: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
