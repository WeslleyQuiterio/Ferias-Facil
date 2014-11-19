using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FeriasFacil.Models
{
    [Table("tb_notificacoes")]
    public class Notificacoes
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public SolicitacaoFerias SolicitacaoFerias { get; set; }
        public int SolicitacaoFeriasID { get; set; }
        public Historico Historico { get; set; }
        public int HistoricoID { get; set; }
        public PeriodoDeFerias PeriodoDeFerias { get; set; }
        public int PeriodoDeFeriasID { get; set; }

    }
}