using System.Security.Cryptography;
using System.Text;

/// <summary>
/// CryptoHelper — A reusable encryption/decryption utility class.
/// Supports: AES-256-CBC, RSA (2048-bit), and HMAC-SHA256 signing.
/// </summary>
public static class clsCryptoHelper
{
    // ─────────────────────────────────────────────────
    //  AES-256 (Symmetric) — fast, ideal for text/data
    // ─────────────────────────────────────────────────

    /// <summary>
    /// Generates a cryptographically secure random AES key (256-bit) and IV (128-bit).
    /// </summary>
    public static (string Base64Key, string Base64IV) GenerateAesKeyAndIV()
    {
        using var aes = Aes.Create();
        aes.KeySize = 256;
        aes.GenerateKey();
        aes.GenerateIV();
        return (Convert.ToBase64String(aes.Key), Convert.ToBase64String(aes.IV));
    }

    /// <summary>
    /// Encrypts plain text using AES-256-CBC.
    /// </summary>
    /// <param name="plainText">The text to encrypt.</param>
    /// <param name="base64Key">256-bit key as a Base64 string.</param>
    /// <param name="base64IV">128-bit IV as a Base64 string.</param>
    /// <returns>Encrypted cipher text encoded as Base64.</returns>
    public static string AesEncrypt(string plainText, string base64Key, string base64IV)
    {
        if (string.IsNullOrEmpty(plainText)) throw new ArgumentNullException(nameof(plainText));

        byte[] key = Convert.FromBase64String(base64Key);
        byte[] iv = Convert.FromBase64String(base64IV);

        using var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        using var encryptor = aes.CreateEncryptor();
        using var ms = new MemoryStream();
        using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
        using (var sw = new StreamWriter(cs, Encoding.UTF8))
            sw.Write(plainText);

        return Convert.ToBase64String(ms.ToArray());
    }

    /// <summary>
    /// Decrypts AES-256-CBC cipher text back to plain text.
    /// </summary>
    public static string AesDecrypt(string cipherBase64, string base64Key, string base64IV)
    {
        if (string.IsNullOrEmpty(cipherBase64)) throw new ArgumentNullException(nameof(cipherBase64));

        byte[] key = Convert.FromBase64String(base64Key);
        byte[] iv = Convert.FromBase64String(base64IV);
        byte[] cipherText = Convert.FromBase64String(cipherBase64);

        using var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        using var decryptor = aes.CreateDecryptor();
        using var ms = new MemoryStream(cipherText);
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs, Encoding.UTF8);
        return sr.ReadToEnd();
    }

    // ─────────────────────────────────────────────────
    //  AES with Password (PBKDF2 key derivation)
    //  — no need to store/share a raw key
    // ─────────────────────────────────────────────────

    private const int SaltSize = 16; // bytes
    private const int Pbkdf2Iters = 600_000;
    private const int AesKeyBytes = 32; // 256-bit
    private const int AesIVBytes = 16; // 128-bit

    /// <summary>
    /// Encrypts text using a user-supplied password (key is derived via PBKDF2-HMAC-SHA256).
    /// The salt and IV are prepended to the output — no need to store them separately.
    /// </summary>
    /// <returns>Base64-encoded blob: [salt (16)] + [IV (16)] + [cipherText]</returns>
    public static string EncryptWithPassword(string plainText, string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);

        using var kdf = new Rfc2898DeriveBytes(
            password, salt, Pbkdf2Iters, HashAlgorithmName.SHA256);

        byte[] key = kdf.GetBytes(AesKeyBytes);
        byte[] iv = kdf.GetBytes(AesIVBytes);

        using var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;

        using var encryptor = aes.CreateEncryptor();
        using var ms = new MemoryStream();

        ms.Write(salt, 0, salt.Length); // prepend salt
        ms.Write(iv, 0, iv.Length);   // prepend IV

        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        using (var sw = new StreamWriter(cs, Encoding.UTF8))
            sw.Write(plainText);

        return Convert.ToBase64String(ms.ToArray());
    }

    /// <summary>
    /// Decrypts a blob produced by <see cref="EncryptWithPassword"/>.
    /// </summary>
    public static string DecryptWithPassword(string cipherBase64, string password)
    {
        byte[] blob = Convert.FromBase64String(cipherBase64);

        byte[] salt = blob.Take(SaltSize).ToArray();
        byte[] iv = blob.Skip(SaltSize).Take(AesIVBytes).ToArray();
        byte[] data = blob.Skip(SaltSize + AesIVBytes).ToArray();

        using var kdf = new Rfc2898DeriveBytes(
            password, salt, Pbkdf2Iters, HashAlgorithmName.SHA256);

        byte[] key = kdf.GetBytes(AesKeyBytes);

        using var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;

        using var decryptor = aes.CreateDecryptor();
        using var ms = new MemoryStream(data);
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs, Encoding.UTF8);
        return sr.ReadToEnd();
    }

    // ─────────────────────────────────────────────────
    //  RSA (Asymmetric) — ideal for key exchange / small payloads
    // ─────────────────────────────────────────────────

    /// <summary>
    /// Generates an RSA 2048-bit key pair.
    /// </summary>
    /// <returns>Tuple of (PublicKeyXml, PrivateKeyXml)</returns>
    public static (string PublicKeyXml, string PrivateKeyXml) GenerateRsaKeyPair(int keySize = 2048)
    {
        using var rsa = RSA.Create(keySize);
        return (
            rsa.ToXmlString(includePrivateParameters: false),
            rsa.ToXmlString(includePrivateParameters: true)
        );
    }

    /// <summary>
    /// Encrypts text with an RSA public key (OAEP-SHA256 padding).
    /// Best for small payloads (≤ 190 bytes for 2048-bit key).
    /// </summary>
    public static string RsaEncrypt(string plainText, string publicKeyXml)
    {
        using var rsa = RSA.Create();
        rsa.FromXmlString(publicKeyXml);
        byte[] data = Encoding.UTF8.GetBytes(plainText);
        byte[] encrypted = rsa.Encrypt(data, RSAEncryptionPadding.OaepSHA256);
        return Convert.ToBase64String(encrypted);
    }

    /// <summary>
    /// Decrypts RSA-encrypted text with the private key.
    /// </summary>
    public static string RsaDecrypt(string cipherBase64, string privateKeyXml)
    {
        using var rsa = RSA.Create();
        rsa.FromXmlString(privateKeyXml);
        byte[] data = Convert.FromBase64String(cipherBase64);
        byte[] decrypted = rsa.Decrypt(data, RSAEncryptionPadding.OaepSHA256);
        return Encoding.UTF8.GetString(decrypted);
    }

    // ─────────────────────────────────────────────────
    //  HMAC-SHA256 — Signing / Integrity verification
    // ─────────────────────────────────────────────────

    /// <summary>
    /// Generates a random 256-bit HMAC signing key.
    /// </summary>
    public static string GenerateHmacKey()
        => Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));

    /// <summary>
    /// Computes an HMAC-SHA256 signature for the given text.
    /// </summary>
    public static string ComputeHmac(string text, string base64Key)
    {
        byte[] key = Convert.FromBase64String(base64Key);
        byte[] data = Encoding.UTF8.GetBytes(text);
        using var hmac = new HMACSHA256(key);
        return Convert.ToBase64String(hmac.ComputeHash(data));
    }

    /// <summary>
    /// Verifies an HMAC-SHA256 signature using a constant-time comparison.
    /// </summary>
    public static bool VerifyHmac(string text, string base64Key, string expectedSignature)
    {
        string actual = ComputeHmac(text, base64Key);
        return CryptographicOperations.FixedTimeEquals(
            Convert.FromBase64String(actual),
            Convert.FromBase64String(expectedSignature));
    }

    // ─────────────────────────────────────────────────
    //  SHA-256 / SHA-512 Hashing (one-way)
    // ─────────────────────────────────────────────────

    /// <summary>Returns the SHA-256 hex digest of the input string.</summary>
    public static string Sha256Hash(string input)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(bytes).ToLowerInvariant();
    }

    /// <summary>Returns the SHA-512 hex digest of the input string.</summary>
    public static string Sha512Hash(string input)
    {
        byte[] bytes = SHA512.HashData(Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(bytes).ToLowerInvariant();
    }
}

