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
    public partial class ucCategory : UserControl
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        ClassDB db = new ClassDB();

        public static string catname;

        public ucCategory()
        {
            InitializeComponent();
            cn = new MySqlConnection();
            cn.ConnectionString = db.getConnection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        // this will fetch al the datas into the datagrid
        private void getAllRecord()
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblcategory ORDER BY name ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["name"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Save this Data? Click Yes to continue", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Validating Form
                if (txtName.Text == String.Empty)
                {
                    MessageBox.Show("All fields are required!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    cn.Open();
                    cm = new MySqlCommand("SELECT * FROM tblcategory WHERE name =@name ", cn);
                    cm.Parameters.AddWithValue("@name", txtName.Text);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        dr.Close();
                        cn.Close();
                        MessageBox.Show("Category Name Already Exist", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        cn.Close();
                        cn.Open();
                        cm = new MySqlCommand("INSERT INTO tblcategory (name) VALUES(@name) ", cn);
                        cm.Parameters.AddWithValue("@name", txtName.Text.ToUpper());
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Category saved successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getAllRecord();
                        getCategoryCount();
                    }
                    dr.Close();
                    cn.Close();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Update this Data? Click Yes to continue", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Validating Form
                if (txtName.Text == String.Empty)
                {
                    MessageBox.Show("All fields are required!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    cn.Open();
                    cm = new MySqlCommand("UPDATE tblcategory SET name=@name WHERE name=@catname ", cn);
                    cm.Parameters.AddWithValue("@name", txtName.Text.ToUpper());
                    cm.Parameters.AddWithValue("@catname", catname);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Category updated successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getAllRecord();
                    getCategoryCount();
                }
            }
        }

        private void getCategoryCount()
        {

            string num = dataGridView1.Rows.Count.ToString();
            lblUserCount.Text = "Total Category " + num;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = dataGridView1.Columns[e.ColumnIndex].Name;
            string _name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            catname = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            if (ColName == "ColEdit")
            {
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;

                cn.Open();
                cm = new MySqlCommand("SELECT * FROM tblcategory WHERE name = @name", cn);
                cm.Parameters.AddWithValue("@name", _name);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtName.Text = dr["name"].ToString();
                }
                dr.Close();
                cn.Close();
            }
            else if (ColName == "ColDelete")
            {
                if (MessageBox.Show("Delete this data? Click Yes to continue", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new MySqlCommand("DELETE FROM tblcategory WHERE name = @name", cn);
                    cm.Parameters.AddWithValue("@name", _name);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Category has been removed successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getAllRecord();
                    getCategoryCount();
                }
            }
        }

        private void searchBy()
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblcategory WHERE name LIKE '" + txtSearch.Text + "%' ORDER BY name ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["name"].ToString());
            }
            dr.Close();
            cn.Close();

            getCategoryCount();
        }

        private void ucCategory_Load(object sender, EventArgs e)
        {
            getAllRecord();
            getCategoryCount();
            btnUpdate.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchBy();
        }
    }
}
