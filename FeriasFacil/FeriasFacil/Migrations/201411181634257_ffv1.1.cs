namespace FeriasFacil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ffv11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_equipe", "GerenciaID", "dbo.tb_gerencia");
            AddColumn("dbo.tb_equipe", "Gerencia_ID", c => c.Int());
            AddColumn("dbo.tb_gerencia", "Equipe_ID", c => c.Int());
            CreateIndex("dbo.tb_equipe", "Gerencia_ID");
            CreateIndex("dbo.tb_gerencia", "Equipe_ID");
            AddForeignKey("dbo.tb_gerencia", "Equipe_ID", "dbo.tb_equipe", "ID");
            AddForeignKey("dbo.tb_equipe", "Gerencia_ID", "dbo.tb_gerencia", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_equipe", "Gerencia_ID", "dbo.tb_gerencia");
            DropForeignKey("dbo.tb_gerencia", "Equipe_ID", "dbo.tb_equipe");
            DropIndex("dbo.tb_gerencia", new[] { "Equipe_ID" });
            DropIndex("dbo.tb_equipe", new[] { "Gerencia_ID" });
            DropColumn("dbo.tb_gerencia", "Equipe_ID");
            DropColumn("dbo.tb_equipe", "Gerencia_ID");
            AddForeignKey("dbo.tb_equipe", "GerenciaID", "dbo.tb_gerencia", "ID", cascadeDelete: true);
        }
    }
}
