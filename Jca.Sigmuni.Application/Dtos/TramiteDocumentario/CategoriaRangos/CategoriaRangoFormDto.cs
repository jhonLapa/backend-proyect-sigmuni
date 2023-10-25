namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.CategoriaRangos
{
    public class CategoriaRangoFormDto
    {
        public List<CategoriaRangoDto> MontoTramite { get; set; }
        //public ProcedimientoDto Procedimiento { get; set; }
        //public List<RequisitoDto> ArrayRequisitos { get; set; }
        //public List<ProcedimientoRequisitoDto> ArrayProcedimientoRequisitos { get; set; }
        public int Tipo { get; set; }
        public int Anio { get; set; }
        public bool EsNuevo { get; set; }
        public int IdProcedimiento { get; set; }

        public string PlazoReconsideracionP { get; set; }
        public string PlazoReconsideracionR { get; set; }
        public string PlazoApelacionP { get; set; }
        public string PlazoApelacionR { get; set; }
    }
}
