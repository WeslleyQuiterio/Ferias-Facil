using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FeriasFacil.Models
{
    [Table("tb_solicitacaoFerias")]
    public class SolicitacaoFerias
    {
        public SolicitacaoFerias()
        {
            this.OpcionaisFerias = new List<OpcionaisFerias>();
            this.Notificacoes = new List<Notificacoes>();
        }
        public int ID { get; set; }
        public PeriodoDeFerias PeriodoDeFerias { get; set; }
        [Display(Name="Ano Referência")]
        public int PeriodoDeFeriasID { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DataInicial { get; set; }  
        [Display(Name="Quantidade de Dias")]
        [Range(10,30, ErrorMessage="Solicite no mínimo 10 e no máximo 30")]
        public int QuantidadeDias { get; set; }
        [DataType(DataType.DateTime, ErrorMessage="Informe uma data válida")]
        [Editable(false)]
        public DateTime DataFinal { get; set; }
        public char Status { get; set; }
        public ICollection<OpcionaisFerias> OpcionaisFerias { get; set; }
        public ICollection<Notificacoes> Notificacoes { get; set; }


    }
}