using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataObjectLayer;
using MVCPresentationLayer.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ILogicLayer;

using LogicLayer;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.VisualBasic;

namespace MVCPresentationLayer.Controllers
{
    public class ProductsController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private IProductsManager productManager;

        public ProductsController()
        {
            productManager = new ProductsManager();
        }

        // GET: Products
        public ViewResult Index()
        {
            //return View(await _context.Product.ToListAsync());
            List<Product> products = new List<Product>();
            products = productManager.getAllProducts();
            return View(products);
            //return View();
        }

        // GET: Products/Details/5
        public ViewResult Details(int? id)
        {
            if (id == null)
            {
                return View();
            }

            //var product = await _context.Product
            //    .FirstOrDefaultAsync(m => m.Id == id);
            Product product = new Product();
            product = productManager.getProductsById(id);
            if (product == null)
            {
                return View();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Name,QTY,Price,UPC")] Product product)
        {
            if (ModelState.IsValid)
            {
                bool result = productManager.addProduct(product);
                if (result)
                {
                    return RedirectToAction("index");
                }
                return View(product);
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public ViewResult Edit(int? id)
        {
            if (id == null)
            {
                return View();
            }
            Product product = new Product();
            product = productManager.getProductsById(id);
            return View(product);
            //var product = await _context.Product.FindAsync(id);
            //if (product == null)
            //{
            //    return NotFound();
            //}
            //return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Name,QTY,Price,UPC")] Product product)
        {
            if (id != product.Id)
            {
                return View();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ViewBag.test = product.Price;
                    int result = productManager.updateProduct(product);
                    if (result == 1)
                    {
                        return RedirectToAction("index");
                    }else
                    {
                        return View(product);
                    }
                        
                }
                catch (Exception)
                {
                    throw;
                }
                //return await RedirectToAction(nameof(Index));
                //return View();
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ViewResult Delete(int? id)
        {
            if (id == null)
            {
                return View();
            }

            //var product = await _context.Product
            //    .FirstOrDefaultAsync(m => m.Id == id);
            Product product = new Product();
            product = productManager.getProductsById(id);
            if (product == null)
            {
                return View();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool result = productManager.deleteProduct(id);
            if (result)
            {
                return RedirectToAction("index");
            }
            Product product = productManager.getProductsById(id);
            return View(product);
        }

        private bool ProductExists(int id)
        {
            //return _context.Product.Any(e => e.Id == id);
            return true;
        }
    }
}
