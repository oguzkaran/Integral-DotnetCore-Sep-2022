using CSD.Extensions.String;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using static NUnit.Framework.Assert;

namespace CSD.Test.NUnit
{
    [TestFixture]
    [Author("Oğuz KARAN", "oguzkaran@csystem.org")]
    [Author("Onur Ulusoy", "onurulusoy@csystem.org")]
    public class StringExtensionTest
    {
        public static IEnumerable<Tuple<string, bool>> Source
        {
            get {
                var streamReader = new StreamReader("setup-ispalindrome.txt");

                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    var dataInfoStr = line.Split("@");
                    yield return new Tuple<string, bool>(dataInfoStr[0], bool.Parse(dataInfoStr[1]));
                }                
            }
        }

        [Author("Başak Pınar", "basakpinar@csystem.org")]
        [Test, TestCaseSource("Source")]
        public void TestIsPalindrome(Tuple<string, bool> dataInfo)
        {
            AreEqual(dataInfo.Item2, dataInfo.Item1.IsPalindrome());
        }        
    }
}
