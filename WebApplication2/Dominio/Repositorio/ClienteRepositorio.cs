using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication2.Infra;

namespace WebApplication2.Dominio.Repositorio
{
    public class ClienteRepositorio : RepositorioBase<Cliente>, IClienteRepositorio
    {

        public ClienteRepositorio(Context context): base (context)
        { }

    }
}