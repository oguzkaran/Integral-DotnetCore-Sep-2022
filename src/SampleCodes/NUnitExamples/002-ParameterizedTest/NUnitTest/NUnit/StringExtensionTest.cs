using CSD.Extensions.String;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace CSD.Test.NUnit
{    
    [TestFixture("Ey edip Adana'da pide ye", true)]
    [TestFixture("Oğuz karan", false)]
    [TestFixture("Ali Papila")]
    public class StringExtensionTest
    {
        private string m_text;
        private bool m_result;

        public StringExtensionTest(string text) : this(text, true)
        {
        }

        public StringExtensionTest(string text, bool result)
        {
            m_text = text;
            m_result = result;
        }

        [Test]
        public void TestIsPalindrome1()
        {
            Assert.AreEqual(m_result, m_text.IsPalindrome());
        }

        [Test]
        public void TestIsPalindrome2()
        {   
            if (m_result)
                Assert.IsTrue(m_text.IsPalindrome());
        }
    }
}
