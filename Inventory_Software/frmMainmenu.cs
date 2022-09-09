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
using System.Windows.Forms.DataVisualization.Charting;

namespace Inventory_Software
{
    public partial class frmMainmenu : Form
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        ClassDB db = new ClassDB();

        public frmMainmenu()
        {
            InitializeComponent();
            cn = new MySqlConnection();
            cn.ConnectionString = db.getConnection();
        }


        private void frmMainmenu_Load(object sender, EventArgs e)
        {
            loadTopSeller();
            loadTopSellingChart();

            ucDashboard uForm = new ucDashboard();
            addUserForm(uForm);

        }

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

        private void addUserForm(UserControl userForm)
        {
            userForm.Dock = DockStyle.Fill;
            panelMainmenu.Controls.Clear();
            panelMainmenu.Controls.Add(userForm);
            userForm.BringToFront();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ucChangePassword uForm = new ucChangePassword();
            addUserForm(uForm);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ucDashboard uForm = new ucDashboard();
            addUserForm(uForm);
        }

        private void btnManageUser_Click(object sender, EventArgs e)
        {
            ucManageUser uForm = new ucManageUser();
            addUserForm(uForm);
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
            if (MessageBox.Show("Are you sure you want to Logout?", "LOGGING OUT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                updateLogs();
                this.Hide();
                frmLogin f1 = new frmLogin();
                f1.ShowDialog();
            }
        }

        private void btnSystemSettings_Click(object sender, EventArgs e)
        {
            ucStoreSettings uc = new ucStoreSettings();
            addUserForm(uc);
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            ucCategory uc = new ucCategory();
            addUserForm(uc);
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            ucSupplier uc = new ucSupplier();
            addUserForm(uc);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ucProduct uc = new ucProduct();
            addUserForm(uc);
        }

        private void btnStockEntry_Click(object sender, EventArgs e)
        {
            ucStockEntry uc = new ucStockEntry();
            addUserForm(uc);
        }

        private void btnStockAdjustment_Click(object sender, EventArgs e)
        {
            ucStockAdjustment uc = new ucStockAdjustment();
            addUserForm(uc);
        }

        private void btnRecordReport_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmReportRecord uc = new frmReportRecord();
            uc.ShowDialog();

        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            frmSystemLock f1 = new frmSystemLock();
            f1.ShowDialog();
        }

        private void btnPrintBarcode_Click(object sender, EventArgs e)
        {
            frmBarcode f1 = new frmBarcode();
            f1.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            getShopName();
            loadTopSeller();
            loadTopSellingChart();
        }

        private void btnChangePassword_Click_1(object sender, EventArgs e)
        {
            frmChangePassword f1 = new frmChangePassword();
            f1.ShowDialog();
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


    }
}
