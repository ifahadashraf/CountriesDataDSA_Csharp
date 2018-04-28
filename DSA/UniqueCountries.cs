using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSA
{
    public partial class UniqueCountries : Form
    {
        AVLTree countries;
        DataTable countriesDataTable;
        public UniqueCountries()
        {
            InitializeComponent();
        }

        public UniqueCountries(AVLTree countries1)
        {
            InitializeComponent();
            this.countries = countries1;
            createDataTable();
            populateDataTable(countries.root);
            countriesDataTable.DefaultView.Sort="CountryName ASC";
            dataGridView1.DataSource = countriesDataTable;
            dataGridView1.Columns["CountryName"].ReadOnly = true;
        }

        private void createDataTable()
        {
            countriesDataTable = new DataTable();
            DataColumn name = new DataColumn("CountryName");
            DataColumn gdp = new DataColumn("GDP");
            DataColumn inflation = new DataColumn("Inflation");
            DataColumn tradeBalance = new DataColumn("Trade Balance");
            DataColumn ranking = new DataColumn("Ranking");
            DataColumn traders = new DataColumn("TradePartners");
            DataColumn height = new DataColumn("Height");
            countriesDataTable.Columns.Add(name);
            countriesDataTable.Columns.Add(gdp);
            countriesDataTable.Columns.Add(inflation);
            countriesDataTable.Columns.Add(tradeBalance);
            countriesDataTable.Columns.Add(ranking);
            countriesDataTable.Columns.Add(traders);
            countriesDataTable.Columns.Add(height);
        }

        public void populateDataTable(MyNode node)
        {
            if (node != null)
            {
                DataRow row = countriesDataTable.NewRow();
                row[0] = node.countryName;
                row[1] = node.gdpGrowth;
                row[2] = node.inflation;
                row[3] = node.tradeBalance;
                row[4] = node.ranking;
                foreach(String s in node.tradePartners)
                {
                    row[5] += s;
                    row[5] += ",";
                }
                row[6] = node.nodeHeight;
                countriesDataTable.Rows.Add(row);
                populateDataTable(node.left);
                populateDataTable(node.right);
            }
        }

        public void updateDataTable(MyNode node,DataRow row)
        {
            if (node != null)
            {
                if(node.countryName.Equals(row[0]))
                {
                    node.countryName = row[0].ToString();
                    node.gdpGrowth = Convert.ToDouble(row[1]);
                    node.inflation = Convert.ToDouble(row[2]);
                    node.tradeBalance = Convert.ToDouble(row[3]);
                    node.ranking = Convert.ToInt32(row[4]);
                    node.tradePartners.Clear();
                    foreach (String s in row[5].ToString().Split(','))
                    {
                        node.tradePartners.Add(s);
                    }
                    node.nodeHeight = Convert.ToInt32(row[6]);
                }
                updateDataTable(node.left,row);
                updateDataTable(node.right,row);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var changedRow = countriesDataTable.Rows[e.RowIndex];
                updateDataTable(countries.root, changedRow);
            }
            catch(Exception ec){}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("CountryName LIKE '{0}%'", textBox1.Text);
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("TradePartners LIKE '%{0}%'", textBox2.Text);
        }
    }
}
