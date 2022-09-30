using CSD.Extensions.String;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.IO;

namespace CSD.Test.NUnit
{    
    [TestFixture]
    public class StringExtensionTest
    {
        private readonly List<DataInfo> m_dataInfoList = new();
        private class DataInfo { 
            public string Text { get; set; }
            public bool Result { get; set; }
        }
        
        [SetUp]
        public void SetUp()
        {
            using var streamReader = new StreamReader("setup-ispalindrome.txt");

            string line;

            while ((line = streamReader.ReadLine()) != null)
            {
                var dataInfoStr = line.Split("@");
                m_dataInfoList.Add(new DataInfo { Text = dataInfoStr[0], Result = bool.Parse(dataInfoStr[1]) });
            }
        }

        [Ignore("Tested before")]
        [Test]
        public void TestRemoveWhitespaces()
        {
            var text = "Bugün hava çok güzel";
            var expectedResult = "Bugünhavaçokgüzel";

            Assert.AreEqual(expectedResult, text.RemoveWhitespaces());
        }

       // [Ignore("Tested before")]
        [Test]
        public void TestGetLetters()
        {
            var text = "ey edip adana'da pide ye";
            var expected = "eyedipadanadapideye";

            Assert.AreEqual(expected, text.GetLetters());
        }

        [Ignore("Tested before", Until = "2022-09-12 22:06")]
        [Test]
        public void TestIsPalindrome()
        {
            foreach (var dataInfo in m_dataInfoList)
                Assert.AreEqual(dataInfo.Result, dataInfo.Text.IsPalindrome());
        }


        [TearDown]
        public void TearDown()
        {
            //...            
        }
    }
}
