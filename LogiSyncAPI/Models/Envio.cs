namespace LogiSyncAPI.Models
{
    public class Envio
    {
        // Identificador único del envío
        public int Id { get; set; }

        // Código de seguimiento del envío
        public string Codigo { get; set; } = string.Empty;

        // Empresa logística responsable del envío
        public int EmpresaLogisticaId { get; set; }
        public EmpresaLogistica? EmpresaLogistica { get; set; }

        // Estado original recibido desde el operador logístico
        public int EstadoOriginalId { get; set; }
        public EstadoOriginal? EstadoOriginal { get; set; }

        // Estado normalizado asignado automáticamente por el sistema
        public int? EstadoNormalizadoId { get; set; }
        public EstadoNormalizado? EstadoNormalizado { get; set; }

        // Historial de cambios de estado del envío
        public ICollection<HistorialEstado>? HistorialEstados { get; set; }

        // Evidencias asociadas al envío (comentarios, imágenes, archivos)
        public ICollection<Evidencia>? Evidencias { get; set; }
    }
}