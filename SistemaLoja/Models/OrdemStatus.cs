using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLoja.Models
{
    public enum OrdemStatus
    {
        Criada,
        EmProgresso,
        Despachada,
        Entregada
    }
}