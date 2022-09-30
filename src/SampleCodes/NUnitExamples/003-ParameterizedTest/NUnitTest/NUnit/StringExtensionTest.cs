using CSD.Extensions.String;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace CSD.Test.NUnit
{
    public class DataInfo {
        public string Text { get; set; }
        public bool Result { get; set; }
    }

    [TestFixture]
    public class StringExtensionTest
    {
        private static List<DataInfo> m_dataInfoList;        

        public static IEnumerable<DataInfo> DataInfo
        {
            get {
                foreach (var dataInfo in m_dataInfoList)
                    yield return dataInfo;
            }
        }

        static StringExtensionTest()
        {
            m_dataInfoList = new List<DataInfo>();
            using var streamReader = new StreamReader("setup-ispalindrome.txt");

            string line;

            while ((line = streamReader.ReadLine()) != null)
            {
                var dataInfoStr = line.Split("@");
                m_dataInfoList.Add(new DataInfo { Text = dataInfoStr[0], Result = bool.Parse(dataInfoStr[1]) });
            }
        }       
        
        [Test, TestCaseSource("DataInfo")]
        public void TestIsPalindrome(DataInfo dataInfo)
        {
            Assert.AreEqual(dataInfo.Result, dataInfo.Text.IsPalindrome());
        }


        [TearDown]
        public void TearDown()
        {
            m_dataInfoList.Clear();
        }
    }
}
