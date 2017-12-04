using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppPB2___Breno_nogueira__.Models
{
    public class Evento
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Titulo Obrigatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Descrição Obrigatoria")]
        public string Descricao { get; set; }
        Tipo Tipo;
    }
}