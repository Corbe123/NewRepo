using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NergyLogicTest
{
    public partial class FRM_PRODUCTLIST : Form
    {
        public FRM_PRODUCTLIST()
        {
            InitializeComponent();
        }

        private void FRM_PRODUCTLIST_Load(object sender, EventArgs e)
        {
            try
            {
                FILLPRODUCT();
            }
            catch (Exception ex)
            {

            }

        }
        public void FILLPRODUCT()
        {

            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("NAME", typeof(string));
            table.Columns.Add("PRICE", typeof(int));

            table.Rows.Add(001, "KEYBOARD", 299);
            table.Rows.Add(002, "MOUSE", 199);
            table.Rows.Add(003, "PEN DRIVE", 699);
            table.Rows.Add(004, "CPU", 5500);
            table.Rows.Add(005, "UPS", 2000);
            table.Rows.Add(666, "BAG", 799);
            table.Rows.Add(777, "ADAPTER", 566);
            table.Rows.Add(888, "XX1", 600);
            table.Rows.Add(999, "XX2", 670);
            table.Rows.Add(123, "XX3", 300);
            table.Rows.Add(124, "XX4", 340);
            table.Rows.Add(145, "XX5", 230);
            table.Rows.Add(212, "XX6", 870);
            GD_PRODUCTLIST.DataSource = table;

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GD_PRODUCTLIST_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                GD_PRODUCTLIST.Rows[e.RowIndex].Selected = true;
                TXT_QTY.ReadOnly = false;
            }
            catch (Exception ex)
            {
                TXT_QTY.ReadOnly = true;
            }

        }

        private void GD_PRODUCTLIST_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                GD_PRODUCTLIST.Rows[e.RowIndex].Selected = true;
                TXT_QTY.ReadOnly = false;

            }
            catch (Exception ex)
            {
                TXT_QTY.ReadOnly = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (GD_PRODUCTLIST.SelectedRows.Count == 1)
                {
                    if (TXT_QTY.Text == null || TXT_QTY.Text == "")
                    {
                        MessageBox.Show("Please Input Qantity");
                        TXT_QTY.Focus();
                        TXT_QTY.ReadOnly = false;
                    }
                    else
                    {
                        int selectedrowindex = GD_PRODUCTLIST.SelectedCells[0].RowIndex;

                        DataGridViewRow selectedRow = GD_PRODUCTLIST.Rows[selectedrowindex];

                        string name = Convert.ToString(selectedRow.Cells["NAME"].Value);
                        string price = Convert.ToString(selectedRow.Cells["PRICE"].Value);

                        GD_CART.Rows.Add();
                        GD_CART.Rows[GD_CART.Rows.Count - 1].Cells["ITEM"].Value = name;
                        GD_CART.Rows[GD_CART.Rows.Count - 1].Cells["RATE"].Value = price;
                        GD_CART.Rows[GD_CART.Rows.Count - 1].Cells["QTY"].Value = TXT_QTY.Text;

                        calculate();

                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            txt_netamount.Text = "";
            txt_price.Text = "";
            txt_quantity.Text = "";
           
            TXT_QTY.Text = "";
            TXT_DISC.Text = "";
           

            GD_CART.DataSource = null;

        }
        decimal getvalue(DataGridViewCell cell)
        {
            decimal value;
            if (cell.Value == null)
                value = 0;
            else if (cell.Value.ToString().Trim() == "")
                value = 0;
            else
                value = Convert.ToDecimal(cell.Value);
            return value;
        }
        private void calculate()
        {
            if(GD_CART.Rows.Count>0)
            {
                try
                {
                    decimal price = 0;
                    decimal priceTOT = 0;
                    decimal qty = 0;
                    decimal qtyTOT = 0;
                    foreach (DataGridViewRow row in GD_CART.Rows)
                    {

                        qty = getvalue(row.Cells["QTY"]);
                        price = getvalue(row.Cells["RATE"]);

                        priceTOT += price*qty;
                        qtyTOT += qty;

                    }
                
                    txt_quantity.Text = qtyTOT.ToString();
                    txt_price.Text = priceTOT.ToString();


                }
                catch (Exception ex)
                {

                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
