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
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace Inventory_Software
{
    public partial class ucDashboard : UserControl
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        ClassDB db = new ClassDB();

        public ucDashboard()
        {
            InitializeComponent();
            cn = new MySqlConnection();
            cn.ConnectionString = db.getConnection();
        }

        string proceName = string.Empty;

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

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
                datagridSalesSummary.Rows.Add(i, dr["invoiceno"].ToString(), dr["total"].ToString(), dr["paymode"].ToString(), dr["date"].ToString(), dr["time"].ToString(), dr["user"].ToString(), dr["status"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        decimal getTotalSale(string sql)
        {
            cn.Open();
            cm = new MySqlCommand(sql, cn);
            decimal num = decimal.Parse(cm.ExecuteScalar().ToString());
            cn.Close();

            return num;
        }

        // This will fetch all the top 5 sellers
        public void loadTopSeller()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT user, SUM(total) AS total FROM tblcart GROUP BY user ORDER BY user DESC LIMIT 5", cn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Chart");
            chart3.DataSource = ds.Tables["Chart"];
            Series series1 = chart3.Series[0];
            series1.ChartType = SeriesChartType.Pie;

            series1.Name = "TOP 5 SELLERS";

            var chart = chart3;
            chart.Series[series1.Name].XValueMember = "user";
            chart.Series[series1.Name].YValueMembers = "total";

            chart.Series[0].IsValueShownAsLabel = true;
            chart.Series[0].LegendText = "#VALX (#PERCENT)";
        }

        // this will fetch all top 5 selling items
        public void loadTopSellingChart()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT pcode, pname, SUM(qty) AS qty FROM tblcart GROUP BY pcode, pname ORDER BY pname DESC LIMIT 5", cn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Chart");
            chart1.DataSource = ds.Tables["Chart"];
            Series series1 = chart1.Series[0];
            series1.ChartType = SeriesChartType.Pie;

            series1.Name = "TOP 5 SELLING ITEMS";

            var chart = chart1;
            chart.Series[series1.Name].XValueMember = "pname";
            chart.Series[series1.Name].YValueMembers = "qty";

            chart.Series[0].IsValueShownAsLabel = true;
            chart.Series[0].LegendText = "#VALX (#PERCENT)";
        }

        private void ucDashboard_Load(object sender, EventArgs e)
        {
            getDayEvent();
            getAllCategory();
            getAllUsers();
            getAllProduct();
            getAllSupplier();
            getStockOnHand();
            getSalesSummary();
            loadTopSeller();
            loadTopSellingChart();

            char x = (char)8358;

            lblLast7Days.Text = x + " " + getTotalSale("SELECT ifnull(SUM(total), 0) FROM tblpayment WHERE day(now() - 7)");
            lblAllTimeSales.Text = x + " " + getTotalSale("SELECT ifnull(SUM(total), 0) FROM tblpayment");
            lblTodaySales.Text = x + " " + getTotalSale("SELECT ifnull(SUM(total), 0) FROM tblpayment WHERE date = '" + DateTime.Now.ToShortDateString() + "'");
        }

        void getDayEvent()
        {
            //Display Good Morning,Good Afternoon and Good Evening Messages
            if (DateTime.Now.Hour < 12) lblDayEvent.Text = "Good Morning, " + frmLogin.username;
            else if (DateTime.Now.Hour < 17) lblDayEvent.Text = "Good Afternoon, " + frmLogin.username;
            else lblDayEvent.Text = "Good Evening, " + frmLogin.username;
        }

        void getAllSupplier()
        {
            cn.Open();
            cm = new MySqlCommand("SELECT COUNT(*) FROM tblsupplier ", cn);
            string num = cm.ExecuteScalar().ToString();
            cn.Close();

            lblSupplier.Text = num;
        }

        void getStockOnHand()
        {
            cn.Open();
            cm = new MySqlCommand("SELECT SUM(quantity) FROM tblproduct ", cn);
            string num = cm.ExecuteScalar().ToString();
            cn.Close();

            lblStockOnHand.Text = num;
        }

        void getAllProduct()
        {
            cn.Open();
            cm = new MySqlCommand("SELECT COUNT(*) FROM tblproduct ", cn);
            string num = cm.ExecuteScalar().ToString();
            cn.Close();

            lblProduct.Text = num;
        }

        void getAllCategory()
        {
            cn.Open();
            cm = new MySqlCommand("SELECT COUNT(*) FROM tblcategory ", cn);
            string num = cm.ExecuteScalar().ToString();
            cn.Close();

            lblCategory.Text = num;
        }

        void getAllUsers()
        {
            cn.Open();
            cm = new MySqlCommand("SELECT COUNT(*) FROM tbluser ", cn);
            string num = cm.ExecuteScalar().ToString();
            cn.Close();

            lblUsers.Text = num;
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

        private void btnNotepad_Click(object sender, EventArgs e)
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

        private void btnWord_Click(object sender, EventArgs e)
        {
            try
            {
                proceName = string.Empty;
                proceName = "WINWORD";
                IsSysProFileOpened();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            datagridSalesSummary.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblpayment WHERE date BETWEEN '" + dtFrom.Text + "' AND '" + dtTo.Text + "' ORDER BY invoiceno ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                datagridSalesSummary.Rows.Add(i, dr["invoiceno"].ToString(), dr["total"].ToString(), dr["amountpaid"].ToString(), dr["mchange"].ToString(), dr["paymode"].ToString(), dr["date"].ToString(), dr["time"].ToString(), dr["user"].ToString(), dr["status"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            datagridSalesSummary.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblpayment WHERE date BETWEEN '" + dtFrom.Text + "' AND '" + dtTo.Text + "' ORDER BY invoiceno ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                datagridSalesSummary.Rows.Add(i, dr["invoiceno"].ToString(), dr["total"].ToString(), dr["amountpaid"].ToString(), dr["mchange"].ToString(), dr["paymode"].ToString(), dr["date"].ToString(), dr["time"].ToString(), dr["user"].ToString(), dr["status"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            frmPaymentReport f1 = new frmPaymentReport();
            f1.dateFrom = dtFrom.Text;
            f1.dateTo = dtTo.Text;
            f1.LoadHeader();
            f1.LoadPayment();
            f1.ShowDialog();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Back Up Database", "BACK UP DATABASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string constring = "server=localhost;username=root;password=;database=ims_db;";
                string file = "C:ims_db.sql";
                using (MySqlConnection cn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cm = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cm))
                        {
                            cm.Connection = cn;
                            cn.Open();
                            mb.ExportToFile(file);
                            cn.Close();
                            MessageBox.Show("Database Backup Completed...", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Restore Database", "RESTORE DATABASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string constring = "server=localhost;username=root;password=;database=ims_db;";
                string file = "C:ims_db.sql";
                using (MySqlConnection cn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cm = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cm))
                        {
                            cm.Connection = cn;
                            cn.Open();
                            mb.ImportFromFile(file);
                            cn.Close();
                            MessageBox.Show("Database Restore Completed...", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmAbout f1 = new frmAbout();
            f1.ShowDialog();
        }
    }
}
