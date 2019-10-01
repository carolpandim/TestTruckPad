using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruckPad.Services.Models
{
    public partial class Bairro
    {
        public Bairro()
        {
            Endereco = new HashSet<Endereco>();
        }

        [Key]
        public int IdBairro { get; set; }
        public int IdCidade { get; set; }
        [Required]
        [Column("Bairro")]
        [StringLength(200)]
        public string Bairro1 { get; set; }

        [ForeignKey("IdCidade")]
        [InverseProperty("Bairro")]
        public Cidade IdCidadeNavigation { get; set; }
        [InverseProperty("IdBairroNavigation")]
        public ICollection<Endereco> Endereco { get; set; }
    }
}
