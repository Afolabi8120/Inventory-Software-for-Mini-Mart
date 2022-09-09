using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Inventory_Software
{
    public partial class frmLogin : Form
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        ClassDB db = new ClassDB();

        public static string username, fullname, usertype, password, email, status;

        public frmLogin()
        {
            InitializeComponent();
            cn = new MySqlConnection();
            cn.ConnectionString = db.getConnection();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        void saveLogs()
        {
            cn.Open();
            cm = new MySqlCommand("INSERT INTO tbllogs (username,date,login,logout) VALUES(@username,@date,@login,@logout)", cn);
            cm.Parameters.AddWithValue("@username", txtUsername.Text);
            cm.Parameters.AddWithValue("@date", DateTime.Now.ToLongDateString());
            cm.Parameters.AddWithValue("@login", DateTime.Now.ToShortTimeString());
            cm.Parameters.AddWithValue("@logout", "");
            cm.ExecuteNonQuery();
            cn.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == String.Empty || txtPassword.Text == String.Empty)
            {
                MessageBox.Show("All fields are required", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                cn.Open();
                cm = new MySqlCommand("SELECT * FROM tbluser WHERE username=@username AND password=@password", cn);
                cm.Parameters.AddWithValue("@username", txtUsername.Text);
                cm.Parameters.AddWithValue("@password", txtPassword.Text);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    username = dr["username"].ToString();
                    fullname = dr["fullname"].ToString();
                    email = dr["email"].ToString();
                    password = dr["password"].ToString();
                    usertype = dr["usertype"].ToString();
                    status = dr["status"].ToString();
                }
                else
                {
                    dr.Close();
                    cn.Close();
                    MessageBox.Show("Username/Password provided is invalid", "LOGIN FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dr.Close();
                cn.Close();

                if (usertype == "Administrator")
                {
                    if (status == "Active")
                    {
                        MessageBox.Show("Welcome, " + fullname, "Hello, " + username, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        saveLogs();
                        this.Hide();
                        frmMainmenu f1 = new frmMainmenu();
                        f1.ShowDialog();
                    }
                }
                else if (usertype == "User")
                {
                    if (status == "Active")
                    {
                        MessageBox.Show("Welcome, " + fullname, "Hello, " + username, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        saveLogs();
                        this.Hide();
                        frmCashier f1 = new frmCashier();
                        f1.ShowDialog();
                    }
                }

                if (usertype == "Administrator")
                {
                    if (status == "In-Active")
                    {
                        MessageBox.Show("Your account has been disabled, Please contact the Admin", "INACTIVE USER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (usertype == "User")
                {
                    if (status == "In-Active")
                    {
                        MessageBox.Show("Your account has been disabled, Please contact the Admin", "INACTIVE USER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
      
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmAbout f1 = new frmAbout();
            f1.ShowDialog();
        }

    }
}
