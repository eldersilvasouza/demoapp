using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Dominio.Repositorio
{
    public interface IRepositorioBase <T> where T : class
    {

        Task  SaveAsync(T obj);

        Task <T> GetAsync(int id);

        Task<List<T>> GetAllAsync();      

        Task UpdateAsync(int id, T objUpdade);

        Task DeleteAsync(T obj);
     




    }
}
