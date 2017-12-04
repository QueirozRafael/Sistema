using Sistema.Context;
using Sistema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly LojaContext db = new LojaContext();

        // GET: Produto
        public ActionResult Index()
        {
            var produtos = db.Produto.ToList();

            if (produtos.Count > 0)
            {
                return View(produtos);
            }

            return HttpNotFound();
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            var produto = db.Produto.First(x => x.Id == id);

            if(produto != null)
            {
                return View(produto);
            }

            return HttpNotFound();
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    db.Produto.Add(produto);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(produto);
            }
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            var produto = db.Produto.First(x => x.Id == id);

            if(produto != null)
            {
                return View(produto);
            }

            return HttpNotFound();
        }

        // POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(produto).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            var produto = db.Produto.First(x => x.Id == id);

            if(produto != null)
            {
                return View(produto);
            }

            return HttpNotFound();
        }

        // POST: Produto/Delete/5
        [HttpPost]
        public ActionResult Delete(Produto produto)
        {
            try
            {
                // TODO: Add delete logic here
                db.Entry(produto).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
