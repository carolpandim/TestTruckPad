using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruckPad.Services.Models
{
    public partial class Parada
    {
        public Parada()
        {
            ViagemParada = new HashSet<ViagemParada>();
        }

        [Key]
        public int IdParada { get; set; }
        public int IdEndereco { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [StringLength(5)]
        public string NumeroLogradouro { get; set; }
        [StringLength(50)]
        public string ComplementoLogradouro { get; set; }
        public bool Ativo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataRegistro { get; set; }

        [ForeignKey("IdParada")]
        [InverseProperty("Parada")]
        public Endereco IdParadaNavigation { get; set; }
        [InverseProperty("IdParadaNavigation")]
        public ICollection<ViagemParada> ViagemParada { get; set; }
    }
}
