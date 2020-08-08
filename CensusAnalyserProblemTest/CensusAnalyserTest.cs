using CensusAnalyserProblem;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CensusAnalyserProblemTest
{
    public class CensusAnalyserTest
    {
        CensusAnalyser censusAnalyser;
        string indianCensusDataHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        string indianStateCodeHeader = "SrNo,State Name,TIN,StateCode";
        string csvFilePath = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.csv";
        string invalidCsvFilePath = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\IndiaStateCensusData.csv";
        string nonCSVFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblem\CensusAnalyser.cs";
        string wrongDelemeterFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IncorrectDelimeters.csv";
        string wrongHeaderFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IncorrectHeaders.csv";
        string indianStateCodeFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCode.csv";
        string wrongIndianStateCodeFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\InCorrectIndiaStateCode.csv";

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            IEnumerable<string> indianCensusRecord = censusAnalyser.loadCSVFileData(indianCensusDataHeaders,csvFilePath);
            Assert.AreEqual(29, indianCensusRecord.Count());
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            try 
            {
                IEnumerable<string> indianCensusRecord = censusAnalyser.loadCSVFileData(indianCensusDataHeaders,invalidCsvFilePath);
                Assert.AreEqual(29, indianCensusRecord.Count());
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.type);
            }
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            try
            {
                IEnumerable<string> indianCensusRecord = censusAnalyser.loadCSVFileData(indianCensusDataHeaders,nonCSVFile);
                Assert.AreEqual(29, indianCensusRecord.Count());
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT, e.type);
            }
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            try
            {
                IEnumerable<string> indianCensusRecord = censusAnalyser.loadCSVFileData(indianCensusDataHeaders,wrongDelemeterFile);
                Assert.AreEqual(29, indianCensusRecord.Count());
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, e.type);
            }
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            try
            {
                IEnumerable<string> indianCensusRecord = censusAnalyser.loadCSVFileData(indianCensusDataHeaders,wrongHeaderFile);
                Assert.AreEqual(29, indianCensusRecord.Count());
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
            IEnumerable<string> indianStateCodeRecord = censusAnalyser.loadCSVFileData(indianStateCodeHeader,indianStateCodeFile);
            Assert.AreEqual(37, indianStateCodeRecord.Count());
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            try
            {
                IEnumerable<string> indianStateCodeRecord = censusAnalyser.loadCSVFileData(indianStateCodeHeader,invalidCsvFilePath);
                Assert.AreEqual(37, indianStateCodeRecord.Count());
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.type);
            }
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            try
            {
                IEnumerable<string> indianStateCodeRecord = censusAnalyser.loadCSVFileData(indianStateCodeHeader,nonCSVFile);
                Assert.AreEqual(37, indianStateCodeRecord.Count());
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT, e.type);
            }
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            try
            {
                IEnumerable<string> indianStateCodeRecord = censusAnalyser.loadCSVFileData(indianStateCodeHeader, wrongIndianStateCodeFile);
                Assert.AreEqual(37, indianStateCodeRecord.Count());
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, e.type);
            }
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            try
            {
                IEnumerable<string> indianStateCodeRecord = censusAnalyser.loadCSVFileData(indianStateCodeHeader,wrongHeaderFile);
                Assert.AreEqual(37, indianStateCodeRecord.Count());
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, e.type);
            }
        }
    }
}