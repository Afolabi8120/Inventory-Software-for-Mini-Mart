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
    public partial class frmReportRecord : Form
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        ClassDB db = new ClassDB();

        public frmReportRecord()
        {
            InitializeComponent();
            cn = new MySqlConnection();
            cn.ConnectionString = db.getConnection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            frmMainmenu uc = new frmMainmenu();
            uc.Show();
        }

        // this will fetch all the log history
        void getLogHistory()
        {
            datagridLogs.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tbllogs ORDER BY username ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                datagridLogs.Rows.Add(i, dr["username"].ToString(), dr["date"].ToString(), dr["login"].ToString(), dr["logout"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        // this will fetch all the sales history
        void getSalesSummary()
        {
            datagridSalesSummary.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblpayment ORDER BY invoiceno ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                datagridSalesSummary.Rows.Add(i, dr["invoiceno"].ToString(), dr["total"].ToString(), dr["amountpaid"].ToString(), dr["mchange"].ToString(), dr["paymode"].ToString(), dr["date"].ToString(), dr["time"].ToString(), dr["user"].ToString(), dr["status"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        // this will fetch all the stock adjustment history
        void getAdjustmentHistory()
        {
            datagridAdjustmentHistory.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblstockadjustment ORDER BY name ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                datagridAdjustmentHistory.Rows.Add(i, dr["code"].ToString(), dr["name"].ToString(), dr["description"].ToString(), dr["reason"].ToString(), dr["action"].ToString(), dr["quantity"].ToString(), dr["date"].ToString(), dr["time"].ToString(), dr["adjustedby"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        // this will fetch all the stock in the inventory
        void getAllStock()
        {
            datagridStockInventory.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblproduct ORDER BY pname ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                datagridStockInventory.Rows.Add(i, dr["code"].ToString(), dr["barcode"].ToString(), dr["pname"].ToString(), dr["category"].ToString(), dr["description"].ToString(), dr["quantity"].ToString(), dr["price"].ToString(), dr["status"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        // this will fetch all the stock in history
        void getStockInHistory()
        {
            datagridStockInHistory.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblstockhistory ORDER BY pname ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                datagridStockInHistory.Rows.Add(i, dr["referenceno"].ToString(), dr["code"].ToString(), dr["pname"].ToString(), dr["price"].ToString(), dr["quantity"].ToString(), dr["total"].ToString(), dr["supplier_name"].ToString(), dr["receivedby"].ToString(), dr["date"].ToString(), dr["status"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void frmReportRecord_Load(object sender, EventArgs e)
        {
            getAdjustmentHistory();
            //getStockInHistory();
            getAllStock();
            getSalesSummary();
            getLogHistory();
        }

        // this is use to search for stoct adjustment history
        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            datagridAdjustmentHistory.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblstockadjustment WHERE date BETWEEN '" + dtFrom.Text + "' AND '" + dtTo.Text + "' ORDER BY name ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                datagridAdjustmentHistory.Rows.Add(i, dr["code"].ToString(), dr["name"].ToString(), dr["description"].ToString(), dr["reason"].ToString(), dr["action"].ToString(), dr["quantity"].ToString(), dr["date"].ToString(), dr["time"].ToString(), dr["adjustedby"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmStockAdjustmentReport f1 = new frmStockAdjustmentReport();
            f1.dtFrom = dtFrom.Text;
            f1.dtTo = dtTo.Text;
            f1.LoadHeader();
            f1.LoadStockAdjustmentHistory();
            f1.ShowDialog();
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void datagridAdjustmentHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        // this is use to search for stock in history
        private void dtToStockIn_ValueChanged(object sender, EventArgs e)
        {
            cboStockInHistory.Items.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT DISTINCT(referenceno) FROM tblstockhistory WHERE date BETWEEN '" + dtFromStockIn.Text + "' AND '" + dtToStockIn.Text + "' ORDER BY pname ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                cboStockInHistory.Items.Add(dr["referenceno"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void btnPrintStockIn_Click(object sender, EventArgs e)
        {
            frmStockInHistoryReport f1 = new frmStockInHistoryReport();
            f1.refno = cboStockInHistory.Text;
            f1.LoadHeader();
            f1.LoadStockInHistory();
            f1.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            datagridStockInventory.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblproduct WHERE code LIKE '" + txtSearch.Text + "%' OR barcode LIKE '" + txtSearch.Text + "%' OR category LIKE '" + txtSearch.Text + "%' OR pname LIKE '" + txtSearch.Text + "%'  ORDER BY pname ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                datagridStockInventory.Rows.Add(i, dr["code"].ToString(), dr["barcode"].ToString(), dr["pname"].ToString(), dr["category"].ToString(), dr["description"].ToString(), dr["quantity"].ToString(), dr["price"].ToString(), dr["status"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void btnPrintStockInventory_Click(object sender, EventArgs e)
        {
            frmAllStockReport f1 = new frmAllStockReport();
            f1.dtSearch = txtSearch.Text;
            f1.LoadHeader();
            f1.LoadAllStock();
            f1.ShowDialog();
        }

        private void btnPrintAllStockInventory_Click(object sender, EventArgs e)
        {
            frmAllStockReport f1 = new frmAllStockReport();
            f1.dtSearch = txtSearch.Text;
            f1.LoadHeader();
            f1.LoadAllStock2();
            f1.ShowDialog();
        }

        private void dtToSalesSummary_ValueChanged(object sender, EventArgs e)
        {
            datagridSalesSummary.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblpayment WHERE date BETWEEN '" + dtFromSalesSummary.Text + "' AND '" + dtToSalesSummary.Text + "' ORDER BY invoiceno ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                datagridSalesSummary.Rows.Add(i, dr["invoiceno"].ToString(), dr["total"].ToString(), dr["amountpaid"].ToString(), dr["mchange"].ToString(), dr["paymode"].ToString(), dr["date"].ToString(), dr["time"].ToString(), dr["user"].ToString(), dr["status"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void cboStockInHistory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboStockInHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            datagridStockInHistory.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblstockhistory WHERE referenceno=@referenceno ORDER BY pname ASC", cn);
            cm.Parameters.AddWithValue("@referenceno", cboStockInHistory.Text);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                datagridStockInHistory.Rows.Add(i, dr["referenceno"].ToString(), dr["code"].ToString(), dr["pname"].ToString(), dr["price"].ToString(), dr["quantity"].ToString(), dr["total"].ToString(), dr["supplier_name"].ToString(), dr["receivedby"].ToString(), dr["date"].ToString(), dr["status"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        void getStockInHistoryTotal()
        {
            datagridStockInHistory.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblstockhistory WHERE referenceno=@referenceno ORDER BY pname ASC", cn);
            cm.Parameters.AddWithValue("@referenceno", cboStockInHistory.Text);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                datagridStockInHistory.Rows.Add(i, dr["referenceno"].ToString(), dr["code"].ToString(), dr["pname"].ToString(), dr["price"].ToString(), dr["quantity"].ToString(), dr["total"].ToString(), dr["supplier_name"].ToString(), dr["receivedby"].ToString(), dr["date"].ToString(), dr["status"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPaymentReport f1 = new frmPaymentReport();
            f1.dateFrom = dtFromSalesSummary.Text;
            f1.dateTo = dtToSalesSummary.Text;
            f1.LoadHeader();
            f1.LoadPayment();
            f1.ShowDialog();
        }
    }
}
