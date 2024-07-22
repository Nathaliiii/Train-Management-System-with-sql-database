using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json; // Make sure to add the Newtonsoft.Json NuGet package

namespace TrainWeb.Pages
{
    public class TicketsModel : PageModel
    {
        public List<Tickets> tickets = new List<Tickets>();


        public async Task<IActionResult> OnGet()
        {
            string url = "https://localhost:44310/api/Ticket";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    tickets = JsonConvert.DeserializeObject<List<Tickets>>(jsonString);
                }
                else
                {
                    Console.WriteLine("Error: " + response.StatusCode);
                }
            }
            return Page();
        }
    }

    public class Tickets
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }

    }
}
