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
    public partial class ucStockAdjustment : UserControl
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        ClassDB db = new ClassDB();

        public ucStockAdjustment()
        {
            InitializeComponent();
            cn = new MySqlConnection();
            cn.ConnectionString = db.getConnection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cboStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        void loadStock()
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblproduct ORDER BY pname ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["code"].ToString(), dr["barcode"].ToString(), dr["pname"].ToString(), dr["category"].ToString(), dr["description"].ToString(), dr["quantity"].ToString(), dr["price"].ToString(), dr["status"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void ucStockAdjustment_Load(object sender, EventArgs e)
        {
            loadStock();
            getUserCount();
            txtAdjustedBy.Text = frmLogin.fullname;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = dataGridView1.Columns[e.ColumnIndex].Name;
            string code = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            if (ColName == "ColEdit")
            {
                cn.Open();
                cm = new MySqlCommand("SELECT * FROM tblproduct WHERE code=@code AND status = @status", cn);
                cm.Parameters.AddWithValue("@code", code);
                cm.Parameters.AddWithValue("@status", "Active");
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtProductCode.Text = dr["code"].ToString();
                    txtName.Text = dr["pname"].ToString();
                    txtDescription.Text = dr["description"].ToString();
                }
                else
                {
                    dr.Close();
                    cn.Close();
                    MessageBox.Show("The selected product is In-Active", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                dr.Close();
                cn.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Make Adjustment?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtName.Text == String.Empty || txtProductCode.Text == String.Empty || txtDescription.Text == String.Empty || txtReasons.Text == String.Empty || txtAdjustedBy.Text == String.Empty)
                {
                    MessageBox.Show("All fields are required!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (txtQuantity.Text == String.Empty || txtQuantity.Text == "0")
                {
                    MessageBox.Show("Please enter a valid quantity", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (cboAction.Text == String.Empty)
                {
                    MessageBox.Show("Please select a valid action", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (cboAction.Text == "ADD TO STOCK")
                {
                    cn.Open();
                    cm = new MySqlCommand("UPDATE tblproduct SET quantity=quantity + @quantity WHERE code=@code", cn);
                    cm.Parameters.AddWithValue("@code", txtProductCode.Text);
                    cm.Parameters.AddWithValue("@quantity", txtQuantity.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();

                    cn.Open();
                    cm = new MySqlCommand("INSERT INTO tblstockadjustment (code,name,description,reason,action,quantity,adjustedby,date,time) VALUES(@code,@name,@description,@reason,@action,@quantity,@adjustedby,@date,@time)", cn);
                    cm.Parameters.AddWithValue("@code", txtProductCode.Text);
                    cm.Parameters.AddWithValue("@name", txtName.Text);
                    cm.Parameters.AddWithValue("@description", txtDescription.Text);
                    cm.Parameters.AddWithValue("@reason", txtReasons.Text);
                    cm.Parameters.AddWithValue("@action", cboAction.Text);
                    cm.Parameters.AddWithValue("@quantity", txtQuantity.Text);
                    cm.Parameters.AddWithValue("@adjustedby", txtAdjustedBy.Text);
                    cm.Parameters.AddWithValue("@date", dtDate.Text);
                    cm.Parameters.AddWithValue("@time", DateTime.Now.ToShortTimeString());
                    cm.ExecuteNonQuery();
                    cn.Close();

                    loadStock();
                    getUserCount();
                    MessageBox.Show("Stock has been added successfully!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtName.Clear();
                    txtProductCode.Clear();
                    txtQuantity.Text = "0";
                    txtReasons.Clear();
                    cboAction.SelectedIndex = -1;
                    txtDescription.Clear();

                }
                else if (cboAction.Text == "REMOVE FROM STOCK")
                {
                    cn.Open();
                    cm = new MySqlCommand("UPDATE tblproduct SET quantity=quantity - @quantity WHERE code=@code", cn);
                    cm.Parameters.AddWithValue("@code", txtProductCode.Text);
                    cm.Parameters.AddWithValue("@quantity", txtQuantity.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();

                    cn.Open();
                    cm = new MySqlCommand("INSERT INTO tblstockadjustment (code,name,description,reason,action,quantity,adjustedby,date,time) VALUES(@code,@name,@description,@reason,@action,@quantity,@adjustedby,@date,@time)", cn);
                    cm.Parameters.AddWithValue("@code", txtProductCode.Text);
                    cm.Parameters.AddWithValue("@name", txtName.Text);
                    cm.Parameters.AddWithValue("@description", txtDescription.Text);
                    cm.Parameters.AddWithValue("@reason", txtReasons.Text);
                    cm.Parameters.AddWithValue("@action", cboAction.Text);
                    cm.Parameters.AddWithValue("@quantity", txtQuantity.Text);
                    cm.Parameters.AddWithValue("@adjustedby", txtAdjustedBy.Text);
                    cm.Parameters.AddWithValue("@date", dtDate.Text);
                    cm.Parameters.AddWithValue("@time", DateTime.Now.ToShortTimeString());
                    cm.ExecuteNonQuery();
                    cn.Close();

                    loadStock();
                    getUserCount();
                    MessageBox.Show("Stock has been removed successfully!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtName.Clear();
                    txtProductCode.Clear();
                    txtQuantity.Text = "0";
                    txtReasons.Clear();
                    cboAction.SelectedIndex = -1;
                    txtDescription.Clear();
                }
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // this will only allow integers only for the quantity input
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void getUserCount()
        {
            string num = dataGridView1.Rows.Count.ToString();
            lblUserCount.Text = "Total Items Found: " + num;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblproduct WHERE pname LIKE '" + txtSearch.Text + "%' OR code LIKE '" + txtSearch.Text + "%' OR barcode LIKE '" + txtSearch.Text + "%' OR category LIKE '" + txtSearch.Text + "%' ORDER BY pname ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["code"].ToString(), dr["barcode"].ToString(), dr["pname"].ToString(), dr["category"].ToString(), dr["description"].ToString(), dr["quantity"].ToString(), dr["price"].ToString(), dr["status"].ToString());
            }
            dr.Close();
            cn.Close();

            getUserCount();
        }

    }
}
