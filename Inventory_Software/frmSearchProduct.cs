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
    public partial class frmSearchProduct : Form
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        ClassDB db = new ClassDB();

        public frmSearchProduct()
        {
            InitializeComponent();
            cn = new MySqlConnection();
            cn.ConnectionString = db.getConnection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmSearchProduct_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            getAllStock();
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

        private void frmSearchProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
}
