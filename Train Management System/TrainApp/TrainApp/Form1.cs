using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Net;
using System.Net.Http;

namespace TrainApp
{
    public partial class Form1 : Form
    {
        int Id;
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Id = Convert.ToInt32(dataGridView1);
            string url = " https://localhost:44310/api/Train" + Id;
            HttpClient client = new HttpClient();
            DialogResult result = MessageBox.Show("Are you sure you want dlete?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var res = client.DeleteAsync(url).Result;
                if (res.IsSuccessStatusCode)
                {
                    Loadtrains();
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = " https://localhost:44310/api/Train";
            HttpClient client = new HttpClient();

            Train train = new Train();
            train.Id = Convert.ToInt32(textBox4.Text);
            train.Name = textBox1.Text;
            train.Type = textBox2.Text;
            train.Capacity = Convert.ToInt32(textBox3.Text);
            string data = (new JavaScriptSerializer()).Serialize(train);
            var content = new
                StringContent(data, UnicodeEncoding.UTF8, "application/json");
            var res = client.PostAsync(url, content).Result;
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Information Added");
                Loadtrains();
            }
            else
            {
                MessageBox.Show("Fail to add information");
            }


        }

        private void Loadtrains()
        {
            throw new NotImplementedException();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public class Train
    {
       
        public int Id { get; set; }

       
        public string Name { get; set; }

        
        public string Type { get; set; }

      
        public int Capacity { get; set; }

    }
}
