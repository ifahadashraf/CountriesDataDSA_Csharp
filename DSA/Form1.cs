using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSA
{
    public partial class Form1 : Form
    {
        AVLTree countries = new AVLTree();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path;
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                textBoxForPath.Text = path;

                using(var reader = new StreamReader(path))
                {
                    reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        MyNode node = new MyNode();

                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        try
                        {
                            var traders = values[5].Substring(1, values[5].Length - 2).Split(';');

                            node.countryName = values[0];
                            node.gdpGrowth = Convert.ToDouble(values[1]);
                            node.inflation = Convert.ToDouble(values[2]);
                            node.tradeBalance = Convert.ToDouble(values[3]);
                            node.ranking = Convert.ToInt32(values[4]);

                            for (int i = 0; i < traders.Length; i++)
                            {
                                node.tradePartners.Add(traders[i]);
                            }

                            countries.root = countries.insert(countries.root,node);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.StackTrace);
                            break;
                        }
                    }

                    countries.preOrder(countries.root);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UniqueCountries form = new UniqueCountries(countries);
            form.Show();
        }
    }
}
