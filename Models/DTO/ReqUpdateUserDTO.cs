namespace SistemaCadastroDeHorasApi.Models.DTO;

public record ReqUpdateUserDTO(
    string Nome,
    string Matricula,
    string Senha,
    int SemestreDeIngresso
);