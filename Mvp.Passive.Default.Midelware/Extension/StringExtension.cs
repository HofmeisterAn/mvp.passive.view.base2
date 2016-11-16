using Mvp.Passive.Default.Midelware.Core;
using System.Security;

namespace Mvp.Passive.Default.Midelware.Extension
{
    public static class StringExtension
    {
        /// <summary>
        /// Erzeugt ein Byte-Array und gibt dieses zurück.
        /// </summary>
        /// <param name="source">Zeichenkette</param>
        /// <returns>Byte-Array aus der Zeichenkette.</returns>
        internal static byte[] ToBytes(this string source)
        {
            var bytes = new byte[source.Length * sizeof(char)];
            System.Buffer.BlockCopy(source.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        /// <summary>
        /// Wandelt eine Zeichenkette vom Typ string in SecureString und gibt diesen zurück.
        /// </summary>
        /// <param name="source">Einfache Zeichenkette vom Typ string.</param>
        /// <returns>Zeichenkette vom Typ SecureString.</returns>
        internal static SecureString ToSecureString(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return null;
            }

            var Result = new SecureString();

            foreach (var c in source)
            {
                Result.AppendChar(c);
            }

            return Result;
        }

        /// <summary>
        /// Verschlüsselt die Zeichenkette mit der DPAPI.
        /// </summary>
        /// <param name="source">Klartext Zeichenkette.</param>
        /// <returns>Verschlüsselte Zeichenkette</returns>
        public static string ToEncryptString(this string source)
        {
            return Vault.Encrypt(source);
        }

        /// <summary>
        /// Entschlüsselt die Zeichenkette mit der DPAPI.
        /// </summary>
        /// <param name="source">Verschlüsselte Zeichenkette.</param>
        /// <returns>Klartext der verschlüsselten Zeichenkette</returns>
        public static string ToDecryptString(this string source)
        {
            return Vault.Decrypt(source).ToInsecureString();
        }
    }
}
