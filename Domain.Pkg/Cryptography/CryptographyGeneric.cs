using System.Security.Cryptography;
using System.Text;

namespace Domain.Pkg.Cryptography;

public static class CryptographyGeneric
{
    private static readonly string key = "ea66738f-2273-4ac3-bc44-ded03b5c";
    private static readonly string iv = "8187600c-78c1-4c";
    public static string Encrypt(string plainText)
    {
        using var aesAlg = Aes.Create();
        aesAlg.Key = GetBytes(key);
        aesAlg.IV = GetBytes(iv);

        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        using var encrypt = new MemoryStream();
        using var csEncrypt = new CryptoStream(encrypt, encryptor, CryptoStreamMode.Write);
        using var swEncrypt = new StreamWriter(csEncrypt);

        swEncrypt.Write(plainText);
        swEncrypt.Close();
        csEncrypt.Close();

        return Convert.ToBase64String(encrypt.ToArray());
    }

    public static string Decrypt(string cipherText)
    {
        using Aes aesAlg = Aes.Create();
        aesAlg.Key = GetBytes(key);
        aesAlg.IV = GetBytes(iv);
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
        using var msDecrypt = new MemoryStream(cipherBytes);
        using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        using var srDecrypt = new StreamReader(csDecrypt);

        return srDecrypt.ReadToEnd();
    }

    private static byte[] GetBytes(string key) => Encoding.UTF8.GetBytes(key);
}
