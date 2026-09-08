
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Login_and_Register
{
    public partial class frmLogin : Form
    {
        private static readonly string myConn =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=db_users;Integrated Security=True;TrustServerCertificate=True;";

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Please enter both username and password.",
                    "Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(myConn))
                {
                    con.Open();

                    string query = @"
                        SELECT COUNT(*)
                        FROM tbl_users
                        WHERE username = @username
                        AND password = @password";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add(
                            "@username",
                            SqlDbType.VarChar,
                            50).Value = username;

                        cmd.Parameters.Add(
                            "@password",
                            SqlDbType.VarChar,
                            255).Value = password;

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count == 1)
                        {
                            MessageBox.Show(
                                "Login successful!",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            frmDashboard dashboard = new frmDashboard();
                            dashboard.Show();

                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Wrong username or password.",
                                "Login Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                            txtUsername.Clear();
                            txtPassword.Clear();
                            txtUsername.Focus();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "SQL Server Error:\n\n" +
                    ex.Message +
                    "\n\nDetails:\n" +
                    (ex.InnerException != null
                        ? ex.InnerException.Message
                        : "No additional details."),
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error:\n\n" +
                    ex.Message +
                    "\n\nDetails:\n" +
                    (ex.InnerException != null
                        ? ex.InnerException.Message
                        : "No additional details."),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void chkShowPassword_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister register = new frmRegister();

            register.Show();

            this.Hide();
        }
    }
}
