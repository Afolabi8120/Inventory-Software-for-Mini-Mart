﻿using System;
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
    public partial class frmBarcodeReport : Form
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        MySqlDataAdapter da;
        ClassDB db = new ClassDB();

        string _Name, _Address, _Phone, _Motto, _Email;
        public string barcode, naira_sign;

        public frmBarcodeReport()
        {
            InitializeComponent();
            cn = new MySqlConnection();
            cn.ConnectionString = db.getConnection();

        }

        private void frmBarcodeReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();

            char x = (char)8358;
            naira_sign = x.ToString();

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

                reportViewer1.LocalReport.ReportPath = Application.StartupPath + "/Reports/BarcodeReport.rdlc";
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
                ReportParameter pNairaSign = new ReportParameter("pNairaSign", naira_sign);

                reportViewer1.LocalReport.SetParameters(pName);
                reportViewer1.LocalReport.SetParameters(pEmail);
                reportViewer1.LocalReport.SetParameters(pPhone);
                reportViewer1.LocalReport.SetParameters(pAddress);
                reportViewer1.LocalReport.SetParameters(pMotto);
                reportViewer1.LocalReport.SetParameters(pNairaSign);

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

        public void LoadBarcode()
        {
            cn.Open();
            da = new MySqlDataAdapter("SELECT * FROM tblproduct WHERE barcode = '" + barcode + "'", cn);
            DataSet1 ds = new DataSet1();
            da.Fill(ds, "dtAllStockReport");

            ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[3]);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            this.reportViewer1.RefreshReport();
            cn.Close();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.reportViewer1.PrintDialog();
        }
    }
}
