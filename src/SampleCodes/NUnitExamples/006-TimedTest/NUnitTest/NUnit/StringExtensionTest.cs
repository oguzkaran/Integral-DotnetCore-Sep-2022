using CSD.Extensions.String;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

using static NUnit.Framework.Assert;

namespace CSD.Test.NUnit
{
    [TestFixture]
    [Author("Oğuz KARAN", "oguzkaran@csystem.org")]
    [Author("Onur Ulusoy", "onurulusoy@csystem.org")]
    public class StringExtensionTest
    {
        public static IEnumerable<Tuple<string, bool>> DataInfo
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
        [Test, TestCaseSource("DataInfo"), MaxTime(1000)]        
        public void TestIsPalindrome(Tuple<string, bool> dataInfo)
        {
            Thread.Sleep(1500); // Durumu göstermek için bekletme yapılıyor
            AreEqual(dataInfo.Item2, dataInfo.Item1.IsPalindrome());
        }       
    }
}
