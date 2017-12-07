using SistemaLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaLoja.ViewsModel
{
    public class OrdemViewModels
    {
        public Customizar Customizar { get; set; }

        public ProdutoOrdem ProdutoOrdem { get; set; }

        public List<ProdutoOrdem> ProdutosOrdem { get; set; }

    }
}