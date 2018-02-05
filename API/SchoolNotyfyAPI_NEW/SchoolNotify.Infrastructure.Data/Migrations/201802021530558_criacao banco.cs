namespace SchoolNotify.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criacaobanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Professor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150),
                        Matricula = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SalaProfessorRelacional",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdSala = c.Int(nullable: false),
                        IdProfessor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Professor", t => t.IdProfessor)
                .ForeignKey("dbo.Sala", t => t.IdSala)
                .Index(t => t.IdSala)
                .Index(t => t.IdProfessor);
            
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdResponsavel = c.Int(nullable: false),
                        IdSalaProfessorRelacional = c.Int(nullable: false),
                        Responsavel_Id = c.Int(),
                        SalaProfessorRelacional_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Responsavel", t => t.Responsavel_Id)
                .ForeignKey("dbo.SalaProfessorRelacional", t => t.SalaProfessorRelacional_Id)
                .Index(t => t.Responsavel_Id)
                .Index(t => t.SalaProfessorRelacional_Id);
            
            CreateTable(
                "dbo.Responsavel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150),
                        Email = c.String(nullable: false, maxLength: 50),
                        Telefone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sala",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Serie = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalaProfessorRelacional", "IdSala", "dbo.Sala");
            DropForeignKey("dbo.SalaProfessorRelacional", "IdProfessor", "dbo.Professor");
            DropForeignKey("dbo.Aluno", "SalaProfessorRelacional_Id", "dbo.SalaProfessorRelacional");
            DropForeignKey("dbo.Aluno", "Responsavel_Id", "dbo.Responsavel");
            DropIndex("dbo.Aluno", new[] { "SalaProfessorRelacional_Id" });
            DropIndex("dbo.Aluno", new[] { "Responsavel_Id" });
            DropIndex("dbo.SalaProfessorRelacional", new[] { "IdProfessor" });
            DropIndex("dbo.SalaProfessorRelacional", new[] { "IdSala" });
            DropTable("dbo.Sala");
            DropTable("dbo.Responsavel");
            DropTable("dbo.Aluno");
            DropTable("dbo.SalaProfessorRelacional");
            DropTable("dbo.Professor");
        }
    }
}
