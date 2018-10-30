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
        private readonly ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetList()
        {
            return View(_context.Products.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Save(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            TempData["message"] = "Create Success";
            return new RedirectResult("GetList");
        }
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);
            if (!_context.Products.Any())
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult SaveUpdate(Product product)
        {
            var existProduct = _context.Products.Find(product.Id);
            if (!_context.Products.Any())
            {
                return NotFound();
            }

            existProduct.Name = product.Name;
            existProduct.Price = product.Price;
            _context.Products.Update(existProduct);
            _context.SaveChanges();
            TempData["message"] = "Update Success";
            return new RedirectResult("GetList");
        }
        public IActionResult Delete(int id)
        {
            var existProduct = _context.Products.Find(id);
            if (existProduct == null)
            {
                TempData["message"] = "Delete Error";
                return new RedirectResult("GetList");
            }
            _context.Products.Remove(existProduct);
            _context.SaveChanges();
            TempData["message"] = "Delete Success";
            return new RedirectResult("GetList");
        }
    }
}