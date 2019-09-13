using NUnit.Framework;
using System;
using System.Security;

namespace SecureStringCharacters.Tests
{
    public class Tests
    {
        public void GetChar_ThrowsException_ForNullString()
        {
            SecureString str = null;
            Assert.Throws<NullReferenceException>(() => str.GetChar(0));
        }

        [TestCase("", -1)]
        [TestCase("a", 2)]
        public void GetChar_ThrowsException_ForInvalidIndex(string clearText, int index)
        {
            var str = ClearTextToSecureString(clearText);
            Assert.Throws<ArgumentOutOfRangeException>(() => str.GetChar(index));
        }

        [TestCase("", 0)]
        [TestCase("a", 1)]
        [TestCase("aa", 2)]
        public void GetChar_StringTerminatorIndex_HandledCorrectly(string clearText, int index)
        {
            var str = ClearTextToSecureString(clearText);
            char? c = null;
            Assert.DoesNotThrow(() => c = str.GetChar(index));
            Assert.NotNull(c);
            Assert.AreEqual('\0', c);
        }

        [TestCase("", 0, '\0')]
        [TestCase(" ", 1, '\0')]
        [TestCase("cat", 0, 'c')]
        [TestCase("cat", 1, 'a')]
        [TestCase("cat", 2, 't')]
        [TestCase("cat", 3, '\0')]
        public void GetChar_ReturnsCorrectChar(string clearText, int index, char expected)
        {
            var str = ClearTextToSecureString(clearText);
            var actual = str.GetChar(index);
            Assert.AreEqual(expected, actual);
        }

        private SecureString ClearTextToSecureString(string clearText)
        {
            var str = new SecureString();
            foreach (var c in clearText.ToCharArray())
            {
                str.AppendChar(c);
            }
            return str;
        }
    }
}
