using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FeriasFacil.Models
{
    [Table("tb_Funcionario")]
    public class Funcionario
    {
        public Funcionario()
        {
            this.PeriodosDeFerias = new List<PeriodoDeFerias>();
        }
        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime DataAdmissao { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string FotoTipo { get; set; }
        public string FotoNome { get; set; }
        public byte[] Foto { get; set; }
        public string Matricula { get; set; }
        public string CPF { get; set; }
        public Gerencia Gerencia { get; set; }
        public int GerenciaID { get; set; }
        public Cargo Cargo { get; set; }
        public int CargoID { get; set; }
        public Equipe Equipe { get; set; }
        public int EquipeID { get; set; }
        public ICollection<PeriodoDeFerias> PeriodosDeFerias { get; set; }

        
    }
}