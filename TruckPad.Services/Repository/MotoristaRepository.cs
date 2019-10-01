using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TruckPad.Services.Models;
using TruckPad.Services.ViewModel;

namespace TruckPad.Services.Repository
{
    public class MotoristaRepository : IMotoristaRepository
    {
        private readonly TruckPadContext db;
        public MotoristaRepository(TruckPadContext _db)
        {
            db = _db;
        }

        public async Task<List<Motorista>> GetMotoristas()
        {
            if (db != null)
            {
                return await db.Motorista.ToListAsync();
            }

            return null;
        }

        public async Task<Motorista> GetMotorista(int? idMotorista)
        {
            if (db != null)
            {
                return await db.Motorista.FirstOrDefaultAsync(x => x.IdMotorista == idMotorista);
            }

            return null;
        }

        public async Task PutMotorista(Motorista motorista)
        {
            if (db != null)
            {
                db.Motorista.Update(motorista);

                await db.SaveChangesAsync();
            }
        }

        public async Task<int> PostMotorista(Motorista motorista)
        {
            if (db != null)
            {
                await db.Motorista.AddAsync(motorista);
                await db.SaveChangesAsync();

                return motorista.IdMotorista;
            }

            return 0;
        }

        public async Task<int> DeleteMotorista(int? idMotorista)
        {
            int result = 0;

            if (db != null)
            {
                var motorista = await db.Motorista.FirstOrDefaultAsync(x => x.IdMotorista == idMotorista);

                if (motorista != null)
                {
                    db.Motorista.Remove(motorista);

                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<List<MotoristaSemCargaDestinoOrigemViewModel>> GetMotoristaSemCargaDestinoOrigem()
        {
            if (db != null)
            {
                return await db.Query<MotoristaSemCargaDestinoOrigemViewModel>().FromSql("EXECUTE dbo.Spr_ListaMotoristaSemCargaDestinoOrigem").ToListAsync();
            }

            return null;
        }

        public async Task<List<MotoristaOrigemDestinoViewModel>> GetMotoristaOrigemDestino()
        {
            if (db != null)
            {
                return await db.Query<MotoristaOrigemDestinoViewModel>().FromSql("EXECUTE dbo.Spr_ListaMotoristaOrigemDestino").ToListAsync();
            }

            return null;
        }

        public async Task<List<MotoristaParadaViewModel>> GetMotoristaParada()
        {
            if (db != null)
            {
                return await db.Query<MotoristaParadaViewModel>().FromSql("EXECUTE dbo.Spr_ListaMotoristaParada").ToListAsync();
            }

            return null;
        }

        public async Task<List<MotoristaParadaCarregadoPorPeriodoViewModel>> GetMotoristaParadaCarregadoPorPeriodo()
        {
            if (db != null)
            {
                return await db.Query<MotoristaParadaCarregadoPorPeriodoViewModel>().FromSql("EXECUTE dbo.Spr_ListaMotoristaParadaCarregadoPorPeriodo").ToListAsync();
            }

            return null;
        }

        public async Task<List<MotoristaTipoVeiculoOrigemDestinoViewModel>> GetMotoristaTipoVeiculoOrigemDestino()
        {
            if (db != null)
            {
                return await db.Query<MotoristaTipoVeiculoOrigemDestinoViewModel>().FromSql("EXECUTE dbo.Spr_ListaMotoristaTipoVeiculoOrigemDestino").ToListAsync();
            }

            return null;
        }

        public async Task<List<MotoristaVeiculoProprioViewModel>> GetMotoristaVeiculoProprio()
        {
            if (db != null)
            {
                return await db.Query<MotoristaVeiculoProprioViewModel>().FromSql("EXECUTE dbo.Spr_ListaMotoristaVeiculoProprio").ToListAsync();
            }

            return null;
        }
    }
}
