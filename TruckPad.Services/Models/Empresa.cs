using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruckPad.Services.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            ViagemIdDestinoNavigation = new HashSet<Viagem>();
            ViagemIdOrigemNavigation = new HashSet<Viagem>();
        }

        [Key]
        public int IdEmpresa { get; set; }
        public int IdEndereco { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required]
        [Column("CNPJ")]
        [StringLength(15)]
        public string Cnpj { get; set; }
        [StringLength(5)]
        public string NumeroLogradouro { get; set; }
        [StringLength(50)]
        public string ComplementoLogradouro { get; set; }
        [StringLength(15)]
        public string Telefone { get; set; }
        [StringLength(15)]
        public string Celular { get; set; }
        public bool Ativo { get; set; }

        [ForeignKey("IdEndereco")]
        [InverseProperty("Empresa")]
        public Endereco IdEnderecoNavigation { get; set; }
        [InverseProperty("IdDestinoNavigation")]
        public ICollection<Viagem> ViagemIdDestinoNavigation { get; set; }
        [InverseProperty("IdOrigemNavigation")]
        public ICollection<Viagem> ViagemIdOrigemNavigation { get; set; }
    }
}
