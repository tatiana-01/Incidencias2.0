using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Dominio.Interfaces;
    public interface IPersonaDireccion
    {
        Task<PersonaDireccion> GetByIdAsync(string idPersona, int idDireccion);
        Task<IEnumerable<PersonaDireccion>> GetAllAsync();
        IEnumerable<PersonaDireccion> Find(Expression<Func<PersonaDireccion, bool>> expression);
        void Add(PersonaDireccion entity);
        void AddRange(IEnumerable<PersonaDireccion> entities);
        void Remove(PersonaDireccion entity);
        void RemoveRange(IEnumerable<PersonaDireccion> entities);
        void Update(PersonaDireccion entity);
    }
