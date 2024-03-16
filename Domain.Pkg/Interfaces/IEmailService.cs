using Domain.Pkg.Model;

namespace Domain.Pkg.Interfaces;

public interface IEmailService
{
    Task<bool> SendEmail(ToEnvioEmailModel envioEmailModel, FromEnvioEmailModel fromEnvioEmailModel);
}
