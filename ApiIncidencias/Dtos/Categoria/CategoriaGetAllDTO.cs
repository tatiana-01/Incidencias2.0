using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIncidencias.Dtos.Componente;
using ApiIncidencias.Dtos.Incidencia;
using ApiIncidencias.Dtos.TipoComponente;

namespace ApiIncidencias.Dtos.Categoria
{
    public class CategoriaGetAllDTO
    {
        public int Id { get; set; }
        public string Nombre {get; set;}
        public ICollection<IncidenciaDTO> Incidencias {get;set;}
        public ICollection<ComponenteDTO> Componentes {get;set;}
        public ICollection<TipoComponenteDTO> TipoComponentes {get;set;}
    }
}