
namespace Login_and_Register
{
    partial class frmDashboard
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    20F,
                    System.Drawing.FontStyle.Bold);

            this.lblWelcome.Location =
                new System.Drawing.Point(95, 65);

            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size =
                new System.Drawing.Size(220, 31);

            this.lblWelcome.Text =
                "Welcome!";

            // btnLogout
            this.btnLogout.Location =
                new System.Drawing.Point(140, 135);

            this.btnLogout.Name =
                "btnLogout";

            this.btnLogout.Size =
                new System.Drawing.Size(120, 35);

            this.btnLogout.Text =
                "Logout";

            this.btnLogout.UseVisualStyleBackColor =
                true;

            this.btnLogout.Click +=
                new System.EventHandler(
                    this.btnLogout_Click);

            // frmDashboard
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(6F, 13F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(400, 250);

            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblWelcome);

            this.Name =
                "frmDashboard";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Dashboard";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}