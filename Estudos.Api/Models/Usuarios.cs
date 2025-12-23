namespace Estudos.Api.Models
{
    // Modelo de dados para a tabela Usuarios
    public class Usuarios
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public DateTime? DataCriacao { get; set; }
    }
}
