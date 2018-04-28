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
    public partial class RemoveCountry : Form
    {
        AVLTree countries;
        MyNode toDelete;
        public RemoveCountry()
        {
            InitializeComponent();
        }

        public RemoveCountry(AVLTree countries)
        {
            InitializeComponent();
            this.countries = countries;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void deleteNode(MyNode node,String name)
        {
            if (node != null)
            {
                if (node.countryName.Equals(name))
                    toDelete = node;
                deleteNode(node.left,name);
                deleteNode(node.right,name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            toDelete = null;
            deleteNode(countries.root, name);
            if(toDelete != null)
            {
                countries.deleteNode(countries.root, toDelete);
                MessageBox.Show("Deleted successfully");
            }
            else
            {
                MessageBox.Show("No such country exists");
            }

        }
    }
}
