using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FeriasFacil.Models
{
    [Table("tb_cargo")]
    public class Cargo
    {
        public Cargo()
        {
            this.Funcionarios = new List<Funcionario>();
        }
        public int ID { get; set; }
        [Required(ErrorMessage = "O Nome do Cargo é obrigatório")]
        [ConcurrencyCheck ,MinLength(3, ErrorMessage = "Nome muito curto ou já existente")]
        [Display(Name="Nome do Cargo")]
        public string Nome { get; set; }
        [Required(ErrorMessage="A Atribuição é obrigatória")]
        [Display(Name = "Atribuição")]
        [MinLength(3, ErrorMessage="Texto muito curto")]
        public string Atribuicao { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }

    }
}