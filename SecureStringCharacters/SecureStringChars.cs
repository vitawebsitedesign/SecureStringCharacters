using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading.Tasks;

namespace SecureStringCharacters
{
    public static class SecureStringExtensions
    {
        public static void ForEachChar(this SecureString str, Action<object> action)
        {
            for (var i = 0; i < str.Length; i++)
            {
                action(str.GetChar(i));
            }
        }

        public static async Task ForEachCharAsync(this SecureString str, Func<object, Task> action)
        {
            for (var i = 0; i < str.Length; i++)
            {
                await action(str.GetChar(i));
            }
        }

        public static char? GetChar(this SecureString str, int charIndex)
        {
            if (str == null)
            {
                throw new NullReferenceException(nameof(str));
            }
            if (charIndex < 0 || charIndex > str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(charIndex));
            }

            var ptr = Marshal.SecureStringToBSTR(str);
            var offset = charIndex * 2;
            byte? b = null;

            try
            {
                b = Marshal.ReadByte(ptr, offset);
            }
            catch
            {
                throw;
            }
            finally
            {
                Marshal.ZeroFreeBSTR(ptr);
            }

            return (char)b;
        }
    }
}
