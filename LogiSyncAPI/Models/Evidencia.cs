namespace LogiSyncAPI.Models
{
    public class Evidencia
    {
        public int Id { get; set; }

        public int EnvioId { get; set; }
        public Envio? Envio { get; set; }

        public string Archivo { get; set; } = string.Empty;

        public string? Comentario { get; set; }

        public DateTime Fecha { get; set; }
    }
}