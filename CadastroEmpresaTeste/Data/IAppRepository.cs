using CadastroEmpresaTeste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroEmpresaTeste.Data
{
    public interface IAppRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;

        Task<Empresa[]> GetAllEmpresasAsync();
        Empresa[] GetAllEmpresas();
        Task<Empresa> GetEmpresaAsync(int id);
        Empresa GetEmpresa(int id);
        Task<bool> SaveChangesAsync();

    }
}
