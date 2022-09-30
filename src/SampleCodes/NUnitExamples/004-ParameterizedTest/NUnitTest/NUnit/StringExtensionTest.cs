using CSD.Extensions.String;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.IO;
using static NUnit.Framework.Assert;

namespace CSD.Test.NUnit
{
    public class DataInfo {
        public string Text { get; set; }
        public bool Result { get; set; }
    }

    [TestFixture]
    public class StringExtensionTest
    {
        public static IEnumerable<DataInfo> Source
        {
            get {
                var streamReader = new StreamReader("setup-ispalindrome.txt");

                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    var dataInfoStr = line.Split("@");
                    yield return new DataInfo { Text = dataInfoStr[0], Result = bool.Parse(dataInfoStr[1]) };
                }                
            }
        }        
        
        [Test, TestCaseSource("Source")]
        public void TestIsPalindrome(DataInfo dataInfo)
        {
            AreEqual(dataInfo.Result, dataInfo.Text.IsPalindrome());
        }       
    }
}
