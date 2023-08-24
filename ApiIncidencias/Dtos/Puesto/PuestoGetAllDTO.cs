using ApiIncidencias.Dtos.Componente;
using ApiIncidencias.Dtos.IncidenciaPuesto;

namespace ApiIncidencias.Dtos.Puesto;
public class PuestoGetAllDTO
    {
        public int Id { get; set; }
        public int IdSalon { get; set; }
        public string Descripcion {get; set;}
        public ICollection<ComponenteDTO> Softwares {get;set;}
        public ICollection<IncidenciaPuestoDTO> IncidenciaPuestos {get;set;}

    }
