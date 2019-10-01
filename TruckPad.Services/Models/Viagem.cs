using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruckPad.Services.Models
{
    public partial class Viagem
    {
        public Viagem()
        {
            ViagemParada = new HashSet<ViagemParada>();
        }

        [Key]
        public int IdViagem { get; set; }
        public int IdOrigem { get; set; }
        public int IdDestino { get; set; }
        public int IdMotorista { get; set; }
        public int IdVeiculo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataPrevistaSaida { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataSaida { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataPrevistaChegada { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataChegada { get; set; }
        public bool Carregado { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataRegistro { get; set; }
        public int? ViagemOrigem { get; set; }

        [ForeignKey("IdDestino")]
        [InverseProperty("ViagemIdDestinoNavigation")]
        public Empresa IdDestinoNavigation { get; set; }
        [ForeignKey("IdMotorista")]
        [InverseProperty("Viagem")]
        public Motorista IdMotoristaNavigation { get; set; }
        [ForeignKey("IdOrigem")]
        [InverseProperty("ViagemIdOrigemNavigation")]
        public Empresa IdOrigemNavigation { get; set; }
        [ForeignKey("IdVeiculo")]
        [InverseProperty("Viagem")]
        public Veiculo IdVeiculoNavigation { get; set; }
        [InverseProperty("IdViagemNavigation")]
        public ICollection<ViagemParada> ViagemParada { get; set; }
    }
}
