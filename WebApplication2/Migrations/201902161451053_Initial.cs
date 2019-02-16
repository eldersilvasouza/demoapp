namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TbCliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nr_nome = c.String(nullable: false, maxLength: 50),
                        cpf = c.String(nullable: false, maxLength: 50),
                        agencia = c.String(nullable: false, maxLength: 50),
                        conta = c.String(nullable: false, maxLength: 50),
                        uf = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TbCliente");
        }
    }
}
