using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruckPad.Services.Models
{
    public partial class Veiculo
    {
        public Veiculo()
        {
            Viagem = new HashSet<Viagem>();
        }

        [Key]
        public int IdVeiculo { get; set; }
        public int IdTipoVeiculo { get; set; }
        [Required]
        [StringLength(11)]
        public string CodRenavam { get; set; }
        [Required]
        [StringLength(17)]
        public string Chassi { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required]
        [Column("CPF_CNPJ")]
        [StringLength(15)]
        public string CpfCnpj { get; set; }
        [Required]
        [StringLength(7)]
        public string Placa { get; set; }
        [Required]
        [Column("Marca_Modelo")]
        [StringLength(100)]
        public string MarcaModelo { get; set; }
        [Required]
        [Column("Ano_Mod")]
        [StringLength(4)]
        public string AnoMod { get; set; }
        [Required]
        [StringLength(20)]
        public string Cor { get; set; }
        public bool Ativo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataRegistro { get; set; }

        [ForeignKey("IdTipoVeiculo")]
        [InverseProperty("Veiculo")]
        public TipoVeiculo IdTipoVeiculoNavigation { get; set; }
        [InverseProperty("IdVeiculoNavigation")]
        public ICollection<Viagem> Viagem { get; set; }
    }
}
