using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FeriasFacil.Models
{
    [Table("tb_opcionaisFerias")]
    public class OpcionaisFerias
    {
        public OpcionaisFerias()
        {
            this.SolicitacaoFerias = new List<SolicitacaoFerias>();
        }
        public int ID { get; set; }
        [Required(ErrorMessage="O Nome dos opcionais de ferias é obrigatório")]
        public string Nome { get; set; }
        public string Detalhes { get; set; }
        public bool Status { get; set; }
        public ICollection<SolicitacaoFerias> SolicitacaoFerias { get; set; }
    }
}