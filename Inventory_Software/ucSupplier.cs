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
    public partial class ucSupplier : UserControl
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        ClassDB db = new ClassDB();

        public ucSupplier()
        {
            InitializeComponent();
            cn = new MySqlConnection();
            cn.ConnectionString = db.getConnection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        void generateSupplierID()
        {
            cn.Open();
            cm = new MySqlCommand("SELECT COUNT(*) FROM tblsupplier", cn);
            string num = cm.ExecuteScalar().ToString();
            cn.Close();

            Random myrand = new Random();
            int rand = myrand.Next(9999, 999999);

            txtID.Text = "SUP-" + num + rand;
        }

        private void ucSupplier_Load(object sender, EventArgs e)
        {
            generateSupplierID();
            getAllRecord();
            btnUpdate.Enabled = false;
        }

        private void getAllRecord()
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblsupplier ORDER BY name ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["id"].ToString(), dr["name"].ToString(), dr["phone"].ToString(), dr["email"].ToString(), dr["address"].ToString(), dr["status"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Save this Data? Click Yes to continue", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Validating Form
                if (txtID.Text == String.Empty || txtName.Text == String.Empty || txtPhone.Text == String.Empty || txtEmail.Text == String.Empty)
                {
                    MessageBox.Show("All fields are required!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (cboStatus.Text == String.Empty )
                {
                    MessageBox.Show("Please select a valid option!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    // Check if supplier id exist in database
                    cn.Open();
                    cm = new MySqlCommand("SELECT * FROM tblsupplier WHERE id = @id", cn);
                    cm.Parameters.AddWithValue("@id", txtID.Text);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        dr.Close();
                        cn.Close();
                        MessageBox.Show("Supplier ID already exist!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        // Check if email address exist in database
                        cn.Close();
                        cn.Open();
                        cm = new MySqlCommand("SELECT * FROM tblsupplier WHERE email = @email", cn);
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
                            cm = new MySqlCommand("INSERT INTO tblsupplier (id,name,phone,email,address,status) VALUES(@id,@name,@phone,@email,@address,@status) ", cn);
                            cm.Parameters.AddWithValue("@id", txtID.Text);
                            cm.Parameters.AddWithValue("@name", txtName.Text.ToUpper());
                            cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                            cm.Parameters.AddWithValue("@email", txtEmail.Text);
                            cm.Parameters.AddWithValue("@address", txtAddress.Text);
                            cm.Parameters.AddWithValue("@status", cboStatus.Text);
                            cm.ExecuteNonQuery();
                            cn.Close();
                            MessageBox.Show("Data saved successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            getAllRecord();
                            getUserCount();
                            Clear();
                            generateSupplierID();
                        }
                    }
                }
            }
        }

        void Clear()
        {
            txtID.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            cboStatus.SelectedIndex = -1;
            generateSupplierID();
        }

        private void getUserCount()
        {

            string num = dataGridView1.Rows.Count.ToString();
            lblUserCount.Text = "Total Supplier: " + num;
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
                if (txtID.Text == String.Empty || txtName.Text == String.Empty || txtPhone.Text == String.Empty || txtEmail.Text == String.Empty)
                {
                    MessageBox.Show("All fields are required!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (cboStatus.Text == String.Empty)
                {
                    MessageBox.Show("Please select a valid option!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    cn.Open();
                    cm = new MySqlCommand("UPDATE tblsupplier SET name=@name,phone=@phone,email=@email,address=@address,status=@status WHERE id=@id ", cn);
                    cm.Parameters.AddWithValue("@id", txtID.Text);
                    cm.Parameters.AddWithValue("@name", txtName.Text.ToUpper());
                    cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cm.Parameters.AddWithValue("@email", txtEmail.Text);
                    cm.Parameters.AddWithValue("@address", txtAddress.Text);
                    cm.Parameters.AddWithValue("@status", cboStatus.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Data updated successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getAllRecord();
                    getUserCount();
                    Clear();
                    generateSupplierID();
                    btnUpdate.Enabled = false;
                    btnSave.Enabled = true;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = dataGridView1.Columns[e.ColumnIndex].Name;
            string id = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            if (ColName == "ColEdit")
            {
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;

                cn.Open();
                cm = new MySqlCommand("SELECT * FROM tblsupplier WHERE id = @id", cn);
                cm.Parameters.AddWithValue("@id", id);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtID.Text = dr["id"].ToString();
                    txtName.Text = dr["name"].ToString();
                    txtPhone.Text = dr["phone"].ToString();
                    txtEmail.Text = dr["email"].ToString();
                    txtAddress.Text = dr["address"].ToString();
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
                    cm = new MySqlCommand("DELETE FROM tblsupplier WHERE id = @id", cn);
                    cm.Parameters.AddWithValue("@id", id);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Data has been deleted successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getAllRecord();
                    getUserCount();
                    Clear();
                }
            }
        }

        private void searchBy()
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblsupplier WHERE name LIKE '" + txtSearch.Text + "%' OR email LIKE '" + txtSearch.Text + "%' ORDER BY name ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["id"].ToString(), dr["name"].ToString(), dr["phone"].ToString(), dr["email"].ToString(), dr["address"].ToString(), dr["status"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchBy();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
