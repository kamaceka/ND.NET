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


namespace ND
{
    public partial class Form1 : Form
    {
        
        FruitDataProvider fruits= new FruitDataProvider();
        public Form1()
        {
            InitializeComponent();
            var result = fruits.GetRecentFruits("all");
            SetListFromButton(result);
            
            
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
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
            
            try
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
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please write keyword or digits by category and not leave space");
                

            }
            //listView1.Sorting = SortOrder.Ascending;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string objTextBox = textBox1.Text;
            FruitRepository repository = new FruitRepository(fruits);
           //var result; 
           if (radioButton1.Checked == true)
           {
                var result = fruits.GetRecentFruitsOfGenus(objTextBox);
                SetListFromButton(result);
                textBox2.Text = "Fun fact: " + repository.FruitProtein(objTextBox).name.ToString() + " has \nthe most  protein in this\n genus!";

            }
            if (radioButton2.Checked == true)
            {
                var result  = fruits.GetRecentFruitsOfFamily(objTextBox);
                SetListFromButton(result);
                textBox2.Text = "Fun fact: this fruit \n family has " +repository.FruitCountFamily(objTextBox).ToString()+" calories\n in total!";
            }
            if (radioButton3.Checked == true)
            {
                
                var result = fruits.GetRecentSugaryFruits(Convert.ToDouble(objTextBox));
                SetListFromButton(result);
                //max.name + " with "+ max.nutritions.sugar+ "g of sugar"
                textBox2.Text = "Fun fact: the most\n sugary fruit of all is\n " + repository.FruitSugar("all").name.ToString()+
                    " with " + repository.FruitSugar("all").nutritions.sugar.ToString()+
                    "g of sugar in 100g\n of fruit! Sweet!";

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = fruits.GetRecentFruits("all");
            SetListFromButton(result);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
