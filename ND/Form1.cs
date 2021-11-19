using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace ND
{
    public partial class Form1 : Form
    {
        ManoPirkiniai pirkiniai = new ManoPirkiniai();
        public Form1()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var items = listView1.SelectedItems;
            if (items.Count == 0)
        return;

            var item = (Pirkinys)items[0].Tag;
            listBox1.Items.Clear();

            foreach(var preke in item.Prekes)
            {
                listBox1.Items.Add(preke);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = pirkiniai.Surasti(dateTimePicker1.Value);
            listView1.Items.Clear();
            foreach(var item in result)
            {
                ListViewItem i = new ListViewItem(new string[] { item.Id.ToString(), item.Data.ToString(), item.Kiekis.ToString(), item.Kaina.ToString() }
                    );
                i.Tag = item;
                listView1.Items.Add(i);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
