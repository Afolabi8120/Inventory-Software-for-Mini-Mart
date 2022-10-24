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
using System.Diagnostics;

namespace Inventory_Software
{
    public partial class frmCashier : Form
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        ClassDB db = new ClassDB();

        string p_name, p_code, p_price, p_qty;
        public string myinvoiceno;

        bool found;

        public frmCashier()
        {
            InitializeComponent();
            cn = new MySqlConnection();
            cn.ConnectionString = db.getConnection();
            this.lblInvoiceNo.Text = frmCashier.createInvoiceNo();
        }

        string proceName = string.Empty;

        void getShopName()
        {
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblsettings", cn);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                lblStoreName.Text = dr["name"].ToString();
            }
            else
            {
                lblStoreName.Text = "Shop/Company Name";
            }
            dr.Close();
            cn.Close();
        }

        private void frmCashier_Load(object sender, EventArgs e)
        {
            lblInvoiceNo.Text = frmCashier.createInvoiceNo();

            this.KeyPreview = true;
            getShopName();
            getDayEvent();

            txtBarcode.Focus();

            char x = (char)8358;

            lblCashier.Text = frmLogin.username + " | Cashier";

            getCart();
            getItemCount();
            getTotalItemPrice();
        }

        void getDayEvent()
        {
            //Display Good Morning,Good Afternoon and Good Evening Messages
            if (DateTime.Now.Hour < 12) lblDayEvent.Text = "Good Morning, " + frmLogin.username;
            else if (DateTime.Now.Hour < 17) lblDayEvent.Text = "Good Afternoon, " + frmLogin.username;
            else lblDayEvent.Text = "Good Evening, " + frmLogin.username;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
        }

        void updateLogs()
        {
            cn.Open();
            cm = new MySqlCommand("UPDATE tbllogs SET logout=@logout WHERE username =@username AND date=@date", cn);
            cm.Parameters.AddWithValue("@username", frmLogin.username);
            cm.Parameters.AddWithValue("@date", DateTime.Now.ToLongDateString());
            cm.Parameters.AddWithValue("@login", DateTime.Now.ToShortTimeString());
            cm.Parameters.AddWithValue("@logout", DateTime.Now.ToShortTimeString());
            cm.ExecuteNonQuery();
            cn.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (MessageBox.Show("Remove all items from cart before logging out!", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    lblInvoiceNo.Text = createInvoiceNo();
                    getCart();
                }
            }

            if (MessageBox.Show("Are you sure you want to Logout?", "LOGGING OUT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                updateLogs();
                this.Hide();
                frmLogin f1 = new frmLogin();
                f1.Show();
            }
        }

        private void frmCashier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btnProductSearch.PerformClick();
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnSalesHistory.PerformClick();
            }
            else if (e.KeyCode == Keys.F5)
            {
                btnPay.PerformClick();
            }
            else if (e.KeyCode == Keys.F4)
            {
                btnChangePassword.PerformClick();
            }
            else if (e.KeyCode == Keys.F6)
            {
                btnSystemLock.PerformClick();
            }
            else if (e.KeyCode == Keys.F8)
            {
                btnLogout.PerformClick();                
            }
            else if (e.KeyCode == Keys.F12)
            {
                txtBarcode.Focus();
            }
        }

        private void btnSystemLock_Click(object sender, EventArgs e)
        {
            frmSystemLock f1 = new frmSystemLock();
            f1.ShowDialog();
        }

        // generate invoice no
        public static string createInvoiceNo()
        {
            var day = DateTime.Today.Day;
            var month = DateTime.Today.Month;
            var year = DateTime.Today.Year;

            // this will generate number from 0 - 25
            Random stringRand = new Random();
            int resultRand = stringRand.Next(0, 25);

            Random myrand = new Random();
            int rand = myrand.Next(111, 99999);

            var myarray = new String[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
            var result = myarray[resultRand]; // so the number generated from resultRand will be assigned to result
             
            string invoice_no = "IVC" + year + month + day + result + rand;
            
            return invoice_no;
        }

        //SYSTEM PROGRAME OPEN FUNCTION
        private void IsSysProFileOpened()
        {
            try
            {
                if (proceName == "Calc")
                    Process.Start("Calc");
                else if (proceName == "WINWORD")
                    Process.Start("WINWORD");
                else if (proceName == "Notepad.exe")
                    Process.Start("Notepad.exe");
                else
                    proceName = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            try
            {
                proceName = string.Empty;
                proceName = "Calc";
                IsSysProFileOpened();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNotePad_Click(object sender, EventArgs e)
        {
            try
            {
                proceName = string.Empty;
                proceName = "Notepad.exe";
                IsSysProFileOpened();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword f1 = new frmChangePassword();
            f1.ShowDialog();
        }

        private void btnProductSearch_Click(object sender, EventArgs e)
        {
            frmSearchProduct f1 = new frmSearchProduct();
            f1.ShowDialog();
        }

        // this will fetch all the items in the cart according to the invoice no
        public void getCart()
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblcart WHERE invoiceno=@invoiceno ORDER BY pname ASC", cn);
            cm.Parameters.AddWithValue("@invoiceno", lblInvoiceNo.Text);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["pcode"].ToString(), dr["pname"].ToString(), dr["price"].ToString(), dr["qty"].ToString(), dr["total"].ToString());
            }
            dr.Close();
            cn.Close();

            lblItemCount.Text = "0";
            lblSubTotal.Text = "0.00";
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (txtBarcode.Text.Length == 13)
            {
                insertToCart();
            }

        }

        void getTotalItemPrice()
        {
            cn.Open();
            cm = new MySqlCommand("SELECT ifnull(SUM(total), 0) FROM tblcart WHERE invoiceno=@invoiceno", cn);
            cm.Parameters.AddWithValue("@invoiceno", lblInvoiceNo.Text);
            var num = cm.ExecuteScalar().ToString();
            cn.Close();

            lblSubTotal.Text = num.ToString();
            lblTotal.Text = num.ToString();
        }

        void insertToCart()
        {
            string getbarcode = txtBarcode.Text;
            cn.Close();
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblproduct WHERE barcode=@barcode", cn);
            cm.Parameters.AddWithValue("@barcode", txtBarcode.Text);
            cm.Parameters.AddWithValue("@status", "Active");
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                cn.Close();
                cn.Open();
                cm = new MySqlCommand("SELECT * FROM tblproduct WHERE barcode=@barcode AND status=@status", cn);
                cm.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                cm.Parameters.AddWithValue("@status", "Active");
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    cn.Close();
                    cn.Open();
                    cm = new MySqlCommand("SELECT * FROM tblproduct WHERE barcode=@barcode AND quantity > 0", cn);
                    cm.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        p_code = dr["code"].ToString();
                        p_name = dr["pname"].ToString();
                        p_price = dr["price"].ToString();
                        p_qty = dr["quantity"].ToString();

                        found = true;
                    }
                    else
                    {
                        found = false;
                    }
                }
                else
                {
                    cn.Close();
                    dr.Close();
                    txtBarcode.Clear();
                    MessageBox.Show("This Item is In-active, Please make some adjustment", "INACTIVE PRODUCT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                cn.Close();
                dr.Close();
            }
            else
            {
                cn.Close();
                dr.Close();
                txtBarcode.Clear();
                MessageBox.Show("Invalid Product Code", "INVALID PRODUCT CODE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            cn.Close();
            dr.Close();

            if (found == true)
            {
                cn.Close();
                cn.Open();
                cm = new MySqlCommand("SELECT * FROM tblcart WHERE invoiceno=@invoiceno AND pcode=@pcode", cn);
                cm.Parameters.AddWithValue("@invoiceno", lblInvoiceNo.Text);
                cm.Parameters.AddWithValue("@pcode", p_code);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    cn.Close();
                    cn.Open();
                    cm = new MySqlCommand("UPDATE tblcart SET qty= qty + @quantity, total = qty * price WHERE invoiceno=@invoiceno AND pcode=@pcode", cn);
                    cm.Parameters.AddWithValue("@invoiceno", lblInvoiceNo.Text);
                    cm.Parameters.AddWithValue("@pcode", p_code);
                    cm.Parameters.AddWithValue("@quantity", 1);
                    cm.ExecuteNonQuery();
                    cn.Close();

                    cn.Open();
                    cm = new MySqlCommand("UPDATE tblproduct SET quantity= quantity - @quantity WHERE code=@code", cn);
                    cm.Parameters.AddWithValue("@code", p_code);
                    cm.Parameters.AddWithValue("@price", p_price);
                    cm.Parameters.AddWithValue("@quantity", 1);
                    cm.ExecuteNonQuery();
                    cn.Close();

                    getCart();
                    getItemCount();
                    getTotalItemPrice();
                    txtBarcode.Clear();
                }
                else
                {
                    cn.Close();
                    cn.Open();
                    cm = new MySqlCommand("INSERT INTO tblcart (invoiceno,pcode,pname,price,qty,total,user,status,date) VALUES(@invoiceno,@pcode,@pname,@price,@qty,@total,@user,@status,@date)", cn);
                    cm.Parameters.AddWithValue("@invoiceno", lblInvoiceNo.Text);
                    cm.Parameters.AddWithValue("@pcode", p_code);
                    cm.Parameters.AddWithValue("@pname", p_name);
                    cm.Parameters.AddWithValue("@price", p_price);
                    cm.Parameters.AddWithValue("@qty", 1);
                    cm.Parameters.AddWithValue("@total", Convert.ToDecimal(p_price) * 1);
                    cm.Parameters.AddWithValue("@user", frmLogin.username);
                    cm.Parameters.AddWithValue("@status", "PENDING");
                    cm.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());
                    cm.ExecuteNonQuery();
                    cn.Close();

                    cn.Open();
                    cm = new MySqlCommand("UPDATE tblproduct SET quantity= quantity - @quantity WHERE code=@code", cn);
                    cm.Parameters.AddWithValue("@code", p_code);
                    cm.Parameters.AddWithValue("@price", p_price);
                    cm.Parameters.AddWithValue("@quantity", 1);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    getCart();
                    getItemCount();
                    getTotalItemPrice();
                    txtBarcode.Clear();
                }
                cn.Close();
                dr.Close();
                
            }
            else if (found == false)
            {
                cn.Close();
                dr.Close();
                txtBarcode.Clear();
                MessageBox.Show("Item with Barcode " + getbarcode + " is out of stock\nCurrent Available stock is 0", "ITEM OUT OF STOCK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allows numbers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }

        void getItemCount()
        {
            lblItemCount.Text = dataGridView1.Rows.Count.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string ColName = dataGridView1.Columns[e.ColumnIndex].Name;
                string pcode = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string _qty = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

                if (ColName == "ColRemove")
                {
                    if (MessageBox.Show("Remove Item?", "REMOVE ITEM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new MySqlCommand("UPDATE tblproduct SET quantity= quantity + @quantity WHERE code=@code", cn);
                        cm.Parameters.AddWithValue("@code", pcode);
                        cm.Parameters.AddWithValue("@quantity", _qty);
                        cm.ExecuteNonQuery();
                        cn.Close();

                        cn.Open();
                        cm = new MySqlCommand("DELETE FROM tblcart WHERE invoiceno=@invoiceno AND pcode=@pcode", cn);
                        cm.Parameters.AddWithValue("@invoiceno", lblInvoiceNo.Text);
                        cm.Parameters.AddWithValue("@pcode", pcode);
                        cm.ExecuteNonQuery();
                        cn.Close();

                        getCart();
                        getItemCount();
                        getTotalItemPrice();
                    }
                }
                else if (ColName == "ColIncrease")
                {
                    cn.Open();
                    cm = new MySqlCommand("SELECT * FROM tblproduct WHERE code=@code AND quantity > 0", cn);
                    cm.Parameters.AddWithValue("@code", pcode);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        p_qty = dr["quantity"].ToString();

                        cn.Close();
                        cn.Open();
                        cm = new MySqlCommand("UPDATE tblproduct SET quantity= quantity - @quantity WHERE code=@code", cn);
                        cm.Parameters.AddWithValue("@code", pcode);
                        cm.Parameters.AddWithValue("@quantity", 1);
                        cm.ExecuteNonQuery();
                        cn.Close();

                        cn.Open();
                        cm = new MySqlCommand("UPDATE tblcart SET qty= qty + @quantity, total = price * qty WHERE invoiceno=@invoiceno AND pcode=@pcode", cn);
                        cm.Parameters.AddWithValue("@invoiceno", lblInvoiceNo.Text);
                        cm.Parameters.AddWithValue("@pcode", pcode);
                        cm.Parameters.AddWithValue("@quantity", 1);
                        cm.ExecuteNonQuery();
                        cn.Close();


                        getCart();
                        getItemCount();
                        getTotalItemPrice();
                    }
                    else
                    {
                        cn.Close();
                        dr.Close();
                        txtBarcode.Clear();
                        MessageBox.Show("The selected product is out of stock\nCurrent Available stock is 0", "ITEM OUT OF STOCK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    cn.Close();
                    dr.Close();
                }
                else if (ColName == "ColDecrease")
                {
                    if (Int32.Parse(_qty) < 1)
                    {
                        cn.Close();
                        cn.Open();
                        cm = new MySqlCommand("DELETE FROM tblcart WHERE invoiceno=@invoiceno AND pcode=@pcode", cn);
                        cm.Parameters.AddWithValue("@invoiceno", lblInvoiceNo.Text);
                        cm.Parameters.AddWithValue("@pcode", pcode);
                        cm.ExecuteNonQuery();
                        cn.Close();

                        getCart();
                        getItemCount();
                        getTotalItemPrice();
                    }
                    else
                    {
                        cn.Close();
                        cn.Open();
                        cm = new MySqlCommand("UPDATE tblproduct SET quantity= quantity + @quantity WHERE code=@code", cn);
                        cm.Parameters.AddWithValue("@code", pcode);
                        cm.Parameters.AddWithValue("@quantity", 1);
                        cm.ExecuteNonQuery();
                        cn.Close();

                        cn.Open();
                        cm = new MySqlCommand("UPDATE tblcart SET qty= qty - @quantity, total = price * qty WHERE invoiceno=@invoiceno AND pcode=@pcode", cn);
                        cm.Parameters.AddWithValue("@invoiceno", lblInvoiceNo.Text);
                        cm.Parameters.AddWithValue("@pcode", pcode);
                        cm.Parameters.AddWithValue("@quantity", 1);
                        cm.ExecuteNonQuery();
                        cn.Close();


                        getCart();
                        getItemCount();
                        getTotalItemPrice();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSalesHistory_Click(object sender, EventArgs e)
        {
            frmSalesHistory f1 = new frmSalesHistory();
            f1.ShowDialog();
        }

        private void txtAmountPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal change = Convert.ToDecimal(txtAmountPaid.Text) - Convert.ToDecimal(lblTotal.Text);

                lblChange.Text = change.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void txtAmountPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allows numbers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cboPaymentMode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            saveTransaction();
        }

        void saveTransaction()
        {
            if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("Cart is empty", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (lblTotal.Text == "0.00" || lblTotal.Text == "0" || lblTotal.Text == String.Empty || txtAmountPaid.Text == "0.00" || txtAmountPaid.Text == "0" || txtAmountPaid.Text == "")
            {
                MessageBox.Show("Can't proceed with transaction, Please Enter a Valid Amount to Pay", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (cboPaymentMode.Text == String.Empty)
            {
                MessageBox.Show("Please select a valid payment mode", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (Convert.ToDecimal(lblChange.Text) < 0)
            {
                MessageBox.Show("Insufficient Amount, Please Enter a Valid Amount", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (MessageBox.Show("Do you want to proceed with this transaction?\nNOTE: This transaction cannot be reverse!", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new MySqlCommand("INSERT INTO tblpayment (invoiceno,total,amountpaid,mchange,paymode,date,time,user,status) VALUES(@invoiceno,@total,@amountpaid,@mchange,@paymode,@date,@time,@user,@status)", cn);
                    cm.Parameters.AddWithValue("@invoiceno", lblInvoiceNo.Text);
                    cm.Parameters.AddWithValue("@total", lblTotal.Text);
                    cm.Parameters.AddWithValue("@amountpaid", txtAmountPaid.Text);
                    cm.Parameters.AddWithValue("@mchange", lblChange.Text);
                    cm.Parameters.AddWithValue("@paymode", cboPaymentMode.Text);
                    cm.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());
                    //cm.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd").ToString());
                    cm.Parameters.AddWithValue("@time", DateTime.Now.ToShortTimeString());
                    cm.Parameters.AddWithValue("@user", frmLogin.username);
                    cm.Parameters.AddWithValue("@status", "COMPLETED");
                    cm.ExecuteNonQuery();
                    cn.Close();

                    cn.Open();
                    cm = new MySqlCommand("UPDATE tblcart SET status=@status WHERE invoiceno=@invoiceno", cn);
                    cm.Parameters.AddWithValue("@invoiceno", lblInvoiceNo.Text);
                    cm.Parameters.AddWithValue("@status", "COMPLETED");
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Transaction has been saved successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //if (MessageBox.Show("Print Receipt?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //{
                    //    createInvoiceNo();
                    //    frmPaymentReceipt fpay = new frmPaymentReceipt();
                    //    fpay.invoiceno = this.lblInvoiceNo.Text;
                    //    fpay.ShowDialog();
                    //}
                    createInvoiceNo();
                    frmPaymentReceipt fpay = new frmPaymentReceipt();
                    fpay.invoiceno = this.lblInvoiceNo.Text;
                    fpay.ShowDialog();

                    lblInvoiceNo.Text = createInvoiceNo();
                    getCart();
                    lblItemCount.Text = "0";
                    lblSubTotal.Text = "0.00";
                    lblTotal.Text = "0.00";
                    cboPaymentMode.SelectedIndex = -1;
                    txtAmountPaid.Text = "0.00";
                    lblChange.Text = "0.00";
                }
            }

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmAbout f1 = new frmAbout();
            f1.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
