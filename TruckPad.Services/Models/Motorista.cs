using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruckPad.Services.Models
{
    public partial class Motorista
    {
        public Motorista()
        {
            Viagem = new HashSet<Viagem>();
        }

        [Key]
        public int IdMotorista { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        public int Idade { get; set; }
        [Required]
        [StringLength(1)]
        public string Sexo { get; set; }
        public bool PossuiVeiculo { get; set; }
        [Required]
        [Column("TipoCNH")]
        [StringLength(10)]
        public string TipoCnh { get; set; }
        [StringLength(15)]
        public string Telefone { get; set; }
        [Required]
        [StringLength(15)]
        public string Celular { get; set; }
        [Required]
        [Column("CPF")]
        [StringLength(11)]
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        [StringLength(40)]
        public string Email { get; set; }
        public bool Ativo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataRegistro { get; set; }

        [InverseProperty("IdMotoristaNavigation")]
        public ICollection<Viagem> Viagem { get; set; }
    }
}
