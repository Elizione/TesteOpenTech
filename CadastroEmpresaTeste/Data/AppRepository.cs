using CadastroEmpresaTeste.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroEmpresaTeste.Data
{
    public class AppRepository : IAppRepository
    {
        public AppRepository(AppDbContext context)
        {
            Context = context;
        }

        public AppDbContext Context { get; }

        public void Add<T>(T entity) where T : class
        {
            Context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            Context.Remove(entity);
        }

        public async Task<Empresa[]> GetAllEmpresasAsync()
        {
            IQueryable<Empresa> query = Context.Empresas;
            return await query.ToArrayAsync();
        }

        public Empresa[] GetAllEmpresas()
        {
            IQueryable<Empresa> query = Context.Empresas;
            return query.ToArray();
        }

        public async Task<Empresa> GetEmpresaAsync(int id)
        {
            return await Context.Empresas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Empresa GetEmpresa(int id)
        {
            return Context.Empresas.FirstOrDefault(x => x.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            Context.Update(entity);
        }
    }
}