// ─────────────────────────────────────────────────────────────────────────────
//  USAGE EXAMPLES
// ─────────────────────────────────────────────────────────────────────────────
/*
class Program
{
    static void Main()
    {
        string original = "Hello, Secure World! 🔐";

        // ── 1. AES with raw key ──────────────────────────────────────────────
        var (key, iv) = CryptoHelper.GenerateAesKeyAndIV();
        string aesEncrypted = CryptoHelper.AesEncrypt(original, key, iv);
        string aesDecrypted = CryptoHelper.AesDecrypt(aesEncrypted, key, iv);
        Console.WriteLine($"[AES] Cipher : {aesEncrypted}");
        Console.WriteLine($"[AES] Decoded: {aesDecrypted}");

        // ── 2. AES with password (PBKDF2) ───────────────────────────────────
        string password   = "MyStrongPassw0rd!";
        string pwdCipher  = CryptoHelper.EncryptWithPassword(original, password);
        string pwdDecoded = CryptoHelper.DecryptWithPassword(pwdCipher, password);
        Console.WriteLine($"[PWD] Cipher : {pwdCipher}");
        Console.WriteLine($"[PWD] Decoded: {pwdDecoded}");

        // ── 3. RSA ───────────────────────────────────────────────────────────
        var (pub, priv)  = CryptoHelper.GenerateRsaKeyPair();
        string rsaCipher = CryptoHelper.RsaEncrypt(original, pub);
        string rsaPlain  = CryptoHelper.RsaDecrypt(rsaCipher, priv);
        Console.WriteLine($"[RSA] Cipher : {rsaCipher[..40]}...");
        Console.WriteLine($"[RSA] Decoded: {rsaPlain}");

        // ── 4. HMAC signing ──────────────────────────────────────────────────
        string hmacKey = CryptoHelper.GenerateHmacKey();
        string sig     = CryptoHelper.ComputeHmac(original, hmacKey);
        bool   valid   = CryptoHelper.VerifyHmac(original, hmacKey, sig);
        Console.WriteLine($"[HMAC] Signature: {sig[..20]}...");
        Console.WriteLine($"[HMAC] Valid    : {valid}");

        // ── 5. SHA hashing ───────────────────────────────────────────────────
        Console.WriteLine($"[SHA-256] {CryptoHelper.Sha256Hash(original)}");
        Console.WriteLine($"[SHA-512] {CryptoHelper.Sha512Hash(original)}");
    }
}
*/