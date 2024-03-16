using Domain.Pkg.Entities;
using Domain.Pkg.Model;

namespace Domain.Pkg.Interfaces;

public interface IEmailService
{
    Task<bool> SendEmail(EnvioEmailModel envioEmailModel, ConfiguracaoDeEmail configuracaoDeEmail);
}
