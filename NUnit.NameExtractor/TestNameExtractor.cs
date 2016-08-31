using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NameExtractor;
using NameExtractor.Enums;
using NameExtractor.Exceptions;
using NameExtractor.Interfaces;

namespace NUnit.NameExtractor
{
    [TestFixture]
    public class TestNameExtractor
    {
        [Test, Description("Testing the case with only LastName")]
        public void ExtractRule1()
        {
            INameProvider nameProvider = new NameProvider("LastName");
            var nameExtractor = new global::NameExtractor.NameExtractor(nameProvider);
            var nameExtractionResult = nameExtractor.Extract();

            Assert.AreEqual("LastName", nameExtractionResult.LastName);
            Assert.AreEqual(string.Empty, nameExtractionResult.FirstName ?? "");
            Assert.AreEqual(EnumTitle.Unknown, nameExtractionResult.Title);
            Assert.Pass("Business Rule 1 - Passed");
        }

        [Test, Description("Testing the case with Title and LastName")]
        public void ExtractRule2()
        {
            INameProvider nameProvider = new NameProvider("Mr. LastName");
            var nameExtractor = new global::NameExtractor.NameExtractor(nameProvider);
            var nameExtractionResult = nameExtractor.Extract();

            Assert.AreEqual(EnumTitle.Mr, nameExtractionResult.Title);
            Assert.AreEqual("LastName", nameExtractionResult.LastName);
            Assert.AreEqual(string.Empty, nameExtractionResult.FirstName ?? "");

            Assert.Pass("Business Rule 2 - Passed");
        }

        [Test, Description("Testing the case with FirstName, LastName and 3th other word")]
        public void ExtractRule3()
        {
            INameProvider nameProvider = new NameProvider("FirstName LastName ppp");
            var nameExtractor = new global::NameExtractor.NameExtractor(nameProvider);
            var nameExtractionResult = nameExtractor.Extract();

            Assert.AreEqual("FirstName", nameExtractionResult.FirstName);
            Assert.AreEqual("LastName", nameExtractionResult.LastName);
            Assert.AreEqual(EnumTitle.Unknown, nameExtractionResult.Title);
            Assert.Pass("Business Rule 3 - Passed");
        }

        [Test, Description("Testing the case with Title, FirstName and LastName")]
        public void ExtractRule4()
        {
            INameProvider nameProvider = new NameProvider("Miss. FirstName LastName");
            var nameExtractor = new global::NameExtractor.NameExtractor(nameProvider);
            var nameExtractionResult = nameExtractor.Extract();
            

            Assert.AreEqual(EnumTitle.Miss, nameExtractionResult.Title);
            Assert.AreEqual("FirstName", nameExtractionResult.FirstName);
            Assert.AreEqual("LastName", nameExtractionResult.LastName);

            Assert.Pass("Business Rule 4 - Passed");
        }

        [Test, Description("Testing the case with more than 3 wards")]
        public void ExtractRule5()
        {
            Assert.Throws<MoreThanThreeWordsException>(new TestDelegate(ExceptionThrowMethodRule5));
            Assert.Pass("Business Rule 5 - Passed");
        }

        void ExceptionThrowMethodRule5()
        {
            INameProvider nameProvider = new NameProvider("Miss. FirstName LastName aaa");
            var nameExtractor = new global::NameExtractor.NameExtractor(nameProvider);
            var nameExtractionResult = nameExtractor.Extract();
        }
    }
}
