using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantMvc.Models;

namespace RestaurantMvc.Controllers
{
    public class FoodSellController : Controller
    {
        Uri baseaddress = new Uri("https://localhost:44362/api");
        HttpClient client;
        public FoodSellController()
        {
            client = new HttpClient();
            client.BaseAddress = baseaddress;
        }
        public IActionResult Index()
        {
            List<FoodSell> ls = new List<FoodSell>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/FoodSell").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ls = JsonConvert.DeserializeObject<List<FoodSell>>(data);
            }
            return View(ls);
        }
        public IActionResult GetSell()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Details(FoodSellDetails obj)
        {
            List<FoodSell> ls = new List<FoodSell>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/FoodSell/"+obj.FoodFetchId).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ls = JsonConvert.DeserializeObject<List<FoodSell>>(data);
            }
            return View(ls);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(FoodSell obj)
        {
            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/FoodSell", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}