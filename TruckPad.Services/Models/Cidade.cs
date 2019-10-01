using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruckPad.Services.Models
{
    public partial class Cidade
    {
        public Cidade()
        {
            Bairro = new HashSet<Bairro>();
        }

        [Key]
        public int IdCidade { get; set; }
        public int IdEstado { get; set; }
        [Required]
        [Column("Cidade")]
        [StringLength(200)]
        public string Cidade1 { get; set; }

        [ForeignKey("IdEstado")]
        [InverseProperty("Cidade")]
        public Estado IdEstadoNavigation { get; set; }
        [InverseProperty("IdCidadeNavigation")]
        public ICollection<Bairro> Bairro { get; set; }
    }
}
