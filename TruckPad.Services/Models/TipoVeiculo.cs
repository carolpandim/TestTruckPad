using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruckPad.Services.Models
{
    public partial class TipoVeiculo
    {
        public TipoVeiculo()
        {
            Veiculo = new HashSet<Veiculo>();
        }

        [Key]
        public int IdTipoVeiculo { get; set; }
        [Required]
        [Column("TipoVeiculo")]
        [StringLength(50)]
        public string TipoVeiculo1 { get; set; }

        [InverseProperty("IdTipoVeiculoNavigation")]
        public ICollection<Veiculo> Veiculo { get; set; }
    }
}
