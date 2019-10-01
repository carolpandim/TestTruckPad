using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruckPad.Services.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Cidade = new HashSet<Cidade>();
        }

        [Key]
        public int IdEstado { get; set; }
        [Required]
        [Column("Estado")]
        [StringLength(50)]
        public string Estado1 { get; set; }
        [Required]
        [Column("UF")]
        [StringLength(2)]
        public string Uf { get; set; }

        [InverseProperty("IdEstadoNavigation")]
        public ICollection<Cidade> Cidade { get; set; }
    }
}
