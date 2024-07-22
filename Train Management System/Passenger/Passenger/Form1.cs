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

namespace Passenger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = " https://localhost:44310/api/Passenger";
            HttpClient client = new HttpClient();

            Passenger passenger = new Passenger();
            passenger.Id = Convert.ToInt32(textBox1.Text);
            passenger.Name = textBox2.Text;
            passenger.Age = Convert.ToInt32(textBox3.Text);
            passenger.Gender = textBox4.Text;
            passenger.Nationality = textBox5.Text;
            string data = (new JavaScriptSerializer()).Serialize(passenger);
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

        private async void Loadtrains()
        {
            string url = "https://localhost:44310/api/Train"; // Your API endpoint to retrieve train information
            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    // Deserialize the JSON response and populate your UI with the train data
                }
                else
                {
                    MessageBox.Show("Failed to load train information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public class Passenger
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
            public string Nationality { get; set; }
            // Add any other properties needed for reading a passenger
        }
    }
}
