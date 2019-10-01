using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruckPad.Services.Models
{
    public partial class Endereco
    {
        public Endereco()
        {
            Empresa = new HashSet<Empresa>();
        }

        [Key]
        public int IdEndereco { get; set; }
        public int IdBairro { get; set; }
        [Column("Endereco")]
        [StringLength(255)]
        public string Endereco1 { get; set; }
        [Column("CEP")]
        [StringLength(9)]
        public string Cep { get; set; }
        [StringLength(50)]
        public string Latitude { get; set; }
        [StringLength(50)]
        public string Longitude { get; set; }

        [ForeignKey("IdBairro")]
        [InverseProperty("Endereco")]
        public Bairro IdBairroNavigation { get; set; }
        [InverseProperty("IdParadaNavigation")]
        public Parada Parada { get; set; }
        [InverseProperty("IdEnderecoNavigation")]
        public ICollection<Empresa> Empresa { get; set; }
    }
}
