using Domain.Pkg.Entities.Bases;

namespace Domain.Pkg.Entities;

public sealed class AppLog : BaseEntity
{
    public AppLog(
        Guid id,
        DateTime dataDeCriacao,
        DateTime dataDeAtualizacao,
        long numero,
        string origem,
        string? latitude,
        string? longitude,
        string host,
        string ip,
        string path,
        string? erro,
        int statusCode,
        int logLevel,
        string? xApi) : base(id, dataDeCriacao, dataDeAtualizacao, numero)
    {
        Origem = origem;
        Latitude = latitude;
        Longitude = longitude;
        Host = host;
        Ip = ip;
        Path = path;
        Erro = erro;
        StatusCode = statusCode;
        LogLevel = logLevel;
        XApi = xApi;
    }

    public string Origem { get; private set; }
    public string? Latitude { get; private set; }
    public string? Longitude { get; private set; }
    public string Host { get; private set; }
    public string Ip { get; private set; }
    public string Path { get; private set; }
    public string? Erro { get; private set; }
    public int StatusCode { get; private set; }
    public int LogLevel { get; private set; }
    public string? XApi { get; private set; }
}
