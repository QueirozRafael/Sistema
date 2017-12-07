using SistemaLoja.Models;
using SistemaLoja.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaLoja.Controllers
{
    public class OrdemController : Controller
    {
        private SistemaLojaContext db = new SistemaLojaContext();

        // GET: Ordem
        public ActionResult NovaOrdem()
        {
            var ordemViewModels = new OrdemViewModels();
            ordemViewModels.Customizar = new Customizar();
            ordemViewModels.ProdutosOrdem = new List<ProdutoOrdem>();
            Session["OrdemViewModels"] = ordemViewModels;

            var cliente = new Customizar { Nome = "Selecione um cliente" };
            var clientes = new List<Customizar>();
            clientes.Add(cliente);
            clientes.AddRange(db.Customizars.ToList().OrderBy(x => x.NomeCompleto));
            ViewBag.Clientes = new SelectList(clientes, "CustomizarId", "NomeCompleto");

            return View(ordemViewModels);
        }

        [HttpPost]
        public ActionResult NovaOrdem(OrdemViewModels ordemViewModels)
        {
            ordemViewModels = Session["OrdemViewModels"] as OrdemViewModels;

            var cliente = new Customizar { Nome = "Selecione um cliente" };
            var clientes = new List<Customizar>();
            clientes.Add(cliente);
            clientes.AddRange(db.Customizars.ToList().OrderBy(x => x.NomeCompleto));
            ViewBag.Clientes = new SelectList(clientes, "CustomizarId", "NomeCompleto");

            if(Request["Clientes"] == null)
            {
                ViewBag.Error = "É necessário adicionar um produto";
                return View();
            }

            var clienteId = int.Parse(Request["Clientes"]);

            if (clienteId == 0)
            {
                ViewBag.Error = "Selecione um cliente";
                return View(ordemViewModels);
            }

            //if(ordemViewModels.ProdutosOrdem.Count == 0)
            //{
            //    ViewBag.Clientes = new SelectList(clientes, "CustomizarId", "NomeCompleto", clienteId);

            //    ViewBag.Error = "É necessário adicionar um produto";
            //    return View();
            //}

            var ordemId = 0;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var novaOrdem = new Ordem
                    {
                        DataOrdem = DateTime.Now,
                        CustomizarId = clienteId,
                        OrdemStatus = OrdemStatus.Criada
                    };

                    db.Ordem.Add(novaOrdem);
                    db.SaveChanges();

                    ordemId = db.Ordem.Select(x => x.OrdemId).Max();

                    if (ordemId > 0)
                    {
                        foreach (var item in ordemViewModels.ProdutosOrdem)
                        {

                            var novaOrdemDetalhe = new OrdemDetalhe
                            {
                                OrdemId = ordemId,
                                ProdutoId = item.ProdutoId,
                                Descricao = item.Descricao,
                                Preco = item.Preco,
                                Quantidade = item.Quantidade,
                            };

                            db.OrdemDetalhe.Add(novaOrdemDetalhe);
                            db.SaveChanges();
                        }
                    }

                    transaction.Commit();
                    ViewBag.Error = string.Format("Ordem N°:{0}, criada com sucesso! ", ordemId);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ViewBag.Error = "Falha ao criar a Ordem. " +  ex.Message;
                }
            }
            
            return View(ordemViewModels);
        }
                
        public ActionResult AdicionarProduto()
        {
            //Exibe os produtos para criar a Ordem
            var produto = new Produto { Descricao = "Selecione um produto" };
            var produtos = new List<Produto>();
            produtos.Add(produto);
            produtos.AddRange(db.Produto.OrderBy(x => x.Descricao).ToList());
            ViewBag.Produtos = new SelectList(produtos, "ProdutoId", "Descricao");

            return View();
        }

        [HttpPost]
        public ActionResult AdicionarProduto(ProdutoOrdem produtoOrdem)
        {
            var ordemViewsModels = Session["OrdemViewModels"] as OrdemViewModels;

            var itemProduto = new Produto { Descricao = "Selecione um produto" };
            var itemProdutos = new List<Produto>();
            itemProdutos.Add(itemProduto);
            itemProdutos.AddRange(db.Produto.OrderBy(x => x.Descricao).ToList());
            ViewBag.Produtos = new SelectList(itemProdutos, "ProdutoId", "Descricao");

            var itemClientes = new List<Customizar>();
            itemClientes.Add(new Customizar() { Nome = "Selecione um cliente" });
            itemClientes.AddRange(db.Customizars.ToList().OrderBy(x => x.NomeCompleto));
            var clienteId = Convert.ToInt32(Session["ClienteId"]);
            ViewBag.Clientes = new SelectList(itemClientes, "CustomizarId", "NomeCompleto", clienteId);
            

            var produtoId = int.Parse(Request["Produtos"]);
            
            if (produtoId == 0)
            {
                ViewBag.Error = "Selecione um produto.";
                return View();
            }
            
            if(db.Produto.Find(produtoId) == null)
            {
                ViewBag.Error = "Não existe o produto selecionado.";
            }

            var produtoOrdemExistente = ordemViewsModels.ProdutosOrdem.Find(x => x.ProdutoId == produtoId);
            
            if (produtoOrdemExistente == null)
            {
                var produto = db.Produto.Find(produtoId);

                var novoProdutoOrdem = new ProdutoOrdem
                {
                    ProdutoId = produto.ProdutoId,
                    Descricao = produto.Descricao,
                    Preco = produto.Preco,
                    Quantidade = int.Parse(Request["Quantidade"]),
                };

                ordemViewsModels.ProdutosOrdem.Add(novoProdutoOrdem);
            }
            else
            {
                produtoOrdemExistente.Quantidade += int.Parse(Request["Quantidade"]);
            }
            
            Session["OrdemViewModels"] = ordemViewsModels as OrdemViewModels;

            return View("NovaOrdem", ordemViewsModels);
       }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}