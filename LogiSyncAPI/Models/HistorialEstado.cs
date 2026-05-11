namespace LogiSyncAPI.Models
{
    public class HistorialEstado
    {
        public int Id { get; set; }

        public int EnvioId { get; set; }
        public Envio? Envio { get; set; }

        public int EstadoOriginalId { get; set; }
        public EstadoOriginal? EstadoOriginal { get; set; }

        public int EstadoNormalizadoId { get; set; }
        public EstadoNormalizado? EstadoNormalizado { get; set; }

        public DateTime FechaRegistro { get; set; }

        public string? Comentario { get; set; }
    }
}