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
            dataGridView1.DataSource = countriesDataTable;
        }

        private void createDataTable()
        {
            countriesDataTable = new DataTable();
            DataColumn name = new DataColumn("Country Name");
            DataColumn gdp = new DataColumn("GDP");
            DataColumn inflation = new DataColumn("Inflation");
            DataColumn tradeBalance = new DataColumn("Trade Balance");
            DataColumn ranking = new DataColumn("Ranking");
            DataColumn traders = new DataColumn("Trade Partners");
            countriesDataTable.Columns.Add(name);
            countriesDataTable.Columns.Add(gdp);
            countriesDataTable.Columns.Add(inflation);
            countriesDataTable.Columns.Add(tradeBalance);
            countriesDataTable.Columns.Add(ranking);
            countriesDataTable.Columns.Add(traders);
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
                countriesDataTable.Rows.Add(row);
                populateDataTable(node.left);
                populateDataTable(node.right);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
