namespace Jca.Sigmuni.Application.Dtos.General.TblCodigos
{
    public class TblCodigoCatastralRefDto
    {
        public string? Id { get; set; }
        public string? CodDepartamento { get; set; }
        public string? CodProvincia { get; set; }
        public string? CodDistrito { get; set; }
        public string? CodSector { get; set; }
        public string? CodManzana { get; set; }
        public string? CodLote { get; set; }
        public string? CodEdif { get; set; }
        public string? CodEnt { get; set; }
        public string? CodPiso { get; set; }
        public string? CodUnid { get; set; }
        public string? DigitoControl { get; set; }


        public int IdUnidadCatastral { get; set; }
    }
}
