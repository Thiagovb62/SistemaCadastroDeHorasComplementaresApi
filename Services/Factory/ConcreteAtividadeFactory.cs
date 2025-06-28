using SistemaCadastroDeHorasApi.Models.DTO;
using SistemaCadastroDeHorasApi.Repositories;
using SistemaCadastroDeHorasApi.Repositories.Contracts;

namespace SistemaCadastroDeHorasApi.Services.Factory;

public class ConcreteAtividadeFactory: AtividadeFactory
{
    public ConcreteAtividadeFactory(IUsuarioRepository usuarioRepository, IComprovanteService comprovanteAuxiliary, IAtividadeUsuarioRepository atividadeUsuarioRepositoryRepository) : base(usuarioRepository, comprovanteAuxiliary, atividadeUsuarioRepositoryRepository)
    { 
    }
}