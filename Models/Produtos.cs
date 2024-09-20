namespace Padaria_Api.Models
{
    public class Produtos 
    {
        public int Id { get; set; }
        public string? Nome  { get; set; }
        public decimal preço { get; set; }
        public int validade { get; set; }

    }
}
