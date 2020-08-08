using CensusAnalyserProblem;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CensusAnalyserProblemTest
{
    public class CensusAnalyserTest
    {
        CensusAnalyser censusAnalyser;
        string csvFilePath = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Data\IndiaStateCensusData.csv";
        string invalidCsvFilePath = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\IndiaStateCensusData.csv";
        string nonCSVFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblem\CensusAnalyser.cs";
        string wrongDelemeterFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Data\IncorrectDelimeters.csv";
        string wrongHeaderFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Data\IncorrectHeaders.csv";
        string indianStateCodeFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Data\IndiaStateCode.csv";

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            string[] totalRecord = censusAnalyser.loadIndianCensusData(csvFilePath);
            Assert.AreEqual(29, totalRecord.Length);
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileNotExist_ShouldThrowException()
        {
            try 
            {
                censusAnalyser.loadIndianCensusData(invalidCsvFilePath);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.type);
            }
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsIncorrect_ShouldThrowException()
        {
            try
            {
                censusAnalyser.loadIndianCensusData(nonCSVFile);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT, e.type);
            }
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowException()
        {
            try
            {
                censusAnalyser.loadIndianCensusData(wrongDelemeterFile);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, e.type);
            }
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowException()
        {
            try
            {
                censusAnalyser.loadIndianCensusData(wrongHeaderFile);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, e.type);
            }
        }

        //Indian StateCode Data
        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            IEnumerable<string> indianStateCodeRecord = censusAnalyser.loadIndianStateCodeData(indianStateCodeFile);
            Assert.AreEqual(37, indianStateCodeRecord.Count());
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileNotExist_ShouldThrowException()
        {
            try
            {
                censusAnalyser.loadIndianStateCodeData(invalidCsvFilePath);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.type);
            }
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsIncorrect_ShouldThrowException()
        {
            try
            {
                censusAnalyser.loadIndianStateCodeData(nonCSVFile);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT, e.type);
            }
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowException()
        {
            try
            {
                censusAnalyser.loadIndianStateCodeData(wrongDelemeterFile);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, e.type);
            }
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowException()
        {
            try
            {
                censusAnalyser.loadIndianStateCodeData(wrongHeaderFile);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, e.type);
            }
        }
    }
}