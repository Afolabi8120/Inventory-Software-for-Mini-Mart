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
using System.IO;

namespace Inventory_Software
{
    public partial class ucProduct : UserControl
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        ClassDB db = new ClassDB();

        public ucProduct()
        {
            InitializeComponent();
            cn = new MySqlConnection();
            cn.ConnectionString = db.getConnection();
        }

        void getCategory()
        {
            cboCategory.Items.Clear();
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblcategory ORDER BY name ASC", cn);
            dr = cm.ExecuteReader();
            while(dr.Read())
            {
                cboCategory.Items.Add(dr["name"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        void generateProductCode()
        {
            cn.Open();
            cm = new MySqlCommand("SELECT COUNT(*) FROM tblproduct", cn);
            string num = cm.ExecuteScalar().ToString();
            cn.Close();

            Random myrand = new Random();
            int rand = myrand.Next(999, 9999999);

            txtProductCode.Text = "P-" + num + rand;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            string barCode = txtBarcode.Text;
            try
            {
                Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                picBarcode.Image = brCode.Draw(barCode, 60);
            }
            catch (Exception ex)
            {

            }
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Save this Data? Click Yes to continue", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Validating Form
                if (txtProductCode.Text == String.Empty || txtName.Text == String.Empty || txtBarcode.Text == String.Empty || txtDescription.Text == String.Empty)
                {
                    MessageBox.Show("All fields are required!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (cboStatus.Text == String.Empty || cboCategory.Text == String.Empty)
                {
                    MessageBox.Show("Please select a valid option!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                
                    // Check if supplier id exist in database
                    cn.Open();
                    cm = new MySqlCommand("SELECT * FROM tblproduct WHERE code = @code", cn);
                    cm.Parameters.AddWithValue("@code", txtProductCode.Text);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        dr.Close();
                        cn.Close();
                        MessageBox.Show("Product Code already exist!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        // Check if email address exist in database
                        cn.Close();
                        cn.Open();
                        cm = new MySqlCommand("SELECT * FROM tblproduct WHERE barcode = @barcode", cn);
                        cm.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                        dr = cm.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows)
                        {
                            dr.Close();
                            cn.Close();
                            MessageBox.Show("Barcode is already in use!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            byte[] bytImage = new byte[0];
                            MemoryStream ms = new System.IO.MemoryStream();
                            Bitmap bmpImage = new Bitmap(picBarcode.Image);

                            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            ms.Seek(0, 0);
                            bytImage = ms.ToArray();
                            ms.Close();

                            // if email address and username does not exist in database, it will save the user's data into the database
                            cn.Close();
                            cn.Open();
                            cm = new MySqlCommand("INSERT INTO tblproduct (code,barcode,pname,category,description,status,quantity,price,picture) VALUES(@code,@barcode,@pname,@category,@description,@status,@quantity,@price,@picture) ", cn);
                            cm.Parameters.AddWithValue("@code", txtProductCode.Text);
                            cm.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                            cm.Parameters.AddWithValue("@pname", txtName.Text);
                            cm.Parameters.AddWithValue("@category", cboCategory.Text);
                            cm.Parameters.AddWithValue("@description", txtDescription.Text);
                            cm.Parameters.AddWithValue("@status", cboStatus.Text);
                            cm.Parameters.AddWithValue("@quantity", "");
                            cm.Parameters.AddWithValue("@price", "");
                            cm.Parameters.AddWithValue("@picture", bytImage);
                            cm.ExecuteNonQuery();
                            cn.Close();
                            MessageBox.Show("Data saved successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            getAllRecord();
                            getUserCount();
                            Clear();
                            generateProductCode();
                            picBarcode.Image = null;
                        }
                    }
                }
            }
        }

        private void searchBy()
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblproduct WHERE pname LIKE '" + txtSearch.Text + "%' OR code LIKE '" + txtSearch.Text + "%' OR barcode LIKE '" + txtSearch.Text + "%' OR category LIKE '" + txtSearch.Text + "%' ORDER BY pname ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["code"].ToString(), dr["barcode"].ToString(), dr["pname"].ToString(), dr["category"].ToString(), dr["description"].ToString(), dr["status"].ToString());
            }
            dr.Close();
            cn.Close();

            getUserCount();
        }

        void Clear()
        {
            txtProductCode.Clear();
            txtBarcode.Clear();
            txtDescription.Clear();
            txtName.Clear();
            txtProductCode.Clear();
            cboCategory.SelectedIndex = -1;
            cboStatus.SelectedIndex = -1;
            generateProductCode();
        }

        private void getUserCount()
        {
            string num = dataGridView1.Rows.Count.ToString();
            lblUserCount.Text = "Total Product: " + num;
        }

        private void getAllRecord()
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblproduct ORDER BY pname ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["code"].ToString(), dr["barcode"].ToString(), dr["pname"].ToString(), dr["category"].ToString(), dr["description"].ToString(), dr["status"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void ucProduct_Load(object sender, EventArgs e)
        {
            getCategory();
            btnUpdate.Enabled = false;
            generateProductCode();
            getAllRecord();
            getUserCount();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            picBarcode.Image = null;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchBy();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Update this Data? Click Yes to continue", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Validating Form
                if (txtProductCode.Text == String.Empty || txtName.Text == String.Empty || txtBarcode.Text == String.Empty || txtDescription.Text == String.Empty)
                {
                    MessageBox.Show("All fields are required!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (cboStatus.Text == String.Empty || cboCategory.Text == String.Empty)
                {
                    MessageBox.Show("Please select a valid option!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {

                    byte[] bytImage = new byte[0];
                    MemoryStream ms = new System.IO.MemoryStream();
                    Bitmap bmpImage = new Bitmap(picBarcode.Image);

                    bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ms.Seek(0, 0);
                    bytImage = ms.ToArray();
                    ms.Close();

                    cn.Open();
                    cm = new MySqlCommand("UPDATE tblproduct SET barcode=@barcode,pname=@pname,category=@category,description=@description,status=@status,picture=@picture WHERE code=@code ", cn);
                    cm.Parameters.AddWithValue("@code", txtProductCode.Text);
                    cm.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                    cm.Parameters.AddWithValue("@pname", txtName.Text);
                    cm.Parameters.AddWithValue("@category", cboCategory.Text);
                    cm.Parameters.AddWithValue("@description", txtDescription.Text);
                    cm.Parameters.AddWithValue("@status", cboStatus.Text);
                    cm.Parameters.AddWithValue("@picture", bytImage);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Data updated successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getAllRecord();
                    getUserCount();
                    Clear();
                    generateProductCode();
                    picBarcode.Image = null;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = dataGridView1.Columns[e.ColumnIndex].Name;
            string code = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            if (ColName == "ColEdit")
            {
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;

                cn.Open();
                cm = new MySqlCommand("SELECT * FROM tblproduct WHERE code = @code", cn);
                cm.Parameters.AddWithValue("@code", code);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtProductCode.Text = dr["code"].ToString();
                    txtBarcode.Text = dr["barcode"].ToString();
                    txtName.Text = dr["pname"].ToString();
                    txtDescription.Text = dr["description"].ToString();
                    cboCategory.Text = dr["category"].ToString();
                    cboStatus.Text = dr["status"].ToString();

                    byte[] data = (byte[])dr["picture"];
                    MemoryStream ms = new MemoryStream(data);
                    picBarcode.Image = Image.FromStream(ms);
                }
                dr.Close();
                cn.Close();
            }
            else if (ColName == "ColDelete")
            {
                if (MessageBox.Show("Delete this data? Click Yes to continue", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new MySqlCommand("DELETE FROM tblproduct WHERE code = @code", cn);
                    cm.Parameters.AddWithValue("@code", code);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Data has been deleted successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getAllRecord();
                    getUserCount();
                    Clear();
                }
            }
        }

        private void cboCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
