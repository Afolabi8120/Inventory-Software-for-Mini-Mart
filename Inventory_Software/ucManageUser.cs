using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Inventory_Software
{
    public partial class ucManageUser : UserControl
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        ClassDB db = new ClassDB();
        public ucManageUser()
        {
            InitializeComponent();
            cn = new MySqlConnection();
            cn.ConnectionString = db.getConnection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void getAllRecord()
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tbluser WHERE username != '" + frmLogin.username + "' ORDER BY fullname ASC", cn);
            //cm.Parameters.AddWithValue("@username", frmLogin.username);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["username"].ToString(), dr["fullname"].ToString(), dr["usertype"].ToString(), dr["email"].ToString(), dr["status"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Save this Data? Click Yes to continue", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Validating Form
                if (txtUsername.Text == String.Empty || txtFullname.Text == String.Empty || txtPassword.Text == String.Empty || txtEmail.Text == String.Empty)
                {
                    MessageBox.Show("All fields are required!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (cboStatus.Text == String.Empty || cboUsertype.Text == String.Empty)
                {
                    MessageBox.Show("Please select a valid option!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (txtPassword.Text != txtCPassword.Text) // check if password match
                {
                    MessageBox.Show("Both password do not match", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    // Check if Username already exist in database
                    cn.Open();
                    cm = new MySqlCommand("SELECT * FROM tbluser WHERE username = @username", cn);
                    cm.Parameters.AddWithValue("@username", txtUsername.Text);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        dr.Close();
                        cn.Close();
                        MessageBox.Show("Username is currently not available!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        // Check if email address exist in database
                        cn.Close();
                        cn.Open();
                        cm = new MySqlCommand("SELECT * FROM tbluser WHERE email = @email", cn);
                        cm.Parameters.AddWithValue("@email", txtEmail.Text);
                        dr = cm.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows)
                        {
                            dr.Close();
                            cn.Close();
                            MessageBox.Show("Email is already in use!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            // if email address and username does not exist in database, it will save the user's data into the database
                            cn.Close();
                            cn.Open();
                            cm = new MySqlCommand("INSERT INTO tbluser (username,fullname,password,usertype,email,status) VALUES(@username,@fullname,@password,@usertype,@email,@status) ", cn);
                            cm.Parameters.AddWithValue("@username", txtUsername.Text);
                            cm.Parameters.AddWithValue("@fullname", txtFullname.Text);
                            cm.Parameters.AddWithValue("@password", txtPassword.Text);
                            cm.Parameters.AddWithValue("@usertype", cboUsertype.Text);
                            cm.Parameters.AddWithValue("@email", txtEmail.Text);
                            cm.Parameters.AddWithValue("@status", cboStatus.Text);
                            cm.ExecuteNonQuery();
                            cn.Close();
                            MessageBox.Show("Data saved successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            getAllRecord();
                            getUserCount();
                            Clear();
                        }
                    }
                }
            }
        }

        private void ucManageUser_Load(object sender, EventArgs e)
        {
            getAllRecord();
            getUserCount();
        }

        private void cboUsertype_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Update this Data? Click Yes to continue", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Validating Form
                if (txtUsername.Text == String.Empty || txtFullname.Text == String.Empty || txtPassword.Text == String.Empty || txtEmail.Text == String.Empty)
                {
                    MessageBox.Show("All fields are required!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (cboStatus.Text == String.Empty || cboUsertype.Text == String.Empty)
                {
                    MessageBox.Show("Please select a valid option!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (txtPassword.Text != txtCPassword.Text) // check if password match
                {
                    MessageBox.Show("Both password do not match", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    // if email address and username does not exist in database, it will save the user's data into the database
                    cn.Open();
                    cm = new MySqlCommand("UPDATE tbluser SET fullname=@fullname,password=@password,usertype=@usertype,email=@email,status=@status WHERE username=@username", cn);
                    cm.Parameters.AddWithValue("@username", txtUsername.Text);
                    cm.Parameters.AddWithValue("@fullname", txtFullname.Text);
                    cm.Parameters.AddWithValue("@password", txtPassword.Text);
                    cm.Parameters.AddWithValue("@usertype", cboUsertype.Text);
                    cm.Parameters.AddWithValue("@email", txtEmail.Text);
                    cm.Parameters.AddWithValue("@status", cboStatus.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Data updated successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getAllRecord();
                    getUserCount();
                    Clear();
                    txtUsername.ReadOnly = false;
                    btnUpdate.Enabled = false;
                    btnSave.Enabled = true;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = dataGridView1.Columns[e.ColumnIndex].Name;
            string username = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            if (ColName == "ColEdit")
            {
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                txtUsername.ReadOnly = true;
                cn.Open();
                cm = new MySqlCommand("SELECT * FROM tbluser WHERE username = @username", cn);
                cm.Parameters.AddWithValue("@username", username);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtUsername.Text = dr["username"].ToString();
                    txtFullname.Text = dr["fullname"].ToString();
                    txtPassword.Text = dr["password"].ToString();
                    txtCPassword.Text = dr["password"].ToString();
                    cboUsertype.Text = dr["usertype"].ToString();
                    txtEmail.Text = dr["email"].ToString();
                    cboStatus.Text = dr["status"].ToString();
                }
                dr.Close();
                cn.Close();
            }
            else if (ColName == "ColDelete")
            {
                if (MessageBox.Show("Delete this data? Click Yes to continue", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new MySqlCommand("DELETE FROM tbluser WHERE username = @username", cn);
                    cm.Parameters.AddWithValue("@username", username);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Data has been deleted successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getAllRecord();
                    getUserCount();
                    Clear();
                }
            }
        }

        void Clear()
        {
            txtCPassword.Clear();
            txtEmail.Clear();
            txtFullname.Clear();
            txtPassword.Clear();
            txtUsername.Clear();
            cboStatus.SelectedIndex = -1;
            cboUsertype.SelectedIndex = -1;
            txtUsername.ReadOnly = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.ReadOnly = false;
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            Clear();
        }

        private void searchBy()
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tbluser WHERE fullname LIKE '%" + txtSearch.Text + "' OR usertype LIKE '%" + txtSearch.Text + "' AND username != '" + frmLogin.username + "' ORDER BY fullname ASC", cn);
            //cm.Parameters.AddWithValue("@username", frmLogin.username);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["username"].ToString(), dr["fullname"].ToString(), dr["usertype"].ToString(), dr["email"].ToString(), dr["status"].ToString());
            }
            dr.Close();
            cn.Close();

            getUserCount();
        }

        private void getUserCount()
        {
            string num = dataGridView1.Rows.Count.ToString();
            lblUserCount.Text = "Total User: " + num;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchBy();
            
        }
    }
}
