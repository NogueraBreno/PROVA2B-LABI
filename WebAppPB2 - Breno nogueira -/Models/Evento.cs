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
        string Id;
        [Required(ErrorMessage = "Titulo Obrigatorio")]
        string Titulo;
        [Required(ErrorMessage = "Tipo Obrigatorio")]
        Tipo Tipo;
    }
}