using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Dominio.Interfaces;
    public interface IIncidenciaPuesto
    {
        Task<IncidenciaPuesto> GetByIdAsync(int IdIncidencia, int IdPuesto,int IdComponente);
        Task<IEnumerable<IncidenciaPuesto>> GetAllAsync();
        Task<(int totalRegistros, IEnumerable<IncidenciaPuesto> registros)> GetAllAsync(int pageIndex, int pageSize, string search);
        IEnumerable<IncidenciaPuesto> Find(Expression<Func<IncidenciaPuesto, bool>> expression);
        void Add(IncidenciaPuesto entity);
        void AddRange(IEnumerable<IncidenciaPuesto> entities);
        void Remove(IncidenciaPuesto entity);
        void RemoveRange(IEnumerable<IncidenciaPuesto> entities);
        void Update(IncidenciaPuesto entity);
    }
