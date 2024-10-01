namespace GestaoDeInventarioAPI.Dto
{
    public class FornecedorEntity
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public bool Ativo { get; set; }

        public List<ProdutoEntity>? Produtos { get; set; }
    }

    public class FornecedorCreate
    {
        public required string Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public bool Ativo { get; set; }
    }
}
