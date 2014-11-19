using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FeriasFacil.Models
{
    [Table("tb_gerencia")]
    public class Gerencia
    {
        public Gerencia()
        {
            this.Equipes = new List<Equipe>();
            this.Funcionarios = new List<Funcionario>();
        }           
        public int ID { get; set; }
        [Required(ErrorMessage = "O Nome da Gerência é obrigatório")]
        [MinLength(3, ErrorMessage = "Este nome está muito pequeno")]
        [Display(Name = "Nome da Gerencia")]
        public string Nome { get; set; }
        [Phone]
        public string Telefone { get; set; }
        public string Localizacao { get; set; }
        public Equipe Equipe { get; set; }
        public virtual ICollection<Equipe> Equipes { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}