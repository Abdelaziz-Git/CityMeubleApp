using System.Security.Cryptography;

public static class clsPasswordHelper
{
    /// <summary>
    /// Generates a PBKDF2 SHA-256 hash of the plaintext password,
    /// prepends the 16-byte random salt, and returns a 48-byte array
    /// (salt || hash) encoded as Base64.
    /// </summary>
    public static string HashPassword(string password)
    {
        // 1. Generate a 16-byte random salt
        byte[] salt = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        // 2. Run PBKDF2-SHA256 for 100,000 iterations, derive a 32-byte key
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256))
        {
            byte[] hash = pbkdf2.GetBytes(32);

            // 3. Combine salt + hash into a single 48-byte array
            byte[] saltPlusHash = new byte[16 + 32];
            Buffer.BlockCopy(salt, 0, saltPlusHash, 0, 16);
            Buffer.BlockCopy(hash, 0, saltPlusHash, 16, 32);

            // 4. Return as Base64 string for storage
            return Convert.ToBase64String(saltPlusHash);
        }
    }

    /// <summary>
    /// Given a plaintext password and a stored Base64 string (16-byte salt + 32-byte hash),
    /// re-derives the PBKDF2-SHA256 hash and returns true if they match.
    /// </summary>
    public static bool VerifyPassword(string enteredPassword, string storedBase64SaltPlusHash)
    {
        // 1. Decode the stored Base64 back to 48 bytes
        byte[] saltPlusHash;
        try
        {
            saltPlusHash = Convert.FromBase64String(storedBase64SaltPlusHash);
        }
        catch
        {
            return false; // Invalid Base64 format
        }

        if (saltPlusHash.Length != 48)
            return false; // Unexpected length

        // 2. Split into the 16-byte salt and the 32-byte stored hash
        byte[] salt = new byte[16];
        byte[] storedHash = new byte[32];
        Buffer.BlockCopy(saltPlusHash, 0, salt, 0, 16);
        Buffer.BlockCopy(saltPlusHash, 16, storedHash, 0, 32);

        // 3. Re-derive a 32-byte hash from the entered password + the extracted salt
        byte[] computedHash;
        using (var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 100_000, HashAlgorithmName.SHA256))
        {
            computedHash = pbkdf2.GetBytes(32);
        }

        // 4. Compare storedHash vs. computedHash in constant time
        int diff = 0;
        for (int i = 0; i < 32; i++)
        {
            diff |= storedHash[i] ^ computedHash[i];
        }

        return diff == 0;
    }
}
