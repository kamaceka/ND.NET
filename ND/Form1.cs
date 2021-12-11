using System;
using System.Collections;
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
        FruitDataProvider fruits= new FruitDataProvider();
        public Form1()
        {
            InitializeComponent();
            var result = fruits.GetRecentFruits("all");
            SetListFromButton(result);
        }

        
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*var items = listView1.SelectedItems;
            if (items.Count == 0)
        return;


            var item = (Pirkinys)items[0].Tag;
            listBox1.Items.Clear();
            var itemss = fruits.GetRecentFruits("all");
            foreach(var fruit in itemss)
            {
                listBox1.Items.Add(fruit);
            }*/
            

        }
        public void SetListFromButton( List<Models.Root> result)
        {
            listView1.Items.Clear();
            foreach (var item in result)
            {
                ListViewItem i = new ListViewItem(new string[] { item.id.ToString(), item.name.ToString(), item.genus.ToString(),
                    item.family.ToString(), item.order.ToString(), item.nutritions.carbohydrates.ToString(),
                item.nutritions.protein.ToString(), item.nutritions.fat.ToString(), item.nutritions.calories.ToString(),
                item.nutritions.sugar.ToString()}
                    );
                i.Tag = item;
                listView1.Items.Add(i);
            }
            listView1.Sorting = SortOrder.Ascending;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string objTextBox = textBox1.Text;
           //var result; 
           if (radioButton1.Checked == true)
           {
                var result = fruits.GetRecentFruits(objTextBox);
                SetListFromButton(result);
            }
            if (radioButton2.Checked == true)
            {
                var result  = fruits.GetRecentFruitsOfFamily(objTextBox);
                SetListFromButton(result);
            }
            if (radioButton3.Checked == true)
            {
                var result = fruits.GetRecentSugaryFruits(Convert.ToDouble(objTextBox));
                SetListFromButton(result);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            var result = fruits.GetRecentFruits("all");
            SetListFromButton(result);
        }
    }
}
