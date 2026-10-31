using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TailorSoft.Activation
{
    public static class LicenseValidator
    {
        public static bool Validate(string path)
        {
            if (!File.Exists(path))
                return false;

            string json = File.ReadAllText(path);

            var wrapper = JsonSerializer.Deserialize<LicenseWrapper>(json);

            string publicKey = @"-----BEGIN RSA PUBLIC KEY-----
MIIBCgKCAQEA2YzloXCEdw06YoEqOOjVAHmxAe3IkHr7301nKdChXTux3igkeEHA
sVAkUeRBveypGlvYG0B6TgfQmUA5CkF3fVf3wGE/TQtuFvwU/Oxv/kvTf+Si9lPm
pG2XLNDGNF4wtsuY8B+SVTwk+D0Tw5asVuT6UM7k0FqRjvXS7bVc7r1OSQjFtgBI
R4ZH/IeqSudoiwRkYUIyJnxtdZ0Yq0TaA2KptjpztOjOHLrzbgiJjQRpNndYxBm0
JaL6ZddNlk9lzKYfruR2blYGSayRitXEYILI9iwtQw0gHmxBb5gTmDrWtiVkr+kw
mlj2KPXZhQxpf0NgWlyz4RrcOMnnwokxiQIDAQAB
-----END RSA PUBLIC KEY-----";

            var rsa = RSA.Create();
            rsa.ImportFromPem(publicKey);

            bool valid = rsa.VerifyData(
                Encoding.UTF8.GetBytes(wrapper?.Data??""),
                Convert.FromBase64String(wrapper?.Signature??""),
                HashAlgorithmName.SHA256,
                RSASignaturePadding.Pkcs1);

            if (!valid)
                return false;

            var license = JsonSerializer.Deserialize<License>(wrapper?.Data??"");

            if (license?.MachineId != MachineIdProvider.GetMachineId())
                return false;

            return true;
        }
        class License
        {
            public string? CustomerName { get; set; }
            public string? MachineId { get; set; }
        }

        class LicenseWrapper
        {
            public string? Data { get; set; }
            public string? Signature { get; set; }
        }
    }

   
}
