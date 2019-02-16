using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace WebApplication2.Infra
{
    public class Context : DbContext
    {

        public Context () : base ("EfataEntities")
        {

        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //modelBuilder.Configurations.Add(new ClienteConfig());
            //modelBuilder.Configurations.Add(new EnderecoConfig());
            //modelBuilder.Configurations.Add(new CidadeConfig());
            //modelBuilder.Configurations.Add(new TelefoneConfig());
            //modelBuilder.Configurations.Add(new TipoEnderecoConfig());
            //modelBuilder.Configurations.Add(new FornecedorConfig());
            //modelBuilder.Configurations.Add(new ProdutoConfig());
            //modelBuilder.Configurations.Add(new PedidoConfig());
            //modelBuilder.Configurations.Add(new PedidoItemConfig());
            //modelBuilder.Configurations.Add(new FormaPagamentoConfig());
            //modelBuilder.Configurations.Add(new SituacaoPedidoConfig());
            //modelBuilder.Configurations.Add(new UfConfig());



            modelBuilder.Entity<Cliente>().ToTable("TbCliente");
            modelBuilder.Entity<Cliente>().HasKey(x => x.Id);
            modelBuilder.Entity<Cliente>().Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Cliente>().Property(x => x.Nome).HasColumnName("nr_nome").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Cliente>().Property(x => x.Cpf).HasColumnName("cpf").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Cliente>().Property(x => x.Conta).HasColumnName("conta").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Cliente>().Property(x => x.Agencia).HasColumnName("agencia").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Cliente>().Property(x => x.Estado).HasColumnName("uf").HasMaxLength(20).IsOptional();




            ////Quando for feito o mapeamento da base, informar para a base, que campos que tenha no seu final _Id, são chaves primarias
            //modelBuilder.Properties()
            //    .Where(p => p.Name == p.ReflectedType.Name + "_Id")
            //    .Configure(p => p.IsKey());

            ////Quando for feito o mapeamento da base, informara para a base, que campos que são string, devem ter seu tipo de dados 
            //// do tipo varchar
            //modelBuilder.Properties<string>()
            //    .Configure(p => p.HasColumnType("varchar"));

            ////Sua especificação de tamanho, tera como maximo 100
            //modelBuilder.Properties<string>()
            //    .Configure(p => p.HasMaxLength(100));






        }

    }
}