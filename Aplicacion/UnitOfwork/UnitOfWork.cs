using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Aplicacion.Repositorio;
using Dominio.Entidades;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfwork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly IncidenciasContext context;
    private AreaContactoRepository _areaContactos;
    private AreaRepository _areas;
    private ARLRepository _ARLs;
    private CategoriaRepository _categorias;
    private CiudadRepository _ciudades;
    private ContactoRepository _contactos;
    private DepartamentoRepository _departamentos;
    private DireccionRepository _direcciones;
    private EPSRepository _EPSs;
    private EstadoIncidenciaRepository _estadoIncidencias;
    private EstadoVerificacionRepository _estadoVerificacion;
    private GeneroRepository _generos;
    private ComponenteRepository _componentes;
    private IncidenciaPuestoRepository _incidenciaPuestos;
    private IncidenciaRepository _incidencias;
    private PaisRepository _paises;
    private PersonaContactoRepository _personaContactos;
    private PersonaDireccionRepository _personaDirecciones;
    private PersonaRepository _personas;
    private PuestoRepository _puestos;
    private RolRepository _roles;
    private SalonRepository _salones;
    private TipoComponenteRepository _tipoComponentes;
    private TipoContactoRepository _tipoContactos;
    private TipoIncidenciaRepository _tipoIncidencias;
    private UsuarioRepository _usuarios;
    private VerificacionRepository _verificaciones;

    public UnitOfWork(IncidenciasContext _context)
    {
        context = _context;
    }

    public IArea Areas
    {
        get
        {
            if (_areas == null)
            {
                _areas = new AreaRepository(context);
            }
            return _areas;
        }
    }

    public IAreaContacto AreaContactos
    {
        get
        {
            if (_areaContactos == null)
            {
                _areaContactos = new AreaContactoRepository(context);
            }
            return _areaContactos;
        }
    }

    public IARL ARLs
    {
        get
        {
            if (_ARLs == null)
            {
                _ARLs = new ARLRepository(context);
            }
            return _ARLs;
        }
    }

    public ICategoria Categorias
    {
        get
        {
            if (_categorias == null)
            {
                _categorias = new CategoriaRepository(context);
            }
            return _categorias;
        }
    }

    public ICiudad Ciudades
    {
        get
        {
            if (_ciudades == null)
            {
                _ciudades = new CiudadRepository(context);
            }
            return _ciudades;
        }
    }

    public IContacto Contactos
    {
        get
        {
            if (_contactos == null)
            {
                _contactos = new ContactoRepository(context);
            }
            return _contactos;
        }
    }

    public IDepartamento Departamentos
    {
        get
        {
            if (_departamentos == null)
            {
                _departamentos = new DepartamentoRepository(context);
            }
            return _departamentos;
        }
    }

    public IDireccion Direcciones
    {
        get
        {
            if (_direcciones == null)
            {
                _direcciones = new DireccionRepository(context);
            }
            return _direcciones;
        }
    }

    public IEPS EPSs
    {
        get
        {
            if (_EPSs == null)
            {
                _EPSs = new EPSRepository(context);
            }
            return _EPSs;
        }
    }

    public IEstadoIncidencia EstadoIncidencias
    {
        get
        {
            if (_estadoIncidencias == null)
            {
                _estadoIncidencias = new EstadoIncidenciaRepository(context);
            }
            return _estadoIncidencias;
        }
    }

    public IEstadoVerificacion EstadoVerificaciones
    {
        get
        {
            if (_estadoVerificacion == null)
            {
                _estadoVerificacion = new EstadoVerificacionRepository(context);
            }
            return _estadoVerificacion;
        }
    }

    public IGenero Generos
    {
        get
        {
            if (_generos == null)
            {
                _generos = new GeneroRepository(context);
            }
            return _generos;
        }
    }

    public IComponente Componentes
    {
        get
        {
            if (_componentes == null)
            {
                _componentes = new ComponenteRepository(context);
            }
            return _componentes;
        }
    }

    public IIncidencia Incidencias
    {
        get
        {
            if (_incidencias == null)
            {
                _incidencias = new IncidenciaRepository(context);
            }
            return _incidencias;
        }
    }

    public IIncidenciaPuesto IncidenciaPuestos
    {
        get
        {
            if (_incidenciaPuestos == null)
            {
                _incidenciaPuestos = new IncidenciaPuestoRepository(context);
            }
            return _incidenciaPuestos;
        }
    }

    public IPais Paises
    {
        get
        {
            if (_paises == null)
            {
                _paises = new PaisRepository(context);
            }
            return _paises;
        }
    }

    public IPersona Personas
    {
        get
        {
            if (_personas == null)
            {
                _personas = new PersonaRepository(context);
            }
            return _personas;
        }
    }

    public IPersonaContacto PersonaContactos
    {
        get
        {
            if (_personaContactos == null)
            {
                _personaContactos = new PersonaContactoRepository(context);
            }
            return _personaContactos;
        }
    }

    public IPersonaDireccion PersonaDirecciones
    {
        get
        {
            if (_personaDirecciones == null)
            {
                _personaDirecciones = new PersonaDireccionRepository(context);
            }
            return _personaDirecciones;
        }
    }

    public IPuesto Puestos
    {
        get
        {
            if (_puestos == null)
            {
                _puestos = new PuestoRepository(context);
            }
            return _puestos;
        }
    }

    public ISalon Salones
    {
        get
        {
            if (_salones == null)
            {
                _salones = new SalonRepository(context);
            }
            return _salones;
        }
    }

    public IRol Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepository(context);
            }
            return _roles;
        }
    }


    public ITipoComponente TipoComponentes
    {
        get
        {
            if (_tipoComponentes == null)
            {
                _tipoComponentes = new TipoComponenteRepository(context);
            }
            return _tipoComponentes;
        }
    }

    public ITipoContacto TipoContactos
    {
        get
        {
            if (_tipoContactos == null)
            {
                _tipoContactos = new TipoContactoRepository(context);
            }
            return _tipoContactos;
        }
    }

    public ITipoIncidencia TipoIncidencias
    {
        get
        {
            if (_tipoIncidencias == null)
            {
                _tipoIncidencias = new TipoIncidenciaRepository(context);
            }
            return _tipoIncidencias;
        }
    }

    public IUsuario Usuarios
    {
        get
        {
            if (_usuarios == null)
            {
                _usuarios = new UsuarioRepository(context);
            }
            return _usuarios;
        }
    }

    public IVerificacion Verificaciones
    {
        get
        {
            if (_verificaciones == null)
            {
                _verificaciones = new VerificacionRepository(context);
            }
            return _verificaciones;
        }
    }

    public async Task<int> SaveAsync(){
        return await context.SaveChangesAsync();
    }

    public void Dispose()
    {
        context.Dispose();
    }
}
