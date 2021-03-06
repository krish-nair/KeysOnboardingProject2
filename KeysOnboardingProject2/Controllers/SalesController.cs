﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KeysOnboardingProject2.Models;

namespace KeysOnboardingProject2.Controllers
{
    public class SalesController : Controller
    {
        private KeysOnboardingDbContext db = new KeysOnboardingDbContext();

        // GET: ProductSolds
        public ActionResult Index()
        {
            var productSolds = db.ProductSolds.Include(p => p.Customer).Include(p => p.Product).Include(p => p.Store);
            return View(productSolds.ToList());
        }

        // GET: ProductSolds/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name");
            return View();
        }

        // POST: ProductSolds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,CustomerId,StoreId,DateSold")] ProductSold productSold)
        {
            if (ModelState.IsValid)
            {
                db.ProductSolds.Add(productSold);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", productSold.CustomerId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", productSold.ProductId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", productSold.StoreId);
            return View(productSold);
        }

        // GET: ProductSolds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSold productSold = db.ProductSolds.Find(id);
            if (productSold == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", productSold.CustomerId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", productSold.ProductId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", productSold.StoreId);
            return View(productSold);
        }

        // POST: ProductSolds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,CustomerId,StoreId,DateSold")] ProductSold productSold)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productSold).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", productSold.CustomerId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", productSold.ProductId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", productSold.StoreId);
            return View(productSold);
        }

        // GET: ProductSolds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSold productSold = db.ProductSolds.Find(id);
            if (productSold == null)
            {
                return HttpNotFound();
            }
            return View(productSold);
        }

        // POST: ProductSolds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductSold productSold = db.ProductSolds.Find(id);
            db.ProductSolds.Remove(productSold);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //// GET: Sales
        //public ActionResult Index()
        //{
        //    var productSolds = db.ProductSolds.Include(p => p.Customer).Include(p => p.Product).Include(p => p.Store).ToList();
        //    return View(productSolds);
        //}

        //// GET: Sales/Details/5
        //public ActionResult Details(int? id)
        //{
        //    var sales = db.ProductSolds.Include(p => p.Customer)
        //        .Include(p => p.Product)
        //        .Include(p => p.Store)
        //        .SingleOrDefault(p => p.Id == id);

        //    if (sales == null)
        //        return HttpNotFound();

        //    return View(sales);

        //    //if (id == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    //ProductSold productSold = db.ProductSolds.Find(id);
        //    //if (productSold == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    //return View(productSold);
        //}

        //// GET: Sales/Create
        //public ActionResult Create()
        //{
        //    var customerId = new Customer();
        //    var productId = new Product();
        //    var storeId = new Store();
        //    return View();
        //}

        //// POST: Sales/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,ProductId,CustomerId,StoreId")] ProductSold productSold)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Console.WriteLine(productSold);
        //        db.ProductSolds.Add(productSold);

        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    var customerId = new Customer();
        //    var productId = new Product();
        //    var storeId = new Store();

        //    return View(productSold);
        //}

        //// GET: Sales/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ProductSold productSold = db.ProductSolds.Find(id);
        //    if (productSold == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    var customerId = new Customer();
        //    var productId = new Product();
        //    var storeId = new Store();

        //    return View(productSold);
        //}

        //// POST: Sales/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,ProductId,CustomerId,StoreId")] ProductSold productSold)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(productSold).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    var customerId = new Customer();
        //    var productId = new Product();
        //    var storeId = new Store();

        //    return View(productSold);
        //}

        //// GET: Sales/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ProductSold productSold = db.ProductSolds.Find(id);
        //    if (productSold == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(productSold);
        //}

        //// POST: Sales/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ProductSold productSold = db.ProductSolds.Find(id);
        //    db.ProductSolds.Remove(productSold);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
