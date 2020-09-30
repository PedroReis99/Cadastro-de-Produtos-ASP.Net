using AppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppMVC.Controllers
{
    public class ProductController : Controller
    {
        UnitOfWork.UnitOfWorkApp _wow;
        public ProductController()
        {
            _wow = new UnitOfWork.UnitOfWorkApp();
        }

        // GET: Product
        public ActionResult Index()
        {
            return View(_wow.ProductRepository.FindAll());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View(_wow.ProductRepository.FindById(id));
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                // TODO: Add insert logic here
                _wow.ProductRepository.Add(product);
                _wow.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_wow.ProductRepository.FindById(id));
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                // TODO: Add update logic here
                _wow.ProductRepository.Edit(product);
                _wow.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_wow.ProductRepository.FindById(id));
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _wow.ProductRepository.Remove(_wow.ProductRepository.FindById(id));
                _wow.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
