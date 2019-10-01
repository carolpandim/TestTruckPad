using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TruckPad.Services.ViewModel;

namespace TruckPad.Services.Models
{
    public partial class TruckPadContext : DbContext
    {
        public TruckPadContext()
        {
        }

        public TruckPadContext(DbContextOptions<TruckPadContext> options)
            : base(options)
        {
        }

        protected string ConnectionString { get; }

        protected TruckPadContext(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("TruckPadDB");
        }

        public virtual DbSet<Bairro> Bairro { get; set; }
        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Motorista> Motorista { get; set; }
        public virtual DbSet<Parada> Parada { get; set; }
        public virtual DbSet<TipoVeiculo> TipoVeiculo { get; set; }
        public virtual DbSet<Veiculo> Veiculo { get; set; }
        public virtual DbSet<Viagem> Viagem { get; set; }
        public virtual DbSet<ViagemParada> ViagemParada { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Query<MotoristaOrigemDestinoViewModel>();
            modelBuilder.Query<MotoristaParadaCarregadoPorPeriodoViewModel>();
            modelBuilder.Query<MotoristaParadaViewModel>();
            modelBuilder.Query<MotoristaSemCargaDestinoOrigemViewModel>();
            modelBuilder.Query<MotoristaVeiculoProprioViewModel>();
            modelBuilder.Query<MotoristaTipoVeiculoOrigemDestinoViewModel>();

            modelBuilder.Entity<Bairro>(entity =>
            {
                entity.Property(e => e.Bairro1).IsUnicode(false);

                entity.HasOne(d => d.IdCidadeNavigation)
                    .WithMany(p => p.Bairro)
                    .HasForeignKey(d => d.IdCidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bairro_Cidade");
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.Property(e => e.Cidade1).IsUnicode(false);

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Cidade)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cidade_Estado");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.IdEndereco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empresa_Endereco");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.Property(e => e.Cep).IsUnicode(false);

                entity.Property(e => e.Endereco1).IsUnicode(false);

                entity.Property(e => e.Latitude).IsUnicode(false);

                entity.Property(e => e.Longitude).IsUnicode(false);

                entity.HasOne(d => d.IdBairroNavigation)
                    .WithMany(p => p.Endereco)
                    .HasForeignKey(d => d.IdBairro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Endereco_Bairro");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.Estado1).IsUnicode(false);

                entity.Property(e => e.Uf).IsUnicode(false);
            });

            modelBuilder.Entity<Motorista>(entity =>
            {
                entity.Property(e => e.Cpf).IsUnicode(false);

                entity.Property(e => e.DataRegistro).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Sexo).IsUnicode(false);

                entity.Property(e => e.TipoCnh).IsUnicode(false);
            });

            modelBuilder.Entity<Parada>(entity =>
            {
                entity.Property(e => e.IdParada).ValueGeneratedOnAdd();

                entity.Property(e => e.DataRegistro).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdParadaNavigation)
                    .WithOne(p => p.Parada)
                    .HasForeignKey<Parada>(d => d.IdParada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parada_Endereco");
            });

            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.Property(e => e.DataRegistro).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdTipoVeiculoNavigation)
                    .WithMany(p => p.Veiculo)
                    .HasForeignKey(d => d.IdTipoVeiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Veiculo_TipoVeiculo");
            });

            modelBuilder.Entity<Viagem>(entity =>
            {
                entity.Property(e => e.DataRegistro).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdDestinoNavigation)
                    .WithMany(p => p.ViagemIdDestinoNavigation)
                    .HasForeignKey(d => d.IdDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Viagem_Empresa_Destino");

                entity.HasOne(d => d.IdMotoristaNavigation)
                    .WithMany(p => p.Viagem)
                    .HasForeignKey(d => d.IdMotorista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Viagem_Motorista");

                entity.HasOne(d => d.IdOrigemNavigation)
                    .WithMany(p => p.ViagemIdOrigemNavigation)
                    .HasForeignKey(d => d.IdOrigem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Viagem_Empresa_Origem");

                entity.HasOne(d => d.IdVeiculoNavigation)
                    .WithMany(p => p.Viagem)
                    .HasForeignKey(d => d.IdVeiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Viagem_Veiculo");
            });

            modelBuilder.Entity<ViagemParada>(entity =>
            {
                entity.Property(e => e.DataRegistro).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdParadaNavigation)
                    .WithMany(p => p.ViagemParada)
                    .HasForeignKey(d => d.IdParada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ViagemParada_Parada");

                entity.HasOne(d => d.IdViagemNavigation)
                    .WithMany(p => p.ViagemParada)
                    .HasForeignKey(d => d.IdViagem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ViagemParada_Viagem");
            });
        }
    }
}
