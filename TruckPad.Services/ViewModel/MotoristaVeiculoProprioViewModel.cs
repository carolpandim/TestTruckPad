using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckPad.Services.ViewModel
{
    public class MotoristaVeiculoProprioViewModel
    {
        public int IdMotorista { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Sexo { get; set; }
        public bool PossuiVeiculo { get; set; }
        public string TipoCNH { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
    }
}
