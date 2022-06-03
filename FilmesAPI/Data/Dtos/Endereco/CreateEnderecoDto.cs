using FilmesAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmesAPI.Data.Dtos
{
    public class CreateEnderecoDto
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public Cinema Cinema { get; set; }
    }
}
