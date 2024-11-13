using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Alunos
{
    public class Aluno
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public String? Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }
    }
}
