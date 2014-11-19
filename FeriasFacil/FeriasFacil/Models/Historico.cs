using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FeriasFacil.Models
{
    [Table("tb_historico")]
    public class Historico
    {
        public Historico()
        {
            this.Notificacoes = new List<Notificacoes>();
        }
        public int ID { get; set; }
        public DateTime Data { get; set; }        
        public ICollection<Notificacoes> Notificacoes { get; set; }
    }
}