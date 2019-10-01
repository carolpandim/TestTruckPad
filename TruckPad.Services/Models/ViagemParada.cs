using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruckPad.Services.Models
{
    public partial class ViagemParada
    {
        [Key]
        public int IdViagemParada { get; set; }
        public int IdViagem { get; set; }
        public int IdParada { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataPrevistaChegada { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataChegada { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataPrevistaSaida { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataSaida { get; set; }
        public int Ordem { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataRegistro { get; set; }

        [ForeignKey("IdParada")]
        [InverseProperty("ViagemParada")]
        public Parada IdParadaNavigation { get; set; }
        [ForeignKey("IdViagem")]
        [InverseProperty("ViagemParada")]
        public Viagem IdViagemNavigation { get; set; }
    }
}
