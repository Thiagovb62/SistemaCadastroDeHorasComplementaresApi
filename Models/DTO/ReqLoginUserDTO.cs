using System.ComponentModel.DataAnnotations;

namespace SistemaCadastroDeHorasApi.Models.DTO;

public record ReqLoginUserDTO(
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "A matrícula deve ser um número positivo")]
    int Matricula,
    [Required]
    string Senha
);