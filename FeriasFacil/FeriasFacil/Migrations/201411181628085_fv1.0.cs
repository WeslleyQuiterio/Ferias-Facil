namespace FeriasFacil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fv10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_cargo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Atribuicao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tb_Funcionario",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        DataAdmissao = c.DateTime(nullable: false),
                        Email = c.String(),
                        Telefone = c.String(),
                        Endereco = c.String(),
                        FotoTipo = c.String(),
                        FotoNome = c.String(),
                        Foto = c.Binary(),
                        Matricula = c.String(),
                        CPF = c.String(),
                        GerenciaID = c.Int(nullable: false),
                        CargoID = c.Int(nullable: false),
                        EquipeID = c.Int(nullable: false),
                        Equipe_ID = c.Int(),
                        Gerencia_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tb_cargo", t => t.CargoID, cascadeDelete: true)
                .ForeignKey("dbo.tb_equipe", t => t.Equipe_ID)
                .ForeignKey("dbo.tb_gerencia", t => t.Gerencia_ID)
                .ForeignKey("dbo.tb_equipe", t => t.EquipeID, cascadeDelete: true)
                .ForeignKey("dbo.tb_gerencia", t => t.GerenciaID, cascadeDelete: true)
                .Index(t => t.GerenciaID)
                .Index(t => t.CargoID)
                .Index(t => t.EquipeID)
                .Index(t => t.Equipe_ID)
                .Index(t => t.Gerencia_ID);
            
            CreateTable(
                "dbo.tb_equipe",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        GerenciaID = c.Int(nullable: false),
                        Funcionario_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tb_Funcionario", t => t.Funcionario_ID)
                .ForeignKey("dbo.tb_gerencia", t => t.GerenciaID, cascadeDelete: false)
                .Index(t => t.GerenciaID)
                .Index(t => t.Funcionario_ID);
            
            CreateTable(
                "dbo.tb_gerencia",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Telefone = c.String(),
                        Localizacao = c.String(),
                        Funcionario_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tb_Funcionario", t => t.Funcionario_ID)
                .Index(t => t.Funcionario_ID);
            
            CreateTable(
                "dbo.tb_periodoFerias",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AnoReferencia = c.Int(nullable: false),
                        FuncionarioID = c.Int(nullable: false),
                        DataVingencia = c.DateTime(nullable: false),
                        DataVencimento = c.DateTime(nullable: false),
                        Saldo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tb_Funcionario", t => t.FuncionarioID, cascadeDelete: true)
                .Index(t => t.FuncionarioID);
            
            CreateTable(
                "dbo.tb_solicitacaoFerias",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PeriodoDeFeriasID = c.Int(nullable: false),
                        DataInicial = c.DateTime(nullable: false),
                        DataFinal = c.DateTime(nullable: false),
                        QuantidadeDias = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tb_periodoFerias", t => t.PeriodoDeFeriasID, cascadeDelete: true)
                .Index(t => t.PeriodoDeFeriasID);
            
            CreateTable(
                "dbo.tb_notificacoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Data = c.DateTime(nullable: false),
                        Descricao = c.String(),
                        SolicitacaoFeriasID = c.Int(nullable: false),
                        HistoricoID = c.Int(nullable: false),
                        PeriodoDeFeriasID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tb_historico", t => t.HistoricoID, cascadeDelete: true)
                .ForeignKey("dbo.tb_periodoFerias", t => t.PeriodoDeFeriasID, cascadeDelete: true)
                .ForeignKey("dbo.tb_solicitacaoFerias", t => t.SolicitacaoFeriasID, cascadeDelete: false)
                .Index(t => t.SolicitacaoFeriasID)
                .Index(t => t.HistoricoID)
                .Index(t => t.PeriodoDeFeriasID);
            
            CreateTable(
                "dbo.tb_historico",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tb_opcionaisFerias",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Detalhes = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.OpcionaisFeriasSolicitacaoFerias",
                c => new
                    {
                        OpcionaisFerias_ID = c.Int(nullable: false),
                        SolicitacaoFerias_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OpcionaisFerias_ID, t.SolicitacaoFerias_ID })
                .ForeignKey("dbo.tb_opcionaisFerias", t => t.OpcionaisFerias_ID, cascadeDelete: true)
                .ForeignKey("dbo.tb_solicitacaoFerias", t => t.SolicitacaoFerias_ID, cascadeDelete: true)
                .Index(t => t.OpcionaisFerias_ID)
                .Index(t => t.SolicitacaoFerias_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.tb_solicitacaoFerias", "PeriodoDeFeriasID", "dbo.tb_periodoFerias");
            DropForeignKey("dbo.OpcionaisFeriasSolicitacaoFerias", "SolicitacaoFerias_ID", "dbo.tb_solicitacaoFerias");
            DropForeignKey("dbo.OpcionaisFeriasSolicitacaoFerias", "OpcionaisFerias_ID", "dbo.tb_opcionaisFerias");
            DropForeignKey("dbo.tb_notificacoes", "SolicitacaoFeriasID", "dbo.tb_solicitacaoFerias");
            DropForeignKey("dbo.tb_notificacoes", "PeriodoDeFeriasID", "dbo.tb_periodoFerias");
            DropForeignKey("dbo.tb_notificacoes", "HistoricoID", "dbo.tb_historico");
            DropForeignKey("dbo.tb_periodoFerias", "FuncionarioID", "dbo.tb_Funcionario");
            DropForeignKey("dbo.tb_Funcionario", "GerenciaID", "dbo.tb_gerencia");
            DropForeignKey("dbo.tb_Funcionario", "EquipeID", "dbo.tb_equipe");
            DropForeignKey("dbo.tb_Funcionario", "Gerencia_ID", "dbo.tb_gerencia");
            DropForeignKey("dbo.tb_gerencia", "Funcionario_ID", "dbo.tb_Funcionario");
            DropForeignKey("dbo.tb_equipe", "GerenciaID", "dbo.tb_gerencia");
            DropForeignKey("dbo.tb_Funcionario", "Equipe_ID", "dbo.tb_equipe");
            DropForeignKey("dbo.tb_equipe", "Funcionario_ID", "dbo.tb_Funcionario");
            DropForeignKey("dbo.tb_Funcionario", "CargoID", "dbo.tb_cargo");
            DropIndex("dbo.OpcionaisFeriasSolicitacaoFerias", new[] { "SolicitacaoFerias_ID" });
            DropIndex("dbo.OpcionaisFeriasSolicitacaoFerias", new[] { "OpcionaisFerias_ID" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.tb_notificacoes", new[] { "PeriodoDeFeriasID" });
            DropIndex("dbo.tb_notificacoes", new[] { "HistoricoID" });
            DropIndex("dbo.tb_notificacoes", new[] { "SolicitacaoFeriasID" });
            DropIndex("dbo.tb_solicitacaoFerias", new[] { "PeriodoDeFeriasID" });
            DropIndex("dbo.tb_periodoFerias", new[] { "FuncionarioID" });
            DropIndex("dbo.tb_gerencia", new[] { "Funcionario_ID" });
            DropIndex("dbo.tb_equipe", new[] { "Funcionario_ID" });
            DropIndex("dbo.tb_equipe", new[] { "GerenciaID" });
            DropIndex("dbo.tb_Funcionario", new[] { "Gerencia_ID" });
            DropIndex("dbo.tb_Funcionario", new[] { "Equipe_ID" });
            DropIndex("dbo.tb_Funcionario", new[] { "EquipeID" });
            DropIndex("dbo.tb_Funcionario", new[] { "CargoID" });
            DropIndex("dbo.tb_Funcionario", new[] { "GerenciaID" });
            DropTable("dbo.OpcionaisFeriasSolicitacaoFerias");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.tb_opcionaisFerias");
            DropTable("dbo.tb_historico");
            DropTable("dbo.tb_notificacoes");
            DropTable("dbo.tb_solicitacaoFerias");
            DropTable("dbo.tb_periodoFerias");
            DropTable("dbo.tb_gerencia");
            DropTable("dbo.tb_equipe");
            DropTable("dbo.tb_Funcionario");
            DropTable("dbo.tb_cargo");
        }
    }
}
