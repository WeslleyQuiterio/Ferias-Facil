using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;
using System.Data.Entity;

namespace FeriasFacil.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Cargo> Cargos { get; set; }
        public virtual IDbSet<Equipe> Equipes { get; set; }
        public virtual IDbSet<Funcionario> Funcionarios { get; set; }
        public virtual IDbSet<Gerencia> Gerencias { get; set; }
        public virtual IDbSet<Historico> Historicos { get; set; }
        public virtual IDbSet<Notificacoes> Notificacoes { get; set; }
        public virtual IDbSet<OpcionaisFerias> OpcionaisFerias { get; set; }
        public virtual IDbSet<PeriodoDeFerias> PeriodosDeFerias { get; set; }
        public virtual IDbSet<SolicitacaoFerias> SolicitacoesFerias { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException("modelBuilder");
            }
            // Desligar o comando de Pluralizacao
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Ao desligar a pluralizacao temos um erro grave na definicao das chaves das entidades utilizadas pelo Asp.Identity. Para corrigir isso torna-se necessario reconfigurar estas entidades conforme abaixo:
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

       // public System.Data.Entity.DbSet<FeriasFacil.Models.SolicitacaoFerias> SolicitacoesFerias { get; set; }

       // public System.Data.Entity.DbSet<FeriasFacil.Models.PeriodoDeFerias> PeriodosDeFerias { get; set; }
              
    }
}