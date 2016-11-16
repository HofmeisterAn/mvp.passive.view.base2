using System.Runtime.InteropServices;
using System.Security;

namespace Mvp.Passive.Default.Midelware.Extension
{
    public static class SecureStringExtension
    {
        /// <summary>
        /// Wandelt eine Zeichenkette vom Typ SecureString in string und gibt diesen zurück.
        /// </summary>
        /// <param name="source">Zeichenkette vom Typ SecureString.</param>
        /// <returns>Einfache Zeichenkette vom Typ string.</returns>
        public static string ToInsecureString(this SecureString source)
        {
            string returnValue;

            var ptr = Marshal.SecureStringToBSTR(source);

            try
            {
                returnValue = Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                Marshal.ZeroFreeBSTR(ptr);
            }

            return returnValue;
        }
    }
}
