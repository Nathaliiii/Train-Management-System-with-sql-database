using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json; 

namespace TrainWeb.Pages
{
    public class TrainsModel : PageModel
    {
        public List<Trains> trains = new List<Trains>();


        public async Task<IActionResult> OnGet()
        {
            string url = "https://localhost:44310/api/Train";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    trains = JsonConvert.DeserializeObject<List<Trains>>(jsonString);
                }
                else
                {
                    Console.WriteLine("Error: " + response.StatusCode);
                }
            }
            return Page();
        }
    }

    public class Trains
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
    }
}

    