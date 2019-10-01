using System;
using System.Collections.Generic;
using System.Text;
using TruckPad.Services.Models;

namespace TruckPad.Tests
{
    public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {
        }

        public void Seed(TruckPadContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Motorista.AddRange(
                new Motorista() { Nome="" },
                new Motorista() { Nome="" }
            );

            context.Viagem.AddRange(
                new Viagem() { IdMotorista = 0 },
                new Viagem() { IdMotorista = 0 }
            );
            context.SaveChanges();
        }
    }
}
