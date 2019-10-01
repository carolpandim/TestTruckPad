using System;

namespace TruckPad.Services.ViewModel
{
    public class MotoristaParadaViewModel
    {
        public int IdMotorista { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Sexo { get; set; }
        public string TipoCNH { get; set; }
        public string Carregado { get; set; }
        public string TipoVeiculo { get; set; }
        public DateTime DataChegada { get; set; }
        public string ProprietarioVeiculo { get; set; }
    }
}
