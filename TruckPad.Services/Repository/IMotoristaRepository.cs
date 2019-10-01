using System.Collections.Generic;
using System.Threading.Tasks;
using TruckPad.Services.Models;
using TruckPad.Services.ViewModel;

namespace TruckPad.Services.Repository
{
    public interface IMotoristaRepository
    {
        Task<List<Motorista>> GetMotoristas();
        Task<Motorista> GetMotorista(int? idMotorista);
        Task<int> PostMotorista(Motorista motorista);
        Task PutMotorista(Motorista motorista);
        Task<int> DeleteMotorista(int? idMotorista);

        Task<List<MotoristaOrigemDestinoViewModel>> GetMotoristaOrigemDestino();
        Task<List<MotoristaParadaCarregadoPorPeriodoViewModel>> GetMotoristaParadaCarregadoPorPeriodo();
        Task<List<MotoristaParadaViewModel>> GetMotoristaParada();
        Task<List<MotoristaSemCargaDestinoOrigemViewModel>> GetMotoristaSemCargaDestinoOrigem();
        Task<List<MotoristaTipoVeiculoOrigemDestinoViewModel>> GetMotoristaTipoVeiculoOrigemDestino();
        Task<List<MotoristaVeiculoProprioViewModel>> GetMotoristaVeiculoProprio();
    }
}
