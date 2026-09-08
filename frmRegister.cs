
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Login_and_Register
{
    public partial class frmRegister : Form
    {
        private readonly string myConn =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=db_users;Integrated Security=True;";

        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConPassword.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show(
                    "Please fill in all fields.",
                    "Registration Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show(
                    "Passwords do not match.",
                    "Registration Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPassword.Clear();
                txtConPassword.Clear();
                txtPassword.Focus();

                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(myConn))
                {
                    con.Open();

                    // Check if username already exists
                    string checkQuery =
                        "SELECT COUNT(*) FROM tbl_users WHERE username = @username";

                    using (SqlCommand checkCmd =
                        new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.Add(
                            "@username",
                            SqlDbType.VarChar,
                            50).Value = username;

                        int count = Convert.ToInt32(
                            checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show(
                                "That username is already taken.",
                                "Registration Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            txtUsername.Focus();
                            return;
                        }
                    }

                    // Insert new user
                    string insertQuery =
                        "INSERT INTO tbl_users (username, password) " +
                        "VALUES (@username, @password)";

                    using (SqlCommand cmd =
                        new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.Add(
                            "@username",
                            SqlDbType.VarChar,
                            50).Value = username;

                        cmd.Parameters.Add(
                            "@password",
                            SqlDbType.VarChar,
                            255).Value = password;

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Your account has been successfully created.",
                    "Registration Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtUsername.Clear();
                txtPassword.Clear();
                txtConPassword.Clear();

                txtUsername.Focus();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database error:\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unexpected error:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtConPassword.Clear();

            txtUsername.Focus();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();

            this.Close();
        }
    }
}
