namespace GestaoDeInventarioAPI.Dto
{
    public class EstoqueEntity
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int QuantidadeEntrada { get; set; }
        public int QuantidadeSaida { get; set; }
        public DateTime? DataMovimentacao { get; set; }
        public required string TipoMovimentacao { get; set; }

        public ProdutoEntity? Produto { get; set; }
    }

    public class EstoqueCreate
    {
        public int QuantidadeEntrada { get; set; }
        public int QuantidadeSaida { get; set; }
        public required string TipoMovimentacao { get; set; }
    }
}
