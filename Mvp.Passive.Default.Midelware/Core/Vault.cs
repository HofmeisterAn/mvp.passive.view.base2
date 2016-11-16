using Mvp.Passive.Default.Midelware.Extension;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace Mvp.Passive.Default.Midelware.Core
{
    public static class Vault
    {
        private static byte[] GUID
        {
            get
            {
                var assembly = Assembly.GetExecutingAssembly();
                var bytes = ((GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0]).Value.ToBytes();

                Array.Reverse(bytes, 0, bytes.Length);
                return bytes;
            }
        }

        private static DataProtectionScope ProtectionScope
        {
            get
            {
                return DataProtectionScope.LocalMachine;
            }
        }

        public static SecureString Decrypt(string encryptedData)
        {
            try
            {
                var decryptedData = ProtectedData.Unprotect(Convert.FromBase64String(encryptedData), GUID, ProtectionScope);
                return (Encoding.Unicode.GetString(decryptedData).ToSecureString());
            }
            catch
            {
                return new SecureString();
            }
        }

        public static SecureString Decrypt(SecureString encryptedData)
        {
            return Vault.Decrypt(encryptedData.ToInsecureString());
        }

        public static string Encrypt(string unencryptedData)
        {
            return Vault.Encrypt(unencryptedData.ToSecureString());
        }

        public static string Encrypt(SecureString unencryptedData)
        {
            var encryptedData = ProtectedData.Protect(Encoding.Unicode.GetBytes(unencryptedData.ToInsecureString()), GUID, ProtectionScope);
            return Convert.ToBase64String(encryptedData);
        }
    }
}
