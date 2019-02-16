using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication2.Infra;

namespace WebApplication2.Dominio.Repositorio
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class, IEntity
    {

        private Context Context { get; set; }
        private DbSet<T> Set { get; set; }

        public RepositorioBase(Context context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.Set = this.Context.Set<T>();
        }

        public async Task SaveAsync(T obj)
        {
            this.Context.Set<T>().Add(obj);
            await this.Context.SaveChangesAsync();
        }



        public async Task<T> GetAsync(int id)
        {
            //return this.Set.FirstOrDefault(x => x.Id == id);
            return await this.Context.Set<T>().Where(x => x.Id == id).FirstOrDefaultAsync();

        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this.Context.Set<T>().ToListAsync();


        }

        public async Task UpdateAsync(int id, T objUpdade)
        {
            this.Context.Entry(objUpdade).State = EntityState.Modified;
            this.Context.Set<T>().Add(objUpdade);
            await this.Context.SaveChangesAsync();

        }

        public async Task DeleteAsync(T obj)
        {
            this.Context.Set<T>().Remove(obj);
            await this.Context.SaveChangesAsync();

        }




    }
}