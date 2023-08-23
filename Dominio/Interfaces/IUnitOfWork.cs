using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IUnitOfWork
    {
        IArea Areas {get;}
        IAreaContacto AreaContactos {get;}
        IARL ARLs {get;}
        ICategoria Categorias {get;}
        ICiudad Ciudades {get;}
        IContacto Contactos {get;}
        IDepartamento Departamentos {get;}
        IDireccion Direcciones {get;}
        IEPS EPSs {get;}
        IEstadoIncidencia EstadoIncidencias {get;}
        IEstadoVerificacion EstadoVerificaciones {get;}
        IGenero Generos {get;}
        IComponente Componentes {get;}
        IIncidencia Incidencias {get;}
        IIncidenciaPuesto IncidenciaPuestos {get;}
        IPais Paises {get;}
        IPersona Personas {get;}
        IPersonaContacto PersonaContactos {get;}
        IPersonaDireccion PersonaDirecciones {get;}
        IPuesto Puestos {get;}
        ISalon Salones {get;}
        IRol Roles {get;}
        ITipoComponente TipoComponentes {get;}
        ITipoContacto TipoContactos {get;}
        ITipoIncidencia TipoIncidencias {get;}
        IUsuario Usuarios {get;}
        IVerificacion Verificaciones {get;}
        Task<int> SaveAsync();
    }
    
}