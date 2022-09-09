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
using Microsoft.Reporting.WinForms;

namespace Inventory_Software
{
    public partial class frmStockInHistoryReport : Form
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        MySqlDataAdapter da;
        ClassDB db = new ClassDB();

        string _Name, _Address, _Phone, _Motto, _Email;
        public string refno;

        public frmStockInHistoryReport()
        {
            InitializeComponent();
            cn = new MySqlConnection();
            cn.ConnectionString = db.getConnection();
        }

        private void frmStockInHistoryReport_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
            //LoadStockInHistory();
            //LoadHeader();
        }

        public void LoadStockInHistory()
        {
            cn.Open();
            da = new MySqlDataAdapter("SELECT s.referenceno,s.code,s.pname,s.price,s.quantity,s.total,s.supplier_name,s.supplier_id,s.receivedby,s.date,s.status,p.item_total,p.amountpaid,p.mchange,p.payment_status FROM tblstockhistory AS s INNER JOIN tblstockhistory_payment AS p ON s.referenceno = p.referenceno WHERE s.referenceno = '" + refno + "' ORDER BY pname ASC", cn);
            DataSet1 ds = new DataSet1();
            da.Fill(ds, "dtStockInHistory");

            ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[2]);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            this.reportViewer1.RefreshReport();
            cn.Close();
        }

        public void LoadHeader()
        {
            ReportDataSource rptDS = new ReportDataSource();
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM tblsettings", cn);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                _Name = dr["name"].ToString();
                _Phone = dr["phone"].ToString();
                _Email = dr["email"].ToString();
                _Address = dr["address"].ToString();
                _Motto = dr["motto"].ToString();

                dr.Close();
                cn.Close();

                reportViewer1.LocalReport.ReportPath = Application.StartupPath + "/Reports/StockInHistoryReport.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds1 = new DataSet1();
                da = new MySqlDataAdapter();


                cn.Open();
                da.SelectCommand = new MySqlCommand("SELECT * FROM tblsettings WHERE name = '" + _Name + "'", cn);
                da.Fill(ds1, "dtName");
                cn.Close();

                ReportParameter pName = new ReportParameter("pName", _Name);
                ReportParameter pEmail = new ReportParameter("pEmail", _Email);
                ReportParameter pPhone = new ReportParameter("pPhone", _Phone);
                ReportParameter pAddress = new ReportParameter("pAddress", _Address);
                ReportParameter pMotto = new ReportParameter("pMotto", _Motto);
                ReportParameter rpRefno = new ReportParameter("rpRefno", refno);
                ReportParameter rpDatePrinted = new ReportParameter("rpDatePrinted", DateTime.Now.ToShortDateString());

                reportViewer1.LocalReport.SetParameters(pName);
                reportViewer1.LocalReport.SetParameters(pEmail);
                reportViewer1.LocalReport.SetParameters(pPhone);
                reportViewer1.LocalReport.SetParameters(pAddress);
                reportViewer1.LocalReport.SetParameters(pMotto);
                reportViewer1.LocalReport.SetParameters(rpRefno);
                reportViewer1.LocalReport.SetParameters(rpDatePrinted);

                rptDS = new ReportDataSource("DataSet1", ("dtName"));
                reportViewer1.LocalReport.DataSources.Add(rptDS);
            }
            else
            {
                _Name = "";
                _Phone = "";
                _Email = "";
                _Address = "";
            }
            dr.Close();
            cn.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.reportViewer1.PrintDialog();
        }
    }
}
