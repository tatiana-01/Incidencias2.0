using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIncidencias.Dtos;
    public class AddRoleDTO
    {
    [Required]
    public string Username { get; set; }
    [Required]
    public string Role { get; set; }
    }
