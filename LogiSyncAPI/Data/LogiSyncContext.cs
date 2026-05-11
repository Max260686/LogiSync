using LogiSyncAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LogiSyncAPI.Data
{
    public class LogiSyncContext : DbContext
    {
        public LogiSyncContext(DbContextOptions<LogiSyncContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<EmpresaLogistica> EmpresasLogisticas => Set<EmpresaLogistica>();
        public DbSet<EstadoOriginal> EstadosOriginales => Set<EstadoOriginal>();
        public DbSet<EstadoNormalizado> EstadosNormalizados => Set<EstadoNormalizado>();
        public DbSet<TraduccionEstado> TraduccionesEstados => Set<TraduccionEstado>();
        public DbSet<Envio> Envios => Set<Envio>();
        public DbSet<HistorialEstado> HistorialEstados => Set<HistorialEstado>();
        public DbSet<Evidencia> Evidencias => Set<Evidencia>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Envio>()
                .HasOne(e => e.EmpresaLogistica)
                .WithMany()
                .HasForeignKey(e => e.EmpresaLogisticaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Envio>()
                .HasOne(e => e.EstadoOriginal)
                .WithMany()
                .HasForeignKey(e => e.EstadoOriginalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Envio>()
                .HasOne(e => e.EstadoNormalizado)
                .WithMany()
                .HasForeignKey(e => e.EstadoNormalizadoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EstadoOriginal>()
                .HasOne(e => e.EmpresaLogistica)
                .WithMany()
                .HasForeignKey(e => e.EmpresaLogisticaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TraduccionEstado>()
                .HasOne(t => t.EstadoOriginal)
                .WithMany()
                .HasForeignKey(t => t.EstadoOriginalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TraduccionEstado>()
                .HasOne(t => t.EstadoNormalizado)
                .WithMany()
                .HasForeignKey(t => t.EstadoNormalizadoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HistorialEstado>()
                .HasOne(h => h.Envio)
                .WithMany(e => e.HistorialEstados)
                .HasForeignKey(h => h.EnvioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HistorialEstado>()
                .HasOne(h => h.EstadoOriginal)
                .WithMany()
                .HasForeignKey(h => h.EstadoOriginalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HistorialEstado>()
                .HasOne(h => h.EstadoNormalizado)
                .WithMany()
                .HasForeignKey(h => h.EstadoNormalizadoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Evidencia>()
                .HasOne(e => e.Envio)
                .WithMany(e => e.Evidencias)
                .HasForeignKey(e => e.EnvioId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}