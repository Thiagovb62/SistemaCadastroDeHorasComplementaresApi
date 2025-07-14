using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.ENUMS;
using SistemaCadastroDeHorasApi.Repositories;

namespace SistemaCadastroDeHorasApi.Services.Factory;

public  class IntegralizacaoHorasFactory
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IAtividadesRepository _atividadesRepository;

    public IntegralizacaoHorasFactory(IUsuarioRepository usuarioRepository,
        IAtividadesRepository atividadesRepository)
    {
        _usuarioRepository = usuarioRepository; 
        _atividadesRepository = atividadesRepository;
        
    }

    public void alocarHoras(Guid atividadeId)
    {
        var atividade = _atividadesRepository.GetByIdAsync(atividadeId).Result;

        // Adicione esta verificação
        if (atividade == null)
        {
            throw new KeyNotFoundException($"Atividade com ID {atividadeId} não encontrada.");
        }

        var usuario = _usuarioRepository.GetByIdAsync(atividade.UsuarioId).Result;

        // Adicione esta verificação também, por segurança
        if (usuario == null)
        {
            throw new KeyNotFoundException($"Usuário associado à atividade {atividadeId} não encontrado.");
        }
        switch (atividade.categoriaAtividadeComplementarHoras)
        {
            case CategoriaAtividadeComplementarEnum.ParticipacaoOrganizacaoEventos:
                if (usuario.horasRestantesTotais > 0)
                {
                    if (usuario.horasRestantesDeParticipacaoOuOrganizacaoDeEventos > 0)
                    {
                        if (usuario.horasRestantesDeParticipacaoOuOrganizacaoDeEventos >= atividade.qtdHorasUtilizadas)
                        {
                            usuario.horasRestantesDeParticipacaoOuOrganizacaoDeEventos -= atividade.qtdHorasUtilizadas;
                            usuario.horasRestantesTotais = usuario.HorasTotais - atividade.qtdHorasUtilizadas;
                            _usuarioRepository.UpdateAsync(usuario);
                        }
                        else
                        {
                            throw new BadHttpRequestException("nao e possivel adiconar horas alem do total.");
                        }
                    }
                    else
                    {
                        throw new BadHttpRequestException("Horas de participação ou organização de eventos ja batidas.");
                    }
                }
                else
                {
                    throw new BadHttpRequestException("Horas restantes totais ja batidas.");
                }

                break;
            case CategoriaAtividadeComplementarEnum.IniciacaoDocenciaPesquisaExtensao:
                if (usuario.horasRestantesTotais > 0)
                {
                    if (usuario.HorasTotaisDeIniciacaoADocenciaOuVivenciaOuExtensão > 0)
                    {
                        if (usuario.HorasTotaisDeIniciacaoADocenciaOuVivenciaOuExtensão >= atividade.qtdHorasUtilizadas)
                        {
                            usuario.HorasTotaisDeIniciacaoADocenciaOuVivenciaOuExtensão -= atividade.qtdHorasUtilizadas;
                            usuario.horasRestantesTotais = usuario.HorasTotais - atividade.qtdHorasUtilizadas;
                            _usuarioRepository.UpdateAsync(usuario);
                        }
                        else
                        {
                            throw new BadHttpRequestException("nao e possivel adiconar horas alem do total.");
                        }
                    }
                    else
                    {
                        throw new BadHttpRequestException("Horas de iniciação, docência, pesquisa ou extensão ja batidas.");
                    }
                }
                else
                {
                    throw new BadHttpRequestException("Horas totais ja batidas.");
                }

                break;
            case CategoriaAtividadeComplementarEnum.AtividadesArtisticoCulturaisEsportivas:
                if (usuario.horasRestantesTotais > 0)
                {
                    if (usuario.horasRestantesDeAtividadesArtisticoCulturaisEEsportivas > 0)
                    {
                        if (usuario.horasRestantesDeAtividadesArtisticoCulturaisEEsportivas >=
                            atividade.qtdHorasUtilizadas)
                        {
                            usuario.horasRestantesDeAtividadesArtisticoCulturaisEEsportivas -=
                                atividade.qtdHorasUtilizadas;
                            usuario.horasRestantesTotais = usuario.HorasTotais - atividade.qtdHorasUtilizadas;
                            _usuarioRepository.UpdateAsync(usuario);
                        }
                        else
                        {
                            throw new BadHttpRequestException("nao e possivel adiconar horas alem do total.");
                        }
                    }
                    else
                    {
                        throw new BadHttpRequestException("Horas de atividades artistico culturais ou esportivas ja batidas.");
                    }
                }
                else
                {
                    throw new BadHttpRequestException("Horas totais ja batidas.");
                }

                break;
            case CategoriaAtividadeComplementarEnum.ExperienciasProfissionais:
                if (usuario.horasRestantesTotais > 0)
                {
                    if (usuario.horasRestantesDeExperienciasLigadasAFormacaoProfissional > 0)
                    {
                        if (usuario.horasRestantesDeExperienciasLigadasAFormacaoProfissional >=
                            atividade.qtdHorasUtilizadas)
                        {
                            usuario.horasRestantesDeExperienciasLigadasAFormacaoProfissional -=
                                atividade.qtdHorasUtilizadas;
                            usuario.horasRestantesTotais = usuario.HorasTotais - atividade.qtdHorasUtilizadas;
                            _usuarioRepository.UpdateAsync(usuario);
                        }
                        else
                        {
                            throw new BadHttpRequestException("nao e possivel adiconar horas alem do total.");
                        }
                    }
                    else
                    {
                        throw new BadHttpRequestException("Horas de experiências profissionais ja batidas.");
                    }
                }
                else
                {
                    throw new BadHttpRequestException("Horas totais ja batidas.");
                }

                break;
            case CategoriaAtividadeComplementarEnum.OutrasAtividades:
                if (usuario.horasRestantesTotais > 0)
                {
                    if (usuario.horasRestantesDeOutrasAtividades > 0)
                    {
                        if (usuario.horasRestantesDeOutrasAtividades >= atividade.qtdHorasUtilizadas)
                        {
                            usuario.horasRestantesDeOutrasAtividades -= atividade.qtdHorasUtilizadas;
                            usuario.horasRestantesTotais = usuario.HorasTotais - atividade.qtdHorasUtilizadas;
                            _usuarioRepository.UpdateAsync(usuario);
                        }
                        else
                        {
                            throw new BadHttpRequestException("nao e possivel adiconar horas alem do total.");
                        }
                    }
                    else
                    {
                        throw new BadHttpRequestException("Horas de outras atividades ja batidas.");
                    }
                }
                else
                {
                    throw new BadHttpRequestException("Horas totais ja batidas.");
                }

                break;
            case CategoriaAtividadeComplementarEnum.VivenciasDeGestao:
                if (usuario.horasRestantesTotais > 0)
                {
                    if (usuario.horasRestantesDeVivenciasDeGestao > 0)
                    {
                        if (usuario.horasRestantesDeVivenciasDeGestao >= atividade.qtdHorasUtilizadas)
                        {
                            usuario.horasRestantesDeVivenciasDeGestao -= atividade.qtdHorasUtilizadas;
                            usuario.horasRestantesTotais = usuario.HorasTotais - atividade.qtdHorasUtilizadas;
                            _usuarioRepository.UpdateAsync(usuario);
                        }
                        else
                        {
                            throw new BadHttpRequestException("nao e possivel adiconar horas alem do total.");
                        }
                    }
                    else
                    {
                        throw new BadHttpRequestException("Horas de vivências de gestão ja batidas.");
                    }
                }
                else
                {
                    throw new BadHttpRequestException("Horas totais ja batidas.");
                }

                break;
            default:
                throw new BadHttpRequestException("Tipo de atividade complementar não reconhecido.");
        }
    }
}