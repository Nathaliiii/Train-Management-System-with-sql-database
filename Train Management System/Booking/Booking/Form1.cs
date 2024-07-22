using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;


namespace Booking
{
    public partial class Form1 : Form
    {
        private DataGridView dataGridViewSeats;

        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridViewSeats = new DataGridView();
            dataGridViewSeats.Dock = DockStyle.Fill;
            dataGridViewSeats.ReadOnly = true;
            Controls.Add(dataGridViewSeats);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:44310/api/Seat";
            HttpClient client = new HttpClient();

            try
            {
                Seat seat = new Seat();
                seat.Id = Convert.ToInt32(textBox1.Text);
                seat.SeatNumber = textBox2.Text;
                seat.Price = Convert.ToInt32(textBox3.Text);

                // Serialize seat object to JSON
                string jsonData = JsonConvert.SerializeObject(seat);

                // Create StringContent with JSON data
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Send POST request to the API
                HttpResponseMessage response = await client.PostAsync(url, content);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Seat information added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Load seats
                    LoadSeats();
                }
                else
                {
                    MessageBox.Show("Failed to add seat information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadSeats()
        {
            string url = "https://localhost:44310/api/Seat";
            HttpClient client = new HttpClient();

            try
            {
                // Send GET request to the API to retrieve seat information
                HttpResponseMessage response = await client.GetAsync(url);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseData = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response to a list of seats
                    List<Seat> seats = JsonConvert.DeserializeObject<List<Seat>>(responseData);

                    // Set the DataSource property of dataGridViewSeats to the list of seats
                    dataGridViewSeats.DataSource = seats;
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

        private async void DeleteSeat(int seatId)
        {
            string url = $"https://localhost:44310/api/Seat/{seatId}";
            HttpClient client = new HttpClient();

            try
            {
                // Send DELETE request to the API
                HttpResponseMessage response = await client.DeleteAsync(url);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Seat information deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload seat information after deletion
                    LoadSeats();
                }
                else
                {
                    MessageBox.Show("Failed to delete seat information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            public decimal Price { get; set; }
            // Add any other properties needed for the Seat model
        }
    }
}
