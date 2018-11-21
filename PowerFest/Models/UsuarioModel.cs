using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PowerFest.Models
{
    public class UsuarioModel
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /*public UsuarioModel()
        {
            this.avaliacao = new HashSet<avaliacao>();
            this.contato = new HashSet<contato>();
        }*/

        public Nullable<System.DateTime> dt_cadastro { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public string perfil { get; set; }
        public int id_usuario { get; set; }
       
        public Nullable<int> id_perfil { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<avaliacao> avaliacao { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<contato> contato { get; set; }
        public virtual Perfil Perfil1 { get; set; }
    }
}