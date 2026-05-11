namespace LogiSyncAPI.Models
{
    public class TraduccionEstado
    {
        public int Id { get; set; }

        public int EstadoOriginalId { get; set; }
        public EstadoOriginal? EstadoOriginal { get; set; }

        public int EstadoNormalizadoId { get; set; }
        public EstadoNormalizado? EstadoNormalizado { get; set; }
    }
}