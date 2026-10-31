using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace TailorSoft.Activation
{
    public static class MachineIdProvider
    {
        public static string GetMachineId()
        {
            var parts = new List<string>();

            // 1. Machine GUID (BEST SOURCE)
            string machineGuid = GetMachineGuid();
            if (!string.IsNullOrWhiteSpace(machineGuid))
                parts.Add(machineGuid);

            // 2. Computer Name (fallback)
            parts.Add(Environment.MachineName);

            // 3. User SID (adds uniqueness per Windows install/user context)
            parts.Add(GetUserSid());

            string raw = string.Join("|", parts);

            return Sha256(raw);
        }

        private static string GetMachineGuid()
        {
            try
            {
                using var key = Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\Microsoft\Cryptography");

                return key?.GetValue("MachineGuid")?.ToString() ?? "";
            }
            catch
            {
                return "";
            }
        }

        private static string GetUserSid()
        {
            try
            {
                return WindowsIdentity.GetCurrent().User?.Value ?? "";
            }
            catch
            {
                return "";
            }
        }

        private static string Sha256(string input)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToHexString(bytes);
        }
    }
}
