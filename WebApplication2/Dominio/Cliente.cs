using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Dominio

{
    public class Cliente : IEntity
    {
        
        public Int32 Id { get; set; }
        
        public string Nome { get; set; }
        
        public string Cpf { get; set; }
        
        public string Agencia { get; set; }
        
        public string Conta { get; set; }
        
        public string Estado { get; set; }

    }
}