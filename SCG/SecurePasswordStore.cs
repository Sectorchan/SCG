using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PL;

public static class SecurePasswordStore
{
    #region Private Members 
    private const int KeySize = 32; // 256 Bit
    private const int SaltSize = 16;
    private const int IvSize = 16;
    private const int Iterations = 100_000;
    private const string FilePath = "encrypted.dat";

    #endregion
    
    public static string SavePassword(string plainPassword, string masterPassword)
    {
        // 1. Salt und IV generieren
        byte[] salt = GenerateRandomBytes(SaltSize);
        byte[] iv = GenerateRandomBytes(IvSize);

        // 2. Schlüssel aus Masterpasswort + Salt ableiten
        byte[] key = DeriveKey(masterPassword, salt);

        // 3. Passwort verschlüsseln
        byte[] encrypted = EncryptStringToBytes_Aes(plainPassword, key, iv);

        // 4. Salt + IV + verschlüsselte Daten speichern (Base64 getrennt mit :)
        string output = $"{Convert.ToBase64String(salt)}:{Convert.ToBase64String(iv)}:{Convert.ToBase64String(encrypted)}";
        return output;
    }

    // Passwort entschlüsseln
    public static string LoadPassword(string encryptedPassword, string masterPassword)
    {
        //if (!File.Exists(FilePath))
        //    throw new FileNotFoundException("Verschlüsselte Datei nicht gefunden.");

        //string input = File.ReadAllText(FilePath);
        string[] parts = encryptedPassword.Split(':');
        if (parts.Length != 3)
            throw new FormatException("Dateiformat ungültig.");

        byte[] salt = Convert.FromBase64String(parts[0]);
        byte[] iv = Convert.FromBase64String(parts[1]);
        byte[] cipherText = Convert.FromBase64String(parts[2]);

        byte[] key = DeriveKey(masterPassword, salt);
        return DecryptStringFromBytes_Aes(cipherText, key, iv);
    }

    // Schlüssel ableiten
    private static byte[] DeriveKey(string password, byte[] salt)
    {
        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
        return pbkdf2.GetBytes(KeySize);
    }

    // Verschlüsselung
    private static byte[] EncryptStringToBytes_Aes(string plainText, byte[] key, byte[] iv)
    {
        using var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;

        using ICryptoTransform encryptor = aes.CreateEncryptor();
        using var ms = new MemoryStream();
        using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
        using var sw = new StreamWriter(cs);
        sw.Write(plainText);
        sw.Close();
        return ms.ToArray();
    }

    // Entschlüsselung
    private static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] key, byte[] iv)
    {
        using var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;

        using ICryptoTransform decryptor = aes.CreateDecryptor();
        using var ms = new MemoryStream(cipherText);
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);
        return sr.ReadToEnd();
    }

    private static byte[] GenerateRandomBytes(int length)
    {
        byte[] data = new byte[length];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(data);
        return data;
    }
}
