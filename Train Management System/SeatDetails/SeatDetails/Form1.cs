using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SeatDetails
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

        private void button1_Click(object sender, EventArgs e)
        {
            string url = " https://localhost:44310/api/Seat";
            HttpClient client = new HttpClient();

            Seat seat = new Seat();
            seat.Id = Convert.ToInt32(textBox1.Text); 
            seat.SeatNumber = textBox2.Text; 
            seat.IsAvailable = Convert.ToBoolean(textBox3.Text); 
            seat.Price = Convert.ToDecimal(textBox4.Text);  
            string data = (new JavaScriptSerializer()).Serialize(seat);
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
            string url = "https://localhost:44310/api/Seat"; // Your API endpoint to retrieve train information
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
                    MessageBox.Show("Failed to load seat information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class Seat
        {
            public int Id { get; set; }
            public string SeatNumber { get; set; }
            public bool IsAvailable { get; set; }
            public decimal Price { get; set; }
            // Add any other properties needed for reading a seat
        }

    }
}
