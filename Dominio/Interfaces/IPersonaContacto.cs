using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Dominio.Interfaces;
    public interface IPersonaContacto
    {
        Task<PersonaContacto> GetByIdAsync(string idPersona, int idContacto);
        Task<(int totalRegistros, IEnumerable<PersonaContacto> registros)> GetAllAsync (int pageIndex, int pageSize, string search);
        IEnumerable<PersonaContacto> Find(Expression<Func<PersonaContacto, bool>> expression);
        void Add(PersonaContacto entity);
        void AddRange(IEnumerable<PersonaContacto> entities);
        void Remove(PersonaContacto entity);
        void RemoveRange(IEnumerable<PersonaContacto> entities);
        void Update(PersonaContacto entity);
    
    }
