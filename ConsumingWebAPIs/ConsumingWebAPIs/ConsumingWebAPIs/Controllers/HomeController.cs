using ConsumingWebAPIs.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace ConsumingWebAPIs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult AllUsers()
        {
            Uri baseAddress = new Uri("https://jsonplaceholder.typicode.com/Users");
            HttpClient httpClient= new HttpClient(); //sending calls outside of app; query wont get xecute; wont get external resources
            httpClient.BaseAddress = baseAddress;//LOCATION TO SEND CALL
            HttpResponseMessage response= httpClient.GetAsync(httpClient.BaseAddress).Result;  //get async; program  waits; waits for the response call; recieving the response call
            if(response.IsSuccessStatusCode)//if 200 status code
            {
                string responseString = response.Content.ReadAsStringAsync().Result;//No go further unless all the data is recieved
                ViewBag.Users = JsonConvert.DeserializeObject<List<User>>(responseString); //ViewBag: To send data to view; alternative to model;displaued in the form of list
            }
            return View();
        }
    }
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }  

        [JsonProperty("username")]
        public string Username { get; set; }  

        [JsonProperty("email")]
        public string Email { get; set; }  // Should be string

        [JsonProperty("phone")]
        public string Phone { get; set; }  

        [JsonProperty("website")]
        public string Website { get; set; }  
        public Company Company { get; set; }  
    }
    public class Company
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("catchPhrase")]
        public string CatchPhrase { get; set; }

        [JsonProperty("bs")]
        public string Bs { get; set; }
    }
}
