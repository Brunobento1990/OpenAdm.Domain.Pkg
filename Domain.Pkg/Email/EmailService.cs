using System.Net;
using System.Net.Mail;

namespace Domain.Pkg.Email;

public class EmailService
{
    private MailMessage? _mailMessage;
    private string _from = string.Empty;
    private string _to = string.Empty;
    private string _subject = string.Empty;
    private string _password = string.Empty;
    private string _body = string.Empty;
    private string _servidor = string.Empty;
    private int _porta;
    private string? _nomeDoArquivo;
    private string? _tipoDoArquivo;
    private byte[]? _arquivo;
    private bool _enableSsl = false;
    private bool _useDefaultCredentials = false;

    public EmailService UseDefaultCredentials(bool useDefaultCredentials)
    {
        _useDefaultCredentials = useDefaultCredentials;
        return this;
    }

    public EmailService Password(string password)
    {
        _password = password;
        return this;
    }

    private void ValidSend()
    {
        if (string.IsNullOrWhiteSpace(_to) ||
            string.IsNullOrWhiteSpace(_from) ||
            string.IsNullOrWhiteSpace(_password) ||
            string.IsNullOrWhiteSpace(_servidor) ||
            _porta == 0)
        {
            throw new Exception("Configurações de e-mail inválidas!");
        }
    }

    public async Task<bool> SendAsync()
    {
        try
        {
            ValidSend();

            _mailMessage = new MailMessage(_from, _to)
            {
                Subject = _subject,
                SubjectEncoding = System.Text.Encoding.GetEncoding("UTF-8"),
                BodyEncoding = System.Text.Encoding.GetEncoding("UTF-8"),
                Body = _body
            };

            if (_arquivo != null && !string.IsNullOrWhiteSpace(_nomeDoArquivo) && !string.IsNullOrWhiteSpace(_tipoDoArquivo))
            {
                var anexo = new Attachment(new MemoryStream(_arquivo), _nomeDoArquivo, _tipoDoArquivo);
                _mailMessage.Attachments.Add(anexo);
            }

            var smtp = new SmtpClient(_servidor, _porta);
            smtp.EnableSsl = _enableSsl;
            smtp.UseDefaultCredentials = _useDefaultCredentials;
            smtp.Credentials = new NetworkCredential(_from, _password);
            await smtp.SendMailAsync(_mailMessage);

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public EmailService EnableSsl(bool enableSsl)
    {
        _enableSsl = enableSsl;
        return this;
    }

    public EmailService Porta(int porta)
    {
        _porta = porta;
        return this;
    }

    public EmailService Anexo(byte[] arquivo, string tipoDoArquivo, string nomeArquivo)
    {
        _nomeDoArquivo = nomeArquivo;
        _tipoDoArquivo = tipoDoArquivo;
        _arquivo = arquivo;

        return this;
    }

    public EmailService Servidor(string servidor)
    {
        _servidor = servidor;
        return this;
    }

    public EmailService Body(string body)
    {
        _body = body;
        return this;
    }

    public EmailService From(string from)
    {
        _from = from;
        return this;
    }

    public EmailService To(string to)
    {
        _to = to;
        return this;
    }

    public EmailService Subject(string subject)
    {
        _subject = subject;
        return this;
    }
}
