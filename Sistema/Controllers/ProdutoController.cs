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

            return View(produtos);
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            var produto = db.Produto.First(x => x.Id == id);
            return View(produto);
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
            return View(produto);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Produto produto)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var produtoAlterar = db.Produto.First(x => x.Id == id);

                    if(produtoAlterar != null)
                    {
                        produtoAlterar.Descricao = produto.Descricao;
                        produtoAlterar.Preco = produto.Preco;
                        produtoAlterar.UltimaCompra = produto.UltimaCompra;
                        produtoAlterar.Estoque = produto.Estoque;
                        produtoAlterar.Ativo = produto.Ativo;
                        db.SaveChanges();
                    }
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
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Produto produto)
        {
            try
            {
                // TODO: Add delete logic here
                var produtoDeletar = db.Produto.First(x => x.Id == id);
                db.Produto.Remove(produtoDeletar);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
