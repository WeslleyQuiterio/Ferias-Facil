using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FeriasFacil.Models
{
    [Table("tb_periodoFerias")]
    public class PeriodoDeFerias
    {
        public PeriodoDeFerias()
        {
            this.SolicitacoesFerias = new List<SolicitacaoFerias>();
        }
        public int ID { get; set; }
        [Required(ErrorMessage="Ano Referência é Obrigatório")]
        [Range(2014,2030, ErrorMessage="Inoforme um ano entre 2014 a 2030")]     
        public int AnoReferencia { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        [Display(Name="Funcionario")]
        public int FuncionarioID { get; set; }
        [Display(Name="Data da Vingencia")]
        [DataType(DataType.DateTime)]
        public DateTime DataVingencia { get; set; }
        [Display(Name="Data do Vencimento")]
        public DateTime DataVencimento { get; set; } 
        [Range(10,30)]
        public int Saldo { get; set; }
        public ICollection<SolicitacaoFerias> SolicitacoesFerias { get; set; }

        
    }
}