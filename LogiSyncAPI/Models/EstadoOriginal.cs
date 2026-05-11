namespace LogiSyncAPI.Models
{
    public class EstadoOriginal
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        public int EmpresaLogisticaId { get; set; }
        public EmpresaLogistica? EmpresaLogistica { get; set; }
    }
}