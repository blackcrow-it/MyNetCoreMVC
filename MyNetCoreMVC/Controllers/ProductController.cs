using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyNetCoreMVC.Models;
using Newtonsoft.Json;

namespace MyNetCoreMVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetList()
        {
            return View();
        }
        public IActionResult Create(string name, int price)
        {
            Product product = new Product
            {
                name = name,
                price = price
            };
            ViewBag.product = product;
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }
        public IActionResult Delete(int id)
        {
            //ViewData["ID"] = id;
            Product product = new Product {
                id = id,
            };
            return Json(product);
        }
    }
}