using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerFest.Models
{
    public class viewModelServicoEmpresa
    {
        public Servico servico { get; set; }
        public categoria categoria { get; set; }
        public arquivos arquivos { get; set; }
    }
}