using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.Endereco
{
    public class CreateEnderecoDto
    {
        [Required]
        public string Logradouro { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public int Numero { get; set; }
    }
}
