using SistemaCadastroDeHorasApi.Repositories;

namespace SistemaCadastroDeHorasApi.Services.Factory;

public class ConcreteHorasFactory: IntegralizacaoHorasFactory
{
    
    public ConcreteHorasFactory(IUsuarioRepository usuarioRepository, IAtividadesRepository atividadesRepository) 
        : base(usuarioRepository, atividadesRepository)
    {
    }
    
}