namespace GestaoDeInventarioAPI.Dto
{
    public class ProdutoEntity
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public int? CategoriaId { get; set; }
        public int? FornecedorId { get; set; }
        public bool? Ativo { get; set; }

        public CategoriaEntity? Categoria { get; set; }
        public FornecedorEntity? Fornecedor { get; set; }
        public List<EstoqueEntity>? Estoques { get; set; }
    }

    public class ProdutoUpdate
    {
        public required string Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public bool? Ativo { get; set; }
    }

}
