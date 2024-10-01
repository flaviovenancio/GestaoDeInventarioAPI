namespace GestaoDeInventarioAPI.Dto
{
    public class CategoriaEntity
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public bool Ativo { get; set; }

        public List<ProdutoEntity>? Produtos { get; set; }
    }

    public class CategoriaCreate
    {
        public required string Nome { get; set; }
        public string? Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}
