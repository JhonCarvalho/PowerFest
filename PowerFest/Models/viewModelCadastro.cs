using PowerFest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerFest
{
    public partial class viewModelCadastro
    {
        public Usuario Usuario { get; set; }
        public contato contato { get; set; }
        public Empresa empresa { get; set; }

        public string selectedPerfil { get; set; }
        public IEnumerable<dropPerfil> dropPerfil  { get; set; }
        public int id_perfil { get; set; }
    }

    public partial class dropPerfil
    {
        public int    id_perfil { get; set; }
        public string tipo      { get; set; }    

    }
}