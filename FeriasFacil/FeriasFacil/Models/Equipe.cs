using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FeriasFacil.Models
{
    [Table("tb_equipe")]
    public class Equipe
    {
        public Equipe()
        {
            this.Funcionarios = new List<Funcionario>();
        }
        public int ID { get; set; }
        [Required(ErrorMessage="O Nome da Equipe é obrigatório")]
        [ConcurrencyCheck, MinLength(3, ErrorMessage="Este nome está muito pequeno, ou já existe")]
        [Display(Name="Nome da Equipe")]
        public string Nome { get; set; }
        public virtual Gerencia Gerencia { get; set; }
        [Display(Name="Gerência")]
        public int GerenciaID { get; set; }

        public virtual Funcionario Funcionario { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }


    }
}