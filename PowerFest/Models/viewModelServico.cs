using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PowerFest
{
    public partial class viewModelServico
    {
        public Servico servico { get; set; }     
        public arquivos arquivos { get; set; }
        public Empresa empresa { get; set; }
        public Usuario Usuario { get; set; }
        public contato contato { get; set; }
        public avaliacao avaliacao { get; set; }

        [Required(ErrorMessage = "Porfavor selecione a imagem.")]
        [Display(Name = "Imagens do seu serviço")]
        public HttpPostedFileBase[] images { get; set; }

        public IEnumerable<dropPerfil> dropCategoria { get; set; }
        public int id_categoria { get; set; }

    }
    public partial class dropCategoria
    {
        public int id_categoria { get; set; }
        public string tipo { get; set; }

    }
}