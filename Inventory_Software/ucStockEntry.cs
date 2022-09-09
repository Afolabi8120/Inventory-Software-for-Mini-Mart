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
    public partial class ucStockEntry : UserControl
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        ClassDB db = new ClassDB();

        public ucStockEntry()
        {
            InitializeComponent();
            cn = new MySqlConnection();
            cn.ConnectionString = db.getConnection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        // generating reference no
        void getReferenceNo()
        {
            var day = DateTime.Now.Day;
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;

            Random myrand = new Random();
            int rand = myrand.Next(111, 99999);

            txtReferenceNo.Text = "REF" + year + month + day + rand;
        }

        // fetch suppliers datails into the supplier combobox
        void getSupplier()
        {
            cboSupplier.Items.Clear();
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblsupplier WHERE status = 'Active' ORDER BY name ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cboSupplier.Items.Add(dr["name"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void ucStockEntry_Load(object sender, EventArgs e)
        {
            getReferenceNo();
            getSupplier();
            getProductList();
            loadStockEntry();
            txtReceivedBy.Text = frmLogin.fullname;
        }

        private void getProductList()
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblproduct ORDER BY pname ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["code"].ToString(), dr["pname"].ToString(), dr["status"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblsupplier WHERE name = @name", cn);
            cm.Parameters.AddWithValue("@name", cboSupplier.Text);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                txtID.Text = dr["id"].ToString();
                txtPhone.Text = dr["phone"].ToString();
            }
            else
            {
                txtID.Clear();
                txtPhone.Clear();
            }
            dr.Close();
            cn.Close();
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
                    txtProductName.Text = dr["pname"].ToString();
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

        private void txtSellingPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtBuyingPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
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

        void loadStockEntry()
        {
            dataGridView2.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblstockhistory WHERE referenceno=@referenceno ORDER BY date ASC", cn);
            cm.Parameters.AddWithValue("@referenceno", txtReferenceNo.Text);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView2.Rows.Add(i, dr["code"].ToString(), dr["pname"].ToString(), dr["price"].ToString(), dr["quantity"].ToString(), dr["total"].ToString(), dr["status"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void cboPaymentStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (cboSupplier.Text == String.Empty || cboSupplier.Text == String.Empty)
            {
                MessageBox.Show("Please Select a valid Supplier", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (txtProductName.Text == String.Empty || txtProductCode.Text == String.Empty)
            {
                MessageBox.Show("Please fill Product Code/Name", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (txtBuyingPrice.Text == String.Empty || txtBuyingPrice.Text == "0.00" || txtBuyingPrice.Text == "0")
            {
                MessageBox.Show("Please enter a valid buying price", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (txtSellingPrice.Text == String.Empty || txtSellingPrice.Text == "0.00" || txtSellingPrice.Text == "0")
            {
                MessageBox.Show("Please enter a valid selling price", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (txtQuantity.Text == String.Empty || txtQuantity.Text == "0")
            {
                MessageBox.Show("Please enter a valid quantity", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("Add this Item?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new MySqlCommand("SELECT * FROM tblstockhistory WHERE referenceno=@referenceno AND code=@code", cn);
                    cm.Parameters.AddWithValue("@referenceno", txtReferenceNo.Text);
                    cm.Parameters.AddWithValue("@code", txtProductCode.Text);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        cn.Close();
                        cn.Open();
                        cm = new MySqlCommand("UPDATE tblproduct SET quantity= quantity + @quantity WHERE code=@code", cn);
                        cm.Parameters.AddWithValue("@code", txtProductCode.Text);
                        cm.Parameters.AddWithValue("@quantity", txtQuantity.Text);
                        cm.ExecuteNonQuery();
                        cn.Close();

                        cn.Open();
                        cm = new MySqlCommand("UPDATE tblstockhistory SET quantity= quantity + @quantity, price =@price,total = total + @quantity * @price WHERE code=@code", cn);
                        cm.Parameters.AddWithValue("@code", txtProductCode.Text);
                        cm.Parameters.AddWithValue("@quantity", txtQuantity.Text);
                        cm.Parameters.AddWithValue("@price", txtBuyingPrice.Text);
                        cm.ExecuteNonQuery();
                        cn.Close();

                        loadStockEntry();
                        txtProductCode.Text = "";
                        txtProductName.Text = "";
                        txtQuantity.Text = "0";
                        txtBuyingPrice.Text = "0.00";
                        txtSellingPrice.Text = "0.00";
                        txtAmountPaid.Text = "0.00";
                        txtChange.Text = "0.00";
                        txtTotal.Text = "0.00";

                        getTotal();
                    }
                    else
                    {
                        cn.Close();
                        cn.Open();
                        cm = new MySqlCommand("INSERT INTO tblstockhistory (referenceno,code,pname,price,quantity,total,supplier_name,supplier_id,receivedby,date,status) VALUES(@referenceno,@code,@pname,@price,@quantity,@total,@supplier_name,@supplier_id,@receivedby,@date,@status)", cn);
                        cm.Parameters.AddWithValue("@referenceno", txtReferenceNo.Text);
                        cm.Parameters.AddWithValue("@code", txtProductCode.Text);
                        cm.Parameters.AddWithValue("@pname", txtProductName.Text);
                        cm.Parameters.AddWithValue("@price", txtBuyingPrice.Text);
                        cm.Parameters.AddWithValue("@quantity", txtQuantity.Text);
                        cm.Parameters.AddWithValue("@total", Double.Parse(txtBuyingPrice.Text) * Int32.Parse(txtQuantity.Text));
                        cm.Parameters.AddWithValue("@supplier_name", cboSupplier.Text);
                        cm.Parameters.AddWithValue("@supplier_id", txtID.Text);
                        cm.Parameters.AddWithValue("@receivedby", txtReceivedBy.Text);
                        cm.Parameters.AddWithValue("@date", dtDate.Text);
                        cm.Parameters.AddWithValue("@status", "PENDING");
                        cm.ExecuteNonQuery();
                        cn.Close();

                        cn.Open();
                        cm = new MySqlCommand("UPDATE tblproduct SET quantity= quantity + @quantity, price =@price WHERE code=@code", cn);
                        cm.Parameters.AddWithValue("@code", txtProductCode.Text);
                        cm.Parameters.AddWithValue("@quantity", txtQuantity.Text);
                        cm.Parameters.AddWithValue("@price", txtSellingPrice.Text);
                        cm.ExecuteNonQuery();
                        cn.Close();

                        loadStockEntry();
                        txtProductCode.Text = "";
                        txtProductName.Text = "";
                        txtQuantity.Text = "0";
                        txtBuyingPrice.Text = "0.00";
                        txtSellingPrice.Text = "0.00";
                        txtAmountPaid.Text = "0.00";
                        txtChange.Text = "0.00";
                        txtTotal.Text = "0.00";

                        getTotal();
                    }
                    dr.Close();
                    cn.Close();
                }
            }

        }

        // this method will get the sum of the total product
        void getTotal()
        {
            cn.Open();
            cm = new MySqlCommand("SELECT SUM(total) FROM tblstockhistory WHERE referenceno=@referenceno", cn);
            cm.Parameters.AddWithValue("@referenceno", txtReferenceNo.Text);
            string num = cm.ExecuteScalar().ToString();
            cn.Close();

            txtTotal.Text = num;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = dataGridView2.Columns[e.ColumnIndex].Name;
            string code = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            string qty = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();

            if (ColName == "ColRemove")
            {
                if (MessageBox.Show("Remove Item?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new MySqlCommand("UPDATE tblproduct SET quantity= quantity - @quantity WHERE code=@code", cn);
                    cm.Parameters.AddWithValue("@code", code);
                    cm.Parameters.AddWithValue("@quantity", qty);
                    cm.ExecuteNonQuery();
                    cn.Close();

                    cn.Open();
                    cm = new MySqlCommand("DELETE FROM tblstockhistory WHERE referenceno=@referenceno AND code=@code", cn);
                    cm.Parameters.AddWithValue("@referenceno", txtReferenceNo.Text);
                    cm.Parameters.AddWithValue("@code", code);
                    cm.Parameters.AddWithValue("@quantity", qty);
                    cm.ExecuteNonQuery();
                    cn.Close();

                    getTotal();
                    loadStockEntry();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAmountPaid.Text == String.Empty || txtAmountPaid.Text == "0.00" || txtAmountPaid.Text == "0")
            {
                MessageBox.Show("Please enter a valid amount to pay", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (cboPaymentStatus.Text == String.Empty)
            {
                MessageBox.Show("Please select a valid payment status", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("Save this entry?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new MySqlCommand("INSERT INTO tblstockhistory_payment (referenceno,item_total,amountpaid,mchange,payment_status) VALUES(@referenceno,@item_total,@amountpaid,@mchange,@paymentstatus)", cn);
                    cm.Parameters.AddWithValue("@referenceno", txtReferenceNo.Text);
                    cm.Parameters.AddWithValue("@item_total", txtTotal.Text);
                    cm.Parameters.AddWithValue("@amountpaid", txtAmountPaid.Text);
                    cm.Parameters.AddWithValue("@mchange", txtChange.Text);
                    cm.Parameters.AddWithValue("@paymentstatus", cboPaymentStatus.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();

                    cn.Open();
                    cm = new MySqlCommand("UPDATE tblstockhistory SET status=@status WHERE referenceno=@referenceno", cn);
                    cm.Parameters.AddWithValue("@referenceno", txtReferenceNo.Text);
                    cm.Parameters.AddWithValue("@status", "COMPLETED");
                    cm.ExecuteNonQuery();
                    cn.Close();

                    MessageBox.Show("This record has been saved successfully!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    loadStockEntry();
                    txtProductCode.Text = "";
                    txtProductName.Text = "";
                    txtQuantity.Text = "0";
                    txtBuyingPrice.Text = "0.00";
                    txtSellingPrice.Text = "0.00";
                    cboSupplier.SelectedIndex = -1;
                    txtPhone.Clear();
                    txtID.Clear();

                    getReferenceNo();
                    loadStockEntry();

                    getTotal();
                }
            }
        }

        private void txtAmountPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var change = Double.Parse(txtAmountPaid.Text) - Double.Parse(txtTotal.Text);

                txtChange.Text = change.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblproduct WHERE pname LIKE '%" + txtSearch.Text + "%' ORDER BY pname ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["code"].ToString(), dr["pname"].ToString(), dr["status"].ToString());
            }
            dr.Close();
            cn.Close();
        }

    }
}
